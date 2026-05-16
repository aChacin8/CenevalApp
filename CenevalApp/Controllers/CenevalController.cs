using Microsoft.AspNetCore.Mvc;
using CenevalApp.Models;
using CenevalApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CenevalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CenevalController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Fácil(3) → Normal(1) → Difícil(2)
        private static readonly Dictionary<int, string> DifficultyNames = new()
        {
            { 3, "Fácil" },
            { 1, "Normal" },
            { 2, "Difícil" }
        };

        private static readonly Dictionary<int, int> NextDifficulty = new()
        {
            { 3, 1 },
            { 1, 2 }
        };

        public CenevalController(AppDbContext context)
        {
            _context = context;
        }

        // ── Proyección de una pregunta con opciones aleatorias ───────────────
        private static object ProjectQuestion(Question q)
        {
            var rng = new Random();
            var shuffledOptions = q.Options
                .OrderBy(_ => rng.Next())
                .Select(o => new { o.OptionId, o.Text })
                .ToList();

            return new
            {
                q.QuestionId,
                q.Content,
                q.Difficulty,
                DifficultyName = DifficultyNames.GetValueOrDefault(q.Difficulty, "Normal"),
                Options = shuffledOptions
            };
        }

        // ── Crear o recuperar evaluación activa ──────────────────────────────
        private async Task<Evaluation> EnsureActiveEvaluation(UserProgress progress)
        {
            if (progress.CurrentEvaluationId.HasValue)
            {
                var existing = await _context.Evaluations
                    .FirstOrDefaultAsync(e => e.EvaluationId == progress.CurrentEvaluationId.Value);
                if (existing != null) return existing;
            }

            var evaluation = new Evaluation
            {
                UserIdInt = progress.UserIdInt,
                StartDateTime = DateTime.Now,
                TotalQuestions = 0,
                CorrectAnswers = 0,
                ScorePercentage = 0
            };
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();

            progress.CurrentEvaluationId = evaluation.EvaluationId;
            return evaluation;
        }

        // ─────────────────────────────────────────────────────────────────────
        [HttpGet("status/{userId}")]
        public async Task<ActionResult<UserProgress>> GetStatus(string userId)
        {
            var progress = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (progress == null)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == userId);

                int userIdInt = user?.Id ?? 0;

                // Inicia en Fácil (Difficulty = 3)
                progress = new UserProgress
                {
                    UserId = userId,
                    UserIdInt = userIdInt,
                    CurrentTopicId = 1,
                    CurrentDifficulty = 3
                };
                _context.UserProgress.Add(progress);
                await _context.SaveChangesAsync();
            }

            // Crear evaluación activa si no existe
            await EnsureActiveEvaluation(progress);
            await _context.SaveChangesAsync();

            var answeredIds = string.IsNullOrEmpty(progress.AnsweredQuestionsIds)
                ? new List<int>()
                : progress.AnsweredQuestionsIds.Split(',').Select(int.Parse).ToList();

            var totalAvailable = await _context.Questions.CountAsync(q => q.Options.Any());
            progress.IsCompleted = progress.TotalQuestionsAsked >= 30 || answeredIds.Count >= totalAvailable;

            return Ok(progress);
        }

        // ─────────────────────────────────────────────────────────────────────
        [HttpGet("next-question/{userId}")]
        public async Task<ActionResult> GetNextQuestion(string userId)
        {
            var progress = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (progress == null)
                return BadRequest("Usuario no encontrado.");

            var answeredIds = string.IsNullOrEmpty(progress.AnsweredQuestionsIds)
                ? new List<int>()
                : progress.AnsweredQuestionsIds.Split(',').Select(int.Parse).ToList();

            var totalAvailable = await _context.Questions.CountAsync(q => q.Options.Any());
            if (progress.TotalQuestionsAsked >= 30 || answeredIds.Count >= totalAvailable)
                return BadRequest("Evaluación finalizada.");

            // 1️⃣ Intentar con tema y dificultad exactos
            var question = await _context.Questions
                .Include(q => q.Options)
                .Where(q => q.TopicId == progress.CurrentTopicId
                         && q.Difficulty == progress.CurrentDifficulty
                         && q.Options.Any()
                         && !answeredIds.Contains(q.QuestionId))
                .OrderBy(r => EF.Functions.Random())
                .FirstOrDefaultAsync();

            // 2️⃣ Fallback: misma dificultad, cualquier tema
            question ??= await _context.Questions
                .Include(q => q.Options)
                .Where(q => q.Difficulty == progress.CurrentDifficulty
                         && q.Options.Any()
                         && !answeredIds.Contains(q.QuestionId))
                .OrderBy(r => EF.Functions.Random())
                .FirstOrDefaultAsync();

            // 3️⃣ Fallback final: cualquier pregunta no respondida
            question ??= await _context.Questions
                .Include(q => q.Options)
                .Where(q => q.Options.Any() && !answeredIds.Contains(q.QuestionId))
                .OrderBy(r => EF.Functions.Random())
                .FirstOrDefaultAsync();

            if (question == null)
                return NotFound("No hay más preguntas disponibles.");

            // Opciones en orden aleatorio (la correcta no siempre en posición 0)
            return Ok(ProjectQuestion(question));
        }

        // ─────────────────────────────────────────────────────────────────────
        [HttpPost("submit-answer")]
        public async Task<ActionResult> SubmitAnswer([FromBody] AnswerSubmission dto)
        {
            var progress = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserId == dto.UserId);

            var option = await _context.Options
                .Include(o => o.Question)
                .FirstOrDefaultAsync(o => o.OptionId == dto.OptionId);

            if (progress == null || option == null) return NotFound();

            // Asegurar evaluación activa
            var evaluation = await EnsureActiveEvaluation(progress);

            progress.TotalQuestionsAsked++;

            // Registrar pregunta como respondida
            var answeredIds = string.IsNullOrEmpty(progress.AnsweredQuestionsIds)
                ? new List<int>()
                : progress.AnsweredQuestionsIds.Split(',').Select(int.Parse).ToList();

            if (!answeredIds.Contains(option.QuestionId))
            {
                answeredIds.Add(option.QuestionId);
                progress.AnsweredQuestionsIds = string.Join(",", answeredIds);
            }

            bool isCorrect = option.IsCorrect;
            bool levelUpTriggered = false;

            if (isCorrect)
            {
                progress.TotalCorrectAnswers++;
                progress.ConsecutiveHits++;

                // 5 aciertos consecutivos → proponer subida de nivel
                if (progress.ConsecutiveHits >= 5 && NextDifficulty.ContainsKey(progress.CurrentDifficulty))
                {
                    progress.LevelUpPending = true;
                    levelUpTriggered = true;
                    // ConsecutiveHits se reinicia en confirm-levelup
                }
            }
            else
            {
                // Fallo: reiniciar racha, NO bajar de nivel
                progress.ConsecutiveHits = 0;
            }

            // Guardar detalle de respuesta en EvaluationDetails
            _context.EvaluationDetails.Add(new EvaluationDetail
            {
                EvaluationId = evaluation.EvaluationId,
                QuestionId = option.QuestionId,
                SelectedOptionId = dto.OptionId,
                IsCorrect = isCorrect
            });

            // Alternar tema para variar las preguntas (1 → 2 → 1 → 2 …)
            var topicCount = await _context.Topics.CountAsync();
            if (topicCount > 1)
                progress.CurrentTopicId = (progress.CurrentTopicId % topicCount) + 1;

            var totalAvailable = await _context.Questions.CountAsync(q => q.Options.Any());
            progress.IsCompleted = progress.TotalQuestionsAsked >= 30 || answeredIds.Count >= totalAvailable;

            // Si el examen terminó → finalizar la evaluación
            if (progress.IsCompleted)
            {
                evaluation.TotalQuestions = progress.TotalQuestionsAsked;
                evaluation.CorrectAnswers = progress.TotalCorrectAnswers;
                evaluation.ScorePercentage = progress.TotalQuestionsAsked > 0
                    ? Math.Round((decimal)progress.TotalCorrectAnswers / progress.TotalQuestionsAsked * 100, 2)
                    : 0;
                progress.CurrentEvaluationId = null;
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Correct = isCorrect,
                Feedback = option.Question?.Feedback,
                LevelUpTriggered = levelUpTriggered,
                CurrentDifficulty = progress.CurrentDifficulty,
                CurrentDifficultyName = DifficultyNames.GetValueOrDefault(progress.CurrentDifficulty, "Normal"),
                NextStatus = progress
            });
        }

        // ─────────────────────────────────────────────────────────────────────
        /// <summary>
        /// Confirma o rechaza la propuesta de subida de nivel.
        /// Body: { "accept": true/false }
        /// </summary>
        [HttpPost("confirm-levelup/{userId}")]
        public async Task<ActionResult> ConfirmLevelUp(string userId, [FromBody] LevelUpConfirmation dto)
        {
            var progress = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (progress == null) return NotFound();

            if (dto.Accept && NextDifficulty.ContainsKey(progress.CurrentDifficulty))
                progress.CurrentDifficulty = NextDifficulty[progress.CurrentDifficulty];

            // Limpiar flag y racha en cualquier caso
            progress.LevelUpPending = false;
            progress.ConsecutiveHits = 0;

            await _context.SaveChangesAsync();

            // Devolver también la siguiente pregunta para evitar un viaje extra al servidor
            var answeredIds = string.IsNullOrEmpty(progress.AnsweredQuestionsIds)
                ? new List<int>()
                : progress.AnsweredQuestionsIds.Split(',').Select(int.Parse).ToList();

            var nextQuestion = await _context.Questions
                .Include(q => q.Options)
                .Where(q => q.Difficulty == progress.CurrentDifficulty
                         && q.Options.Any()
                         && !answeredIds.Contains(q.QuestionId))
                .OrderBy(r => EF.Functions.Random())
                .FirstOrDefaultAsync();

            // Fallback si no hay de la nueva dificultad
            nextQuestion ??= await _context.Questions
                .Include(q => q.Options)
                .Where(q => q.Options.Any() && !answeredIds.Contains(q.QuestionId))
                .OrderBy(r => EF.Functions.Random())
                .FirstOrDefaultAsync();

            return Ok(new
            {
                Accepted = dto.Accept,
                NewDifficulty = progress.CurrentDifficulty,
                NewDifficultyName = DifficultyNames.GetValueOrDefault(progress.CurrentDifficulty, "Normal"),
                Progress = progress,
                NextQuestion = nextQuestion != null ? ProjectQuestion(nextQuestion) : null
            });
        }

        // ─────────────────────────────────────────────────────────────────────
        [HttpPost("restart/{userId}")]
        public async Task<ActionResult> Restart(string userId)
        {
            var progress = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (progress == null) return NotFound();

            // Finalizar evaluación activa si tiene preguntas respondidas (evaluación abandonada)
            if (progress.CurrentEvaluationId.HasValue && progress.TotalQuestionsAsked > 0)
            {
                var activeEval = await _context.Evaluations
                    .FirstOrDefaultAsync(e => e.EvaluationId == progress.CurrentEvaluationId.Value);

                if (activeEval != null && activeEval.TotalQuestions == 0)
                {
                    activeEval.TotalQuestions = progress.TotalQuestionsAsked;
                    activeEval.CorrectAnswers = progress.TotalCorrectAnswers;
                    activeEval.ScorePercentage = Math.Round(
                        (decimal)progress.TotalCorrectAnswers / progress.TotalQuestionsAsked * 100, 2);
                }
            }

            // Reiniciar progreso
            progress.TotalQuestionsAsked = 0;
            progress.TotalCorrectAnswers = 0;
            progress.ConsecutiveHits = 0;
            progress.CurrentDifficulty = 3;   // Vuelve a Fácil
            progress.CurrentTopicId = 1;
            progress.AnsweredQuestionsIds = "";
            progress.LevelUpPending = false;
            progress.CurrentEvaluationId = null;
            progress.IsCompleted = false;

            await _context.SaveChangesAsync();

            // Crear nueva evaluación para el nuevo intento
            var newEvaluation = new Evaluation
            {
                UserIdInt = progress.UserIdInt,
                StartDateTime = DateTime.Now,
                TotalQuestions = 0,
                CorrectAnswers = 0,
                ScorePercentage = 0
            };
            _context.Evaluations.Add(newEvaluation);
            await _context.SaveChangesAsync();

            progress.CurrentEvaluationId = newEvaluation.EvaluationId;
            await _context.SaveChangesAsync();

            return Ok(progress);
        }
    }

    public class AnswerSubmission
    {
        public string UserId { get; set; } = string.Empty;
        public int OptionId { get; set; }
    }

    public class LevelUpConfirmation
    {
        public bool Accept { get; set; }
    }
}
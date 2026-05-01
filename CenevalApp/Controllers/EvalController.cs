using Microsoft.AspNetCore.Mvc;
using CenevalApp.Models;
using CenevalApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CenevalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EvalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("status/{userId}")]
        public async Task<ActionResult<UserProgress>> GetStatus(string userId)
        {
            var progress = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (progress == null)
            {
                progress = new UserProgress
                {
                    UserId = userId,
                    CurrentTopicId = 1, 
                    CurrentDifficulty = 1
                };
                _context.UserProgress.Add(progress);
                await _context.SaveChangesAsync();
            }

            return Ok(progress);
        }

        [HttpGet("next-question/{userId}")]
        public async Task<ActionResult> GetNextQuestion(string userId)
        {
            var progress = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (progress == null || progress.IsCompleted)
                return BadRequest("Evaluación finalizada o usuario no encontrado.");

            var question = await _context.Questions
                .Include(q => q.Options)
                .Where(q => q.TopicId == progress.CurrentTopicId && q.Difficulty == progress.CurrentDifficulty)
                .OrderBy(r => Guid.NewGuid()) 
                .Select(q => new {
                    q.QuestionId,
                    q.Content,
                    Options = q.Options.Select(o => new { o.OptionId, o.Text }) 
                })
                .FirstOrDefaultAsync();

            return Ok(question);
        }

        [HttpPost("submit-answer")]
        public async Task<ActionResult> SubmitAnswer([FromBody] AnswerSubmission dto)
        {
            var progress = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserId == dto.UserId);

            var option = await _context.Options
                .Include(o => o.Question)
                .FirstOrDefaultAsync(o => o.OptionId == dto.OptionId);

            if (progress == null || option == null) return NotFound();

            progress.TotalQuestionsAsked++;

            bool isCorrect = option.IsCorrect;
            if (isCorrect)
            {
                progress.TotalCorrectAnswers++;
                progress.ConsecutiveHits++;
            }
            else
            {
                progress.ConsecutiveHits = 0;
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Correct = isCorrect,
                Feedback = option.Question?.Feedback,
                NextStatus = progress
            });
        }
    }

    public class AnswerSubmission
    {
        public string UserId { get; set; } = string.Empty;
        public int OptionId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace CenevalApp.Models
{
    public class UserProgress
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int UserIdInt { get; set; }

        public int CurrentTopicId { get; set; }
        public int CurrentDifficulty { get; set; } = 3;
        public int ConsecutiveHits { get; set; } = 0;

        public int TotalQuestionsAsked { get; set; } = 0;
        public int TotalCorrectAnswers { get; set; } = 0;

        public string AnsweredQuestionsIds { get; set; } = string.Empty;

        // Señal al frontend para mostrar el diálogo de confirmación de subida de nivel
        public bool LevelUpPending { get; set; } = false;

        // ID de la evaluación activa (se asigna al iniciar o reiniciar)
        public int? CurrentEvaluationId { get; set; }

        [NotMapped]
        public bool IsCompleted { get; set; }

        // Navegación
        public User? User { get; set; }
    }
}
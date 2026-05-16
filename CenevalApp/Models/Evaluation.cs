using System.ComponentModel.DataAnnotations;

namespace CenevalApp.Models
{
    public class Evaluation
    {
        [Key]
        public int EvaluationId { get; set; }

        public int UserIdInt { get; set; }
        public DateTime StartDateTime { get; set; } = DateTime.Now;
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public decimal ScorePercentage { get; set; }

        // Navegación
        public User? User { get; set; }
        public ICollection<EvaluationDetail> Details { get; set; } = new List<EvaluationDetail>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace CenevalApp.Models
{
    public class EvaluationDetail
    {
        [Key]
        public int DetailId { get; set; }

        public int EvaluationId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }

        // Navegación
        public Evaluation? Evaluation { get; set; }
        public Question? Question { get; set; }
        public Option? SelectedOption { get; set; }
    }
}

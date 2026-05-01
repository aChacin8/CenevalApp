namespace CenevalApp.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int TopicId { get; set; }

        public int Difficulty { get; set; }

        public string Content { get; set; } = string.Empty;

        public string Feedback { get; set; } = string.Empty;

        // Relaciones
        public Topic? Topic { get; set; }
        public ICollection<Option> Options { get; set; } = new List<Option>();
    }
}
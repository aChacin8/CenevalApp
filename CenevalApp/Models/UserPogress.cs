namespace CenevalApp.Models
{
    public class UserProgress
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public int CurrentTopicId { get; set; }
        public int CurrentDifficulty { get; set; } = 1;
        public int ConsecutiveHits { get; set; } = 0;

        public int TotalQuestionsAsked { get; set; } = 0;
        public int TotalCorrectAnswers { get; set; } = 0;

        public bool IsCompleted => TotalQuestionsAsked >= 30;
    }
}
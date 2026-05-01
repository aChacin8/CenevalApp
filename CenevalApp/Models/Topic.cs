namespace CenevalApp.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
namespace Ptoject.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public List<Questions>? Questions { get; set; }
    }
}

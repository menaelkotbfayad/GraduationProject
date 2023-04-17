using System.ComponentModel.DataAnnotations.Schema;

namespace Ptoject.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Degree { get; set; }
        [ForeignKey(nameof(Subjects))]
        public int SubId { get; set; }
        public Subjects Subjects { get; set; }
        public int QuestionType { get; set; }
        public virtual List<Answers>? Answers { get; set; }
        public virtual List<QuestionUser> QuestionUser { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Ptoject.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public string? Answer { get; set; }
        public bool IsTrue { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestionID { get; set; }
        public Questions? Question { get; set; }
    }
}

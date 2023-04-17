using System.ComponentModel.DataAnnotations.Schema;

namespace Ptoject.Models
{
    public class AnswerUser
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Answer))]
        public int AnswerID { get; set; }
        public Answers Answer { get; set; }

        [ForeignKey(nameof(Question))]
        public int QuestionID { get; set; }
        public Questions Question { get; set; }
        public string QuestionName { get; set; }
        public string AnswerName { get; set; }
        public double DegreeeQuestion { get; set; }
        public double DegreeeStudent { get; set; }
        public string ApplicationDbUserId { get; set; }
        public virtual ApplicationDbUser ApplicationDbUser { get; set; }

    }
}

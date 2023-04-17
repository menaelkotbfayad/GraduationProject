using Microsoft.AspNetCore.Identity;
using Ptoject.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ptoject.Models
{
    public class QuestionUser
    {
        public int Id { get; set; }
        public int QuestionsId { get; set; }
        public virtual Questions Questions { get; set; }
        public string ApplicationDbUserId { get; set; }
        public virtual ApplicationDbUser ApplicationDbUser { get; set; }
    }
}

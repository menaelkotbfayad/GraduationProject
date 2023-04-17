using Ptoject.Models;
using System.ComponentModel.DataAnnotations;

namespace Ptoject.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This Faild is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This Faild is required")]
        public double Degree { get; set; }
        [Required(ErrorMessage = "This Faild is required")]
        public int SubId { get; set; }
        public int QuestionType { get; set; }
        public virtual List<Answers>? Answers { get; set; }
    }
}

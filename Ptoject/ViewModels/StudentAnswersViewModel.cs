using Ptoject.Models;
using System.ComponentModel.DataAnnotations;

namespace Ptoject.ViewModels
{
    public class StudentAnswersViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Faild is required")]
        public int AnswerID { get; set; }
        [Required(ErrorMessage = "This Faild is required")]
        public int QuestionID { get; set; }
        [Required(ErrorMessage = "This Faild is required")]
        public string QuestionName { get; set; }
        [Required(ErrorMessage = "This Faild is required")]
        public string AnswerName { get; set; }
        [Required(ErrorMessage = "This Faild is required")]
        public double DegreeeQuestion { get; set; }
        [Required(ErrorMessage = "This Faild is required")]
        public double DegreeeStudent { get; set; }

    }
}

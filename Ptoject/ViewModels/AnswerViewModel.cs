using Microsoft.Build.Framework;
using Ptoject.Models;
using System.ComponentModel.DataAnnotations;

namespace Ptoject.ViewModels
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "This Faild is required")]
        public string Answer { get; set; }
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "This Faild is required")]
        public bool IsTrue { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "This Faild is required")]
        public int QuestionID { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ptoject.Data;
using Ptoject.Models;
using Ptoject.Services.Interfaces;
using Ptoject.ViewModels;

namespace Ptoject.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestion _question;
        private readonly ApplicationDbContext _context;
        public QuestionController(IQuestion question, ApplicationDbContext context)
        {
            _question= question;
            _context=context;
        }
        public IActionResult AddNewQuestion()
        {
            ViewBag.Subjects = _context.Subjects.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult SaveNewQuestion(QuestionViewModel question)
        {
            if(ModelState.IsValid)
            {
              var check =   _question.AddNewQuestion(question);
                //if(check != 0)
                //{
                //    ViewBag.Subjects = _context.Subjects.ToList();
                //    return RedirectToAction(nameof(Index));
                //}
                return Json(new { hhhh = View() });
            }
            else
            {
            return View(nameof(AddNewQuestion),question);
            }
        }
        public IActionResult Index()
        {
            ViewBag.Subjects = _context.Subjects.ToList();
            var questions = _question.GetQuestions();
            return View();
        }

        public IActionResult getQuestionOfThisSubject(int id)
        {
            var sub = _context.Subjects.Where(d => d.Id == id).FirstOrDefault();
            var questions = _context.Questions.Where(s => s.SubId == sub.Id).ToList();
            return View(questions);
        }
    }
}

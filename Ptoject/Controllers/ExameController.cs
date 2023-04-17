using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Ptoject.Data;
using Ptoject.Models;
using Ptoject.Services.Interfaces;

namespace Ptoject.Controllers
{
    public class ExameController : Controller
    {
        private readonly IQuestion _question;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationDbUser> _userManager;
        public ExameController(IQuestion question, ApplicationDbContext context,
            UserManager<ApplicationDbUser> userManager)
        {
            _question = question;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            Random rr = new Random();
            Random rrSub = new Random();

            var questions = _context.Questions.Include(d => d.Answers).ToList();
            var subjects = _context.Subjects.ToList();

            List<int> subId = new List<int>();

            List<int> ints = new List<int>();
            var user = _context.Users.FirstOrDefault(d => d.UserName == User.Identity.Name);

            foreach (var question in questions)
            {
                ints.Add(question.Id);
            }
            foreach (var sub in subjects)
            {
                subId.Add(sub.Id);
            }
            IEnumerable<int> threeRandom = ints.OrderBy(x => rr.Next()).Take(20);
            IEnumerable<int> oneSub = subId.OrderBy(x => rrSub.Next()).Take(1);


            foreach (var sub in oneSub)
            {
                ViewBag.Subject = _context.Subjects.Where(d => d.Id == sub).Select(c => c.Subject).FirstOrDefault();
            }
            List<Questions> q2 = new List<Questions>();
            foreach (var question in threeRandom)
            {
                Questions questions1 = _context.Questions.Where(d => d.Id == question).FirstOrDefault();
                q2.Add(questions1);
            }
            List<QuestionUser> exames = new List<QuestionUser>();
            foreach (var question in q2)
            {
                QuestionUser exame = new QuestionUser();
                exame.QuestionsId = question.Id;
                exame.ApplicationDbUserId = user.Id;
                exames.Add(exame);
            }
            _context.QuestionUser.AddRange(exames);
            _context.SaveChanges();
            return View(q2);



        }

        [HttpPost]
        public IActionResult CheckAnswer(int id)
        {
            var ans = _context.Answers.Where(d => d.Id == id).Include(n=>n.Question).FirstOrDefault();
            var user = _context.Users.FirstOrDefault(d => d.UserName == User.Identity.Name);


            if (ans != null)
            {
                var qu = _context.Questions.Where(d => d.Id == ans.QuestionID).FirstOrDefault();
                var ansStudent = new AnswerUser();
                ansStudent.AnswerID = ans.Id;
                ansStudent.QuestionID = ans.QuestionID;
                ansStudent.AnswerName = ans.Answer;
                ansStudent.QuestionName = ans.Question.Title;
                ansStudent.DegreeeQuestion = ans.Question.Degree;
                ansStudent.ApplicationDbUserId = user.Id;
                if (ans.IsTrue)
                {
                    ansStudent.DegreeeStudent=ans.Question.Degree;
                    _context.AnswerUser.Add(ansStudent);
                    _context.SaveChanges();

                    return Json(new { res = "Ok" });
                }
                else
                {
                    ansStudent.DegreeeStudent =0;
                    _context.AnswerUser.Add(ansStudent);
                    _context.SaveChanges();
                    return Json(new { res = "Cancel" });
                }
            }
            return RedirectToAction("Index");
        }
    }
}
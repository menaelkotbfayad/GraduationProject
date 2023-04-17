using Ptoject.Data;
using Ptoject.Models;
using Ptoject.Services.Interfaces;
using Ptoject.ViewModels;

namespace Ptoject.Services.Implementation
{
    public class QuestionRepo : IQuestion
    {
        private readonly ApplicationDbContext _context;
        public QuestionRepo(ApplicationDbContext context)
        {
            _context= context;
        }
        public int AddNewQuestion(QuestionViewModel question)
        {
            if(question != null)
            {
                Questions questions = new Questions();
                questions.Title = question.Title;
                questions.Degree = question.Degree;
               questions.SubId= question.SubId;
                questions.QuestionType= question.QuestionType;
                _context.Questions.Add(questions);
                //int rows = _context.SaveChanges();
                questions.Answers = new List<Answers>();
                
               
                for(int i= 0; i < question.Answers.Count; i++)
                {
                    if (question.Answers[i].Answer != null)
                    {
                        questions.Answers.Add(new Answers
                        {
                            IsTrue = question.Answers[i].IsTrue,
                            Answer = question.Answers[i].Answer
                        });
                    }
                    //if (question.Answers[i].Answer != null)
                    //{
                    //    Answers answers = new Answers();

                    //    answers.QuestionID = questions.Id;
                    //    answers.Answer = question.Answers[i].Answer;
                    //    answers.IsTrue = question.Answers[i].IsTrue;
                    //    _context.Answers.Add(answers);
                    //}
                }
                int rows = _context.SaveChanges();
                return rows;
            }
            return 0;
        }

        public List<QuestionViewModel> GetQuestions()
        {
            var questions = new List<QuestionViewModel>();
            questions = _context.Questions.Select(n => new QuestionViewModel { 
            Title=n.Title,
            Degree = n.Degree,
            }).ToList();
            return questions;
        }
    }
}

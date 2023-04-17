using Ptoject.ViewModels;

namespace Ptoject.Services.Interfaces
{
    public interface IQuestion
    {
        int AddNewQuestion(QuestionViewModel question);
        List<QuestionViewModel> GetQuestions();
    }
}

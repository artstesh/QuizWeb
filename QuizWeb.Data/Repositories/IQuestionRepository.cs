using System.Collections.Generic;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories
{
    public interface IQuestionRepository
    {
        bool AddOrUpdate(Question question);
        List<QuestionModel> GetByTheme(int parentThemeId);
        QuestionModel Get(int id);
    }
}

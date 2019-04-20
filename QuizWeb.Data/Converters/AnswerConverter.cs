using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Converters
{
    public static class AnswerConverter
    {
        public static AnswerModel ToDto(this Answer model)
        {
            if (model == null) return null;
            return new AnswerModel
            {
                Text = model.Text, Id = model.Id, IsCorrect = model.IsCorrect, QuestionId = model.QuestionId
            };
        }

        public static Answer FromDto(this AnswerModel model)
        {
            if (model == null) return null;
            return new Answer
            {
                Text = model.Text, Id = model.Id, IsCorrect = model.IsCorrect, QuestionId = model.QuestionId
            };
        }
    }
}
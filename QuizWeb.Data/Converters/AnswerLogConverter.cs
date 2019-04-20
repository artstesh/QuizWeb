using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Converters
{
    public static class AnswerLogLogConverter
    {
        public static AnswerLogModel ToDto(this AnswerLog origin)
        {
            if (origin == null) return null;
            return new AnswerLogModel
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct,
                ThemeId = origin.ThemeId, Id = origin.Id
            };
        }

        public static AnswerLog FromDto(this AnswerLogModel origin)
        {
            if (origin == null) return null;
            return new AnswerLog
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct,
                ThemeId = origin.ThemeId, Id = origin.Id
            };
        }
    }
}
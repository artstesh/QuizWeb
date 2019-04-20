using System.Linq;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Converters
{
    public static class QuestionConverter
    {
        public static QuestionModel ToDto(this Question origin)
        {
            if (origin == null) return null;
            return new QuestionModel
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, Id = origin.Id,
                Answers = origin.Answers.Select(e => e.ToDto()).ToList()
            };
        }

        public static Question FromDto(this QuestionModel origin)
        {
            if (origin == null) return null;
            return new Question
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, Id = origin.Id,
                Answers = origin.Answers.Select(e => e.FromDto()).ToList()
            };
        }
    }
}
using System;
using System.Collections.Generic;

namespace QuizWeb.Data.Models
{
    public class QuestionModel : IEquatable<QuestionModel>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int LevelId { get; set; }
        public int ThemeId { get; set; }
        public LevelModel Level { get; set; }
        public ThemeModel Theme { get; set; }
        public List<AnswerModel> Answers { get; set; }

        public bool Equals(QuestionModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Text, other.Text) && LevelId == other.LevelId &&
                   ThemeId == other.ThemeId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((QuestionModel) obj);
        }
    }
}
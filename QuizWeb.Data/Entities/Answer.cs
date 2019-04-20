using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Data.Entities
{
    [Table("answer")]
    public class Answer : BaseEntity, IEquatable<Answer>
    {
        [Column("Text")] public string Text { get; set; }

        [Column("IsCorrect")] public bool IsCorrect { get; set; }

        [Column("QuestionId")] public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public bool Equals(Answer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Text, other.Text) && IsCorrect == other.IsCorrect && QuestionId == other.QuestionId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Answer) obj);
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Data.Entities
{
    [Table("answer_log")]
    public class AnswerLog : BaseEntity, IEquatable<AnswerLog>
    {
        [Column("SessionId")] public string SessionId { get; set; }

        [Column("AnswerId")] public int AnswerId { get; set; }

        [Column("IsCorrect")] public bool Correct { get; set; }

        [Column("ThemeId")] public int ThemeId { get; set; }

        public bool Equals(AnswerLog other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(SessionId, other.SessionId) && AnswerId == other.AnswerId &&
                   Correct == other.Correct && ThemeId == other.ThemeId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AnswerLog) obj);
        }
    }
}
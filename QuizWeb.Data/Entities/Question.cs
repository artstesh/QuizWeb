using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Data.Entities
{
    [Table("question")]
    public class Question : DeletableEntity, IEquatable<Question>
    {
        [Column("Text")] public string Text { get; set; }

        [Column("LevelId")] public int LevelId { get; set; }

        [Column("ThemeId")] public int ThemeId { get; set; }

        public virtual Level Level { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual List<Answer> Answers { get; set; }

        public bool Equals(Question other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Text, other.Text) && LevelId == other.LevelId &&
                   ThemeId == other.ThemeId && IsDeleted == other.IsDeleted;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Question) obj);
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Data.Entities
{
    [Table("theme")]
    public class Theme : BaseEntity, IEquatable<Theme>
    {
        [Column("Name")] public string Name { get; set; }

        [Column("ParentThemeId")] public int? ParentThemeId { get; set; }

        public virtual Theme ParentTheme { get; set; }

        public bool Equals(Theme other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && ParentThemeId == other.ParentThemeId &&
                   Equals(ParentTheme, other.ParentTheme);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Theme) obj);
        }
    }
}
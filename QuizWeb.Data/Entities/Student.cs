using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Data.Entities
{
    [Table("student")]
    public class Student : BaseEntity
    {
        [Column("Login")] public string Login { get; set; }

        [Column("Name")] public string Name { get; set; }

        [Column("ExamTime")] public DateTime ExamTime { get; set; }
        [Column("ExamThemeId")] public int ExamThemeId { get; set; }

        public bool Equals(Student other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Login, other.Login) &&
                   string.Equals(Name, other.Name) &&
                   ExamThemeId == other.ExamThemeId &&
                   ExamTime.Equals(other.ExamTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((User) obj);
        }
    }
}
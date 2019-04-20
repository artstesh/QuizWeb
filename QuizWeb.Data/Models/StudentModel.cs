using System;

namespace QuizWeb.Data.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public DateTime ExamTime { get; set; }
        public int ExamThemeId { get; set; }

        public bool Equals(StudentModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Login, other.Login) && string.Equals(Name, other.Name) &&
                   ExamThemeId == other.ExamThemeId &&
                   ExamTime.Equals(other.ExamTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((UserModel) obj);
        }
    }
}
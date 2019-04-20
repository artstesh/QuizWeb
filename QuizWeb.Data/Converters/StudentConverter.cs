using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Converters
{
    public static class StudentConverter
    {
        public static StudentModel ToDto(this Student origin)
        {
            if (origin == null) return null;
            return new StudentModel
            {
                Name = origin.Name, Login = origin.Login, ExamTime = origin.ExamTime, Id = origin.Id,
                ExamThemeId = origin.ExamThemeId
            };
        }

        public static Student FromDto(this StudentModel origin)
        {
            if (origin == null) return null;
            return new Student
            {
                Name = origin.Name, Login = origin.Login, ExamTime = origin.ExamTime, Id = origin.Id,
                ExamThemeId = origin.ExamThemeId
            };
        }
    }
}
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuizWeb.Models
{
    public class StudentEditionViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public DateTime ExamTime { get; set; }
        public int ExamThemeId { get; set; }
        public SelectList Themes { get; set; }
    }
}
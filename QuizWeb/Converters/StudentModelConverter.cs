using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizWeb.Data.Models;
using QuizWeb.Models;

namespace QuizWeb.Converters
{
    public static class StudentModelConverter
    {
        public static StudentModel ToModel(this StudentEditionViewModel model)
        {
            if (model == null) return null;
            return new StudentModel
            {
                ExamTime = model.ExamTime, Id = model.Id, Name = model.Name, Login = model.Login, ExamThemeId = model.ExamThemeId
            };
        }
        
        public static StudentEditionViewModel ToView(this StudentModel model, List<ThemeModel> themes)
        {
            if (model == null) return null;
            var list = new SelectList(themes, "Id", "Name");
            return new StudentEditionViewModel
            {
                ExamTime = model.ExamTime, Id = model.Id, Name = model.Name, Login = model.Login, ExamThemeId = model.ExamThemeId, Themes = list
            };
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Models
{
    public class QuestionViewModel
    {
        public QuestionViewModel(List<Theme> themes, List<LevelModel> levels)
        {
            Levels = new List<SelectListItem>();
            Levels.AddRange(levels.Select(e => new SelectListItem {Text = e.Name, Value = e.Id.ToString()}));
            Levels.First().Selected = true;

            Themes = new List<SelectListItem>();
            Themes.AddRange(themes.Select(e => new SelectListItem {Text = e.Name, Value = e.Id.ToString()}));
            Themes.First().Selected = true;
            Answer1Text = string.Empty;
            Answer2Text = string.Empty;
            Answer3Text = string.Empty;
            Answer4Text = string.Empty;
            Answer5Text = string.Empty;
            Answer6Text = string.Empty;
        }

        public QuestionViewModel()
        {
            Levels = new List<SelectListItem>();
            Themes = new List<SelectListItem>();
            Answer1Text = string.Empty;
            Answer2Text = string.Empty;
            Answer3Text = string.Empty;
            Answer4Text = string.Empty;
            Answer5Text = string.Empty;
            Answer6Text = string.Empty;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int LevelId { get; set; }
        public int ThemeId { get; set; }

        public bool Answer1 { get; set; }
        public bool Answer2 { get; set; }
        public bool Answer3 { get; set; }
        public bool Answer4 { get; set; }
        public bool Answer5 { get; set; }
        public bool Answer6 { get; set; }

        public int Answer1Id { get; set; }
        public int Answer2Id { get; set; }
        public int Answer3Id { get; set; }
        public int Answer4Id { get; set; }
        public int Answer5Id { get; set; }
        public int Answer6Id { get; set; }

        public string Answer1Text { get; set; }
        public string Answer2Text { get; set; }
        public string Answer3Text { get; set; }
        public string Answer4Text { get; set; }
        public string Answer5Text { get; set; }
        public string Answer6Text { get; set; }

        public List<SelectListItem> Levels { get; set; }
        public List<SelectListItem> Themes { get; set; }
    }
}
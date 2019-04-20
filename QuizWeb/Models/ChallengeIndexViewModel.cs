using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizWeb.Data.Models;

namespace QuizWeb.Models
{
    public class ChallengeIndexViewModel
    {
        public List<QuestionModel> Questions { get; set; }
        public int ThemeId { get; set; }
        public List<SelectListItem> Themes { get; set; }

        public ChallengeIndexViewModel()
        {
            Themes = new List<SelectListItem>();
            Questions = new List<QuestionModel>();
        }
    }
}
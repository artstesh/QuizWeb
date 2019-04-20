using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Models;

namespace QuizWeb.Converters
{
    public static class QuestionConverter
    {
        public static QuestionViewModel ToViewModel(this QuestionModel question, List<ThemeModel> themes, List<LevelModel> levels)
        {
            if (question == null) return null;

            var model = new QuestionViewModel
            {
                Text = question.Text, Id = question.Id, LevelId = question.LevelId, ThemeId = question.ThemeId
            };
            model.Answer1Text = question.Answers[0].Text;
            model.Answer2Text = question.Answers[1].Text;
            model.Answer3Text = question.Answers[2].Text;
            model.Answer4Text = question.Answers[3].Text;
            model.Answer5Text = question.Answers.Count > 5 ? question.Answers[4].Text : string.Empty;
            model.Answer6Text = question.Answers.Count > 5 ? question.Answers[5].Text : string.Empty;

            model.Answer1 = question.Answers[0].IsCorrect;
            model.Answer2 = question.Answers[1].IsCorrect;
            model.Answer3 = question.Answers[2].IsCorrect;
            model.Answer4 = question.Answers[3].IsCorrect;
            model.Answer5 = question.Answers.Count > 5 && question.Answers[4].IsCorrect;
            model.Answer6 = question.Answers.Count > 5 && question.Answers[5].IsCorrect;

            model.Answer1Id = question.Answers[0].Id;
            model.Answer2Id = question.Answers[1].Id;
            model.Answer3Id = question.Answers[2].Id;
            model.Answer4Id = question.Answers[3].Id;
            model.Answer5Id = question.Answers.Count > 5 ? question.Answers[4].Id : -1;
            model.Answer6Id = question.Answers.Count > 5 ? question.Answers[5].Id : -1;

            model.Levels = new List<SelectListItem>();
            model.Levels.AddRange(levels.Select(e => new SelectListItem {Text = e.Name, Value = e.Id.ToString()}));
            model.Levels.First().Selected = true;

            model.Themes = new List<SelectListItem>();
            model.Themes.AddRange(themes.Select(e => new SelectListItem {Text = e.Name, Value = e.Id.ToString()}));
            model.Themes.First().Selected = true;

            return model;
        }

        public static Question ToQuestion(this QuestionViewModel model)
        {
            if (model == null) return null;
            var answers = new List<Answer>();
           if(!string.IsNullOrWhiteSpace(model.Answer1Text))answers.Add(new Answer { IsCorrect = model.Answer1, Text = model.Answer1Text, Id = model.Answer1Id });
           if(!string.IsNullOrWhiteSpace(model.Answer2Text)) answers.Add(new Answer { IsCorrect = model.Answer2, Text = model.Answer2Text, Id = model.Answer2Id });
           if(!string.IsNullOrWhiteSpace(model.Answer3Text)) answers.Add(new Answer { IsCorrect = model.Answer3, Text = model.Answer3Text, Id = model.Answer3Id });
           if(!string.IsNullOrWhiteSpace(model.Answer4Text)) answers.Add(new Answer { IsCorrect = model.Answer4, Text = model.Answer4Text, Id = model.Answer4Id });
           if(!string.IsNullOrWhiteSpace(model.Answer5Text)) answers.Add(new Answer { IsCorrect = model.Answer5, Text = model.Answer5Text, Id = model.Answer5Id });
           if(!string.IsNullOrWhiteSpace(model.Answer6Text)) answers.Add(new Answer { IsCorrect = model.Answer6, Text = model.Answer6Text, Id = model.Answer6Id });
            return new Question
            {
                Answers = answers,
                Id = model.Id, Text = model.Text, LevelId = model.LevelId, ThemeId = model.ThemeId
            };
        }

        public static SessionAnswerViewModel ToSessionAnswerViewModel(this QuestionModel question, string guid)
        {
            if (question == null) return null;
            var model = new SessionAnswerViewModel
            {
                SessionKey = guid, QuestionId = question.Id, Text = question.Text
            };
            model.Answer1Text = question.Answers[0].Text;
            model.Answer2Text = question.Answers[1].Text;
            model.Answer3Text = question.Answers[2].Text;
            model.Answer4Text = question.Answers[3].Text;
            model.Answer5Text = question.Answers.Count > 5 ? question.Answers[4].Text : string.Empty;
            model.Answer6Text = question.Answers.Count > 5 ? question.Answers[5].Text : string.Empty;
            model.ThemeName = question.Theme.Name;
            model.Answer1Id = question.Answers[0].Id;
            model.Answer2Id = question.Answers[1].Id;
            model.Answer3Id = question.Answers[2].Id;
            model.Answer4Id = question.Answers[3].Id;
            model.Answer5Id = question.Answers.Count > 5 ? question.Answers[4].Id : -1;
            model.Answer6Id = question.Answers.Count > 5 ? question.Answers[5].Id : -1;
            model.Id = new Random(DateTime.Now.Millisecond).Next();
            return model;
        }
    }
}
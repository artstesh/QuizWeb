using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizWeb.Converters;
using QuizWeb.Data.Converters;
using QuizWeb.Data.Repositories;
using QuizWeb.Models;

namespace Artstesh.Controllers
{
    public class ChallengeControllerHelper : IChallengeControllerHelper
    {
        private readonly IThemeRepository _themeRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ILevelRepository _levelRepository;
        

        public ChallengeControllerHelper(IThemeRepository themeRepository, IQuestionRepository questionRepository, ILevelRepository levelRepository)
        {
            _themeRepository = themeRepository;
            _questionRepository = questionRepository;
            _levelRepository = levelRepository;
        }

        public async Task<ChallengeIndexViewModel> GetIndexModel(int id)
        {
            var model = new ChallengeIndexViewModel();
            var themes = await _themeRepository.GetThemes();
            model.ThemeId = themes.All(e => e.Id != id) ? themes.First().Id : id;
            model.Questions = _questionRepository.GetByTheme(id);
            model.Themes = themes.Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList();
            return model;
        }

        public async Task<QuestionViewModel> GetCreationModel()
        {
            var themes = await _themeRepository.GetAllThemes();
            var levels = _levelRepository.GetLevels();
            var model = new QuestionViewModel(themes.Select(e => e.FromDto()).ToList(), levels);
            return model;
        }

        public async Task<QuestionViewModel> GetForEdidtion(int id)
        {
            var themes = await _themeRepository.GetAllThemes();
            var levels = _levelRepository.GetLevels();
            var model = _questionRepository.Get(id).ToViewModel(themes, levels);
            return model;
        }

        public bool Save(QuestionViewModel model)
        {
            var question = model.ToQuestion();
            question.Answers = question.Answers.Where(a => !string.IsNullOrEmpty(a.Text)).ToList();
            if(question.Answers.Count < 4 || !question.Answers.Any(a => a.IsCorrect)) throw new Exception("Ответов - не меньше 4 и хоть один правильный");
            var saved = _questionRepository.AddOrUpdate(question);
            return saved;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories.Implementation
{
   public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;

        public QuestionRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddOrUpdate(Question question)
        {
            var quest = _context.Challenges.FirstOrDefault(e => e.Id == question.Id);
            if (quest != null) quest.IsDeleted = true;
            question.Id = 0;
            _context.Challenges.Add(question);
            _context.SaveChanges();
            return true;
        }

        public List<QuestionModel> GetByTheme(int parentThemeId)
        {
            var themeIds = _context.Themes.Where(e => e.ParentThemeId == parentThemeId).Select(e => e.Id).ToList();
            themeIds.Add(parentThemeId);
            var questions = _context.Challenges.Where(e => themeIds.Contains(e.ThemeId)).ToList();
            return questions.Select(e => e.ToDto()).ToList();
        }

        public QuestionModel Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

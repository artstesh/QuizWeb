using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories.Implementation
{
    public class ChallengeRepository : IChallengeRepository
    {
        private readonly DataContext _context;

        public ChallengeRepository(DataContext context)
        {
            _context = context;
        }

        public List<QuestionModel> GetChallenge(SessionSettings settings)
        {
            List<QuestionModel> questions;

            questions = _context.Challenges.Include(e => e.Answers).Include(e => e.Theme)
                .Where(e => !e.IsDeleted)
                .Where(e => e.Theme.ParentThemeId == settings.ThemeId).ToList()
                .OrderBy(e => Guid.NewGuid()).Take(settings.QuizCount)
                .Select(e => e.ToDto()).ToList();

            return questions;
        }
    }
}
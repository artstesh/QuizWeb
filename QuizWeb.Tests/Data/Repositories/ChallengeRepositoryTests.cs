using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Data.Repositories.Implementation;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Repositories
{
    public class ChallengeRepositoryTests
    {
        private readonly DataContext _context;
        private readonly ChallengeRepository _repository;

        public ChallengeRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase();
            _context = new DataContext(builder.Options);
            _repository = new ChallengeRepository(_context);
        }

        [Theory, AutoMoqData]
        public void GetChallenge_Success(SessionSettings settings, Question question)
        {
            settings.QuizCount = Int32.MaxValue;
            question.IsDeleted = false;
            question.Theme.ParentThemeId = settings.ThemeId;
            _context.Challenges.Add(question);
            _context.SaveChanges();
            //
            var result = _repository.GetChallenge(settings);
            //
            Assert.True(result.Count == 1);
            Assert.True(result.First().Equals(question.ToDto()));
        }

        [Theory, AutoMoqData]
        public void GetChallenge_Not_Deleted(SessionSettings settings, Question question)
        {
            settings.QuizCount = Int32.MaxValue;
            question.IsDeleted = true;                      //!!!!
            question.Theme.ParentThemeId = settings.ThemeId;
            _context.Challenges.Add(question);
            _context.SaveChanges();
            //
            var result = _repository.GetChallenge(settings);
            //
            Assert.False(result.Any());
        }

        [Theory, AutoMoqData]
        public void GetChallenge_Count_Restriction(SessionSettings settings, Question question)
        {
            settings.QuizCount = 0;
            question.IsDeleted = false;                      
            question.Theme.ParentThemeId = settings.ThemeId;
            _context.Challenges.Add(question);
            _context.SaveChanges();
            //
            var result = _repository.GetChallenge(settings);
            //
            Assert.False(result.Any());
        }

        [Theory, AutoMoqData]
        public void GetChallenge_Wrong_ThemeId(SessionSettings settings, Question question)
        {
            settings.QuizCount = Int32.MaxValue;
            question.IsDeleted = true;                      
            _context.Challenges.Add(question);
            _context.SaveChanges();
            //
            var result = _repository.GetChallenge(settings);
            //
            Assert.False(result.Any());
        }
    }
}
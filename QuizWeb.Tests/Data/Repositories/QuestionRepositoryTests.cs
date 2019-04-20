using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Repositories.Implementation;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Repositories
{
    public class QuestionRepositoryTests
    {
        private readonly DataContext _context;
        private readonly QuestionRepository _repository;

        public QuestionRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase();
            _context = new DataContext(builder.Options);
            _repository = new QuestionRepository(_context);
        }

        [Theory, AutoMoqData]
        public void AddOrUpdate_Add_Question_Success(Question question)
        {
            var result = _repository.AddOrUpdate(question);
            var exist = _context.Challenges.FirstOrDefaultAsync(e => e.Text == question.Text);
            Assert.True(result);
            Assert.NotNull(exist);
        }

        [Theory, AutoMoqData]
        public void AddOrUpdate_Add_Answer_Success(Question question)
        {
            var answer = question.Answers.First();
            var result = _repository.AddOrUpdate(question);
            var exist = _context.Answers.FirstOrDefaultAsync(e => e.Text == answer.Text);
            Assert.True(result);
            Assert.NotNull(exist);
        }

        [Theory, AutoMoqData]
        public void AddOrUpdate_Update_Success(Question question, Question newbie)
        {
            _context.Challenges.Add(question);
            _context.SaveChanges();
            newbie.Id = question.Id;
            var result = _repository.AddOrUpdate(newbie);
            var exist = _context.Challenges.FirstOrDefault(e => e.Text == newbie.Text);
            Assert.True(result);
            Assert.NotNull(exist);
            Assert.True(question.IsDeleted);
        }

        [Theory, AutoMoqData]
        public void GetByTheme_Success(Question question)
        {
            _context.Challenges.Add(question);
            _context.SaveChanges();
            var result = _repository.GetByTheme(question.ThemeId).First();
            Assert.True(result.Text == question.Text);
        }

        [Theory, AutoMoqData]
        public void GetByTheme_SubTheme_Success(Question question, Theme subTheme)
        {
            subTheme.ParentThemeId = question.ThemeId;
            _context.Themes.Add(subTheme);
            _context.Challenges.Add(question);
            _context.SaveChanges();
            var result = _repository.GetByTheme(question.ThemeId).First();
            Assert.True(result.Text == question.Text);
        }

        [Theory, AutoMoqData]
        public void GetByTheme_No_Theme(Question question, int themeId)
        {
            _context.Challenges.Add(question);
            _context.SaveChanges();
            var result = _repository.GetByTheme(themeId);
            Assert.False(result.Any());
        }
    }
}

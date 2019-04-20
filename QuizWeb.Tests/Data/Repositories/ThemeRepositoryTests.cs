using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Repositories.Implementation;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Repositories
{
    public class ThemeRepositoryTests
    {
        public ThemeRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase();
            _context = new DataContext(builder.Options);
            _repository = new ThemeRepository(_context);
        }

        private readonly DataContext _context;
        private readonly ThemeRepository _repository;

        [Fact]
        public async Task GetThemes_Success()
        {
            var themes = FakeFactory.Fixture.Build<Theme>().With(e => e.ParentThemeId, (int?) null).CreateMany()
                .OrderBy(e => e.Name).ToList();
            _context.Themes.AddRange(themes);
            _context.SaveChanges();
            //
            var result = await _repository.GetThemes();
            //
            Assert.True(themes.Select(e => e.ToDto()).SequenceEqual(result));
        }

        [Theory, AutoMoqData]
        public async Task GetThemes_Parent_Should_Be_Null(Theme theme)
        {
            _context.Themes.Add(theme);
            _context.SaveChanges();
            //
            var result = await _repository.GetThemes();
            //
            Assert.Null(result.FirstOrDefault(e => e.Name == theme.Name));
        }

        [Theory, AutoMoqData]
        public async Task GetAllThemes_Success(Theme theme)
        {
            _context.Themes.Add(theme);
            _context.SaveChanges();
            //
            var result = await _repository.GetAllThemes();
            var returned = result.First(e => e.Name == theme.Name);
            //
            Assert.True(theme.ToDto().Equals(returned));
        }

        [Theory, AutoMoqData]
        public async Task GetAllThemes_Ordered(Theme theme, Theme otherTheme)
        {
            theme.Name = "X";
            otherTheme.Name = "D";
            _context.Themes.Add(theme);
            _context.Themes.Add(otherTheme);
            _context.SaveChanges();
            //
            var result = await _repository.GetAllThemes();
            //
            Assert.True(result.First().Name == otherTheme.Name);
        }
    }
}
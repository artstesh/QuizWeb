using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Repositories.Implementation;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Repositories
{
    public class LevelRepositoryTests
    {
        private readonly DataContext _context;
        private readonly LevelRepository _repository;

        public LevelRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase();
            _context = new DataContext(builder.Options);
            _repository = new LevelRepository(_context);
        }

        [Theory]
        [AutoMoqData]
        public void Log_Success(Level level)
        {
            _context.Levels.Add(level);
            _context.SaveChanges();
            //
            var result = _repository.GetLevels();
            var expected = result.First(e => e.Name == level.Name);
            Assert.True(expected.Equals(level.ToDto()));
        }

    }
}
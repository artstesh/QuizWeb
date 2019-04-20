using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Repositories.Implementation;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Repositories
{
    public class ExamVersionRepositoryTests
    {
        private readonly DataContext _context;
        private ExamVersionRepository _repository;

        public ExamVersionRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase();
            _context = new DataContext(builder.Options);
            _repository = new ExamVersionRepository(_context);
        }

        [Theory]
        [AutoMoqData]
        public async Task Get_Success(ExamVersion version)
        {
            _context.ExamVersions.Add(version);
            _context.SaveChanges();
            //
            var result = await _repository.Get();
            //
            Assert.True(result == version.Version);
        }

        [Theory]
        [AutoMoqData]
        public async Task Get_Exception(Exception exception)
        {
            var result = await _repository.Get();
            Assert.NotNull(result);
        }

        [Theory]
        [AutoMoqData]
        public async Task Set_Success(ExamVersion version, string newVersion)
        {
            _context.ExamVersions.Add(version);
            _context.SaveChanges();
            //
            var result = await _repository.Set(newVersion);
            //
            Assert.True(result);
            Assert.True(version.Version == newVersion);
        }

        [Theory]
        [AutoMoqData]
        public async Task Set_Exception(ExamVersion version, string newVersion)
        {
            _repository = new ExamVersionRepository(null);
            var result = await _repository.Set(newVersion);
            //
            Assert.False(result);
        }
    }
}
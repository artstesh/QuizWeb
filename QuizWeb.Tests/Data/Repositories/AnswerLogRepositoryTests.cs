using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Repositories.Implementation;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Repositories
{
    public class AnswerLogRepositoryTests
    {
        private readonly DataContext _context;
        private readonly AnswerLogRepository _repository;

        public AnswerLogRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase();
            _context = new DataContext(builder.Options);
            _repository = new AnswerLogRepository(_context);
        }

        [Theory]
        [AutoMoqData]
        public async Task Log_Success(AnswerLog log)
        {
            var result = await _repository.Log(log);
            Assert.True(result);
            var added = _context.AnswerLogs.FirstOrDefault(e => e.SessionId.Equals(log.SessionId));
            Assert.True(added != null);
        }

        [Theory]
        [AutoMoqData]
        public async Task GetBySession_Success(AnswerLog log)
        {
            _context.AnswerLogs.Add(log);
            await _context.SaveChangesAsync();
            //
            var result = await _repository.GetBySession(log.SessionId);
            var returned = result.First(e => e.SessionId == log.SessionId);
            //
            Assert.Equal(returned, log.ToDto());
        }

        [Theory]
        [AutoMoqData]
        public async Task GetBySession_Not_Fount(string sessionId)
        {
            var result = await _repository.GetBySession(sessionId);
            //
            Assert.Empty(result);
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Repositories.Implementation;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Repositories
{
    public class UserSessionRepositoryTests
    {
        private readonly DataContext _context;
        private readonly UserSessionRepository _repository;

        public UserSessionRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase();
            _context = new DataContext(builder.Options);
            _repository = new UserSessionRepository(_context);
        }

        [Theory]
        [AutoMoqData]
        public async Task Add_Success(UserSession session)
        {
            var result = await _repository.Add(session);
            _context.SaveChanges();
            Assert.True(result);
            var added = _context.UserSessions.FirstOrDefault(e => e.Guid.Equals(session.Guid));
            Assert.True(added != null);
        }

        [Theory]
        [AutoMoqData]
        public async Task GetLastSession_Success(UserSession session)
        {
            _context.UserSessions.Add(session);
            _context.SaveChanges();
            //
            var result = await _repository.GetLastSession(session.Login);
            //
            Assert.True(result.Equals(session.Guid));
        }

        [Theory]
        [AutoMoqData]
        public async Task GetLastSession_No_Such_Login(string login)
        {
            var result = await _repository.GetLastSession(login);
            //
            Assert.True(string.IsNullOrEmpty(result));
        }

        [Theory]
        [AutoMoqData]
        public async Task GetLastSession_Success_OrderBy(UserSession session1, UserSession session2)
        {
            session2.Login = session1.Login;
            session1.Created = DateTime.MinValue;
            _context.UserSessions.Add(session1);
            _context.UserSessions.Add(session2);
            _context.SaveChanges();
            //
            var result = await _repository.GetLastSession(session1.Login);
            //
            Assert.True(result.Equals(session2.Guid));
        }
    }
}
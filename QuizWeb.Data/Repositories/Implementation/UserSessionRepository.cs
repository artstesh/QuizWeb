using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;

namespace QuizWeb.Data.Repositories.Implementation
{
    public class UserSessionRepository : IUserSessionRepository
    {
        private readonly DataContext _context;

        public UserSessionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(UserSession session)
        {
            {
                _context.UserSessions.Add(session);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<string> GetLastSession(string login)
        {
            {
                var sessions = await _context.UserSessions.Where(e => e.Login.Equals(login)).ToListAsync();
                return sessions.OrderBy(e => e.Created).LastOrDefault()?.Guid ?? "";
            }
        }
    }
}
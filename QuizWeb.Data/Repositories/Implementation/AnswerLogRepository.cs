using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories.Implementation
{
    public class AnswerLogRepository : IAnswerLogRepository
    {
        private readonly DataContext _context;

        public AnswerLogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Log(AnswerLog log)
        {
            _context.AnswerLogs.Add(log);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<AnswerLogModel>> GetBySession(string sessionId)
        {
            var result = await _context.AnswerLogs.Where(e => e.SessionId.Equals(sessionId)).ToListAsync();
            return result.Select(e => e.ToDto()).ToList();
        }
    }
}
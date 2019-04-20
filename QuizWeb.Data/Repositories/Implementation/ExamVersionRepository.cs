using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.DbContext;

namespace QuizWeb.Data.Repositories.Implementation
{
    public class ExamVersionRepository : IExamVersionRepository
    {
        private readonly DataContext _context;

        public ExamVersionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Set(string version)
        {
            try
            {
                var examVersions = _context.ExamVersions.ToList();
                examVersions.ForEach(e => e.Version = version);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<string> Get()
        {
            try
            {
                {
                    return (await _context.ExamVersions.FirstAsync()).Version;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
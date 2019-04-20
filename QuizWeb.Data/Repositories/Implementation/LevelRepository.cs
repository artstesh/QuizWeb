using System.Collections.Generic;
using System.Linq;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories.Implementation
{
    public class LevelRepository : ILevelRepository
    {
        private readonly DataContext _context;

        public LevelRepository(DataContext context)
        {
            _context = context;
        }

        public List<LevelModel> GetLevels()
        {
            return _context.Levels.Select(e => e.ToDto()).ToList();
        }
    }
}
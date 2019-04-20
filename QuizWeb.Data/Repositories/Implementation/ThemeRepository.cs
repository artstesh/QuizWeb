using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories.Implementation
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly DataContext _context;

        public ThemeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ThemeModel>> GetThemes()
        {
            var themes = _context.Themes
                .Where(e => e.ParentThemeId == null).ToList()
                .OrderBy(e => e.Name)
                .ToList();

            return themes.Select(e => e.ToDto()).ToList();
        }

        public async Task<List<ThemeModel>> GetAllThemes()
        {
            var themes = _context.Themes.ToList()
                .OrderBy(e => e.Name)
                .ToList();

            return themes.Select(e => e.ToDto()).ToList();
        }
    }
}
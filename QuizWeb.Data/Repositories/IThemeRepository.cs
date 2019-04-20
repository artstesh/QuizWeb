using System.Collections.Generic;
using System.Threading.Tasks;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories
{
    public interface IThemeRepository
    {
        Task<List<ThemeModel>> GetThemes();
        Task<List<ThemeModel>> GetAllThemes();
    }
}
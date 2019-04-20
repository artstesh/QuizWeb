using System.Collections.Generic;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories
{
    public interface ILevelRepository
    {
        List<LevelModel> GetLevels();
    }
}
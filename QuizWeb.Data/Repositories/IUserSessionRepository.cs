using System.Threading.Tasks;
using QuizWeb.Data.Entities;

namespace QuizWeb.Data.Repositories
{
    public interface IUserSessionRepository
    {
        Task<bool> Add(UserSession session);
        Task<string> GetLastSession(string login);
    }
}
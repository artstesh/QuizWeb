using System.Threading.Tasks;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Services
{
    public interface IStudentResultService
    {
        Task<UserResult> GetResults(string login);
    }
}
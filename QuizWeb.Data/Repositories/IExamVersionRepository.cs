using System.Threading.Tasks;

namespace QuizWeb.Data.Repositories
{
    public interface IExamVersionRepository
    {
        Task<bool> Set(string version);
        Task<string> Get();
    }
}
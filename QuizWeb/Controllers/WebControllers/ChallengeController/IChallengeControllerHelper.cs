using System.Threading.Tasks;
using QuizWeb.Models;

namespace Artstesh.Controllers
{
    public interface IChallengeControllerHelper
    {
        Task<ChallengeIndexViewModel> GetIndexModel(int id);
        Task<QuestionViewModel> GetCreationModel();
        Task<QuestionViewModel> GetForEdidtion(int id);
        bool Save(QuestionViewModel model);
    }
}
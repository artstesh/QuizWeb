using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWeb.Data.Services;

namespace QuizWeb.Controllers.WebControllers
{
    [Authorize]
    public class StudentResultController : Controller
    {
        private readonly IStudentResultService _resultService;

        public StudentResultController(IStudentResultService resultService)
        {
            _resultService = resultService;
        }

        // GET: StudentResult/Details/5
        public async Task<ActionResult> Details(string login)
        {
            var result = await _resultService.GetResults(login);
            return View(result);
        }
    }
}

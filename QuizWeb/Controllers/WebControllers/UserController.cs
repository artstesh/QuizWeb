using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWeb.Data.Models;
using QuizWeb.Data.Repositories;

namespace QuizWeb.Controllers.WebControllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await _repository.Get());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var user = await _repository.Get(id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View(new UserModel());
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create(UserModel model)
        {
            try
            {
                await _repository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await _repository.Get(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, UserModel model)
        {
            try
            {
                await _repository.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWeb.Converters;
using QuizWeb.Data.Models;
using QuizWeb.Data.Repositories;
using QuizWeb.Models;

namespace QuizWeb.Controllers.WebControllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IThemeRepository _themeRepository;

        public StudentController(IStudentRepository studentRepository, IThemeRepository themeRepository)
        {
            _studentRepository = studentRepository;
            _themeRepository = themeRepository;
        }

        // GET: Student
        public async Task<ActionResult> Index()
        {
            var students = await _studentRepository.Get();
            return View(students);
        }

        // GET: Student/Create
        public async Task<ActionResult> Create()
        {
            var themes = await _themeRepository.GetThemes();
            var model = new StudentModel{ExamTime = DateTime.Now};
            var viewModel = model.ToView(themes);
            return View((object) viewModel);
        }

        // POST: Student/Create
        [HttpPost]
        public async Task<ActionResult> Create(StudentEditionViewModel model)
        {
            try
            {
             await   _studentRepository.Add(model.ToModel());

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var themes = await _themeRepository.GetThemes();
            var model = await _studentRepository.Get(id);
            var viewModel = model.ToView(themes);
            return View(viewModel);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, StudentEditionViewModel model)
        {
            try
            {
            await    _studentRepository.Update(model.ToModel());

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}

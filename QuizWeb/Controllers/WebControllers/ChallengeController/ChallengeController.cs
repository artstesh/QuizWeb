using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWeb.Converters;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Models;
using QuizWeb.Data.Repositories;
using QuizWeb.Models;

namespace Artstesh.Controllers
{
    [Authorize]
    public class ChallengeController : Controller
    {
        private IChallengeControllerHelper _helper;

        public ChallengeController(IChallengeControllerHelper helper)
        {
            _helper = helper;
        }

        // GET: Challenge
        public async Task<ActionResult> Index(int id = -1)
        {
            var model = await _helper.GetIndexModel(id);
            return View(model);
        }

        // GET: Challenge/Create
        public async Task<ActionResult> Create()
        {
                var model = await _helper.GetCreationModel();
                return View(model);
        }

        // POST: Challenge/Create
        [HttpPost]
        public ActionResult Create(QuestionViewModel model)
        {
            try
            {
                var saved = _helper.Save(model);
                if (saved)
                    return RedirectToAction("Index", new {id = model.ThemeId});
                return View(model);
            }
            catch(Exception e)
            {
                return View(model);
            }
        }

        // GET: Challenge/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _helper.GetForEdidtion(id);
            return View(model);
        }

        // POST: Challenge/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QuestionViewModel model)
        {
            try
            {
                var saved = _helper.Save(model);
                if (saved)
                    return RedirectToAction("Index", new {id = model.ThemeId});
                return View(model);
            }
            catch(Exception e)
            {
                return View(model);
            }
        }
    }
}

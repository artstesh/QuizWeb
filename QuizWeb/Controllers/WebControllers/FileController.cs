using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWeb.Data.Services;
using QuizWeb.Models;

namespace QuizWeb.Controllers.WebControllers
{
    [Authorize]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public FileResult Download()
        {
            var file = _fileService.Get();
            var fileType = "application/zip";
            var fileName = "Exam.zip";
            return File(file, fileType, fileName);
        }

        [HttpGet] public ActionResult Alskdjfsa()
        {
            return View();
        }
 
        [HttpPost]
        public async Task<ActionResult> Alskdjfsa(UploadFileViewModel model)
        {
            if(model!=null && model.FileBase != null && !string.IsNullOrEmpty(model.Version))
            {
                await _fileService.Upload(model.Version, model.FileBase);
            }
            return RedirectToAction("Index", "Wiki");
        }
    }
}
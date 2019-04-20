using Microsoft.AspNetCore.Http;

namespace QuizWeb.Models
{
    public class UploadFileViewModel
    {
        public IFormFile FileBase { get; set; }
        public string Version { get; set; }
    }
}
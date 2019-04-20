using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QuizWeb.Data.Repositories;

namespace QuizWeb.Data.Services
{
    public class FileService : IFileService
    {
        public static string FileName = "exam.zip";
        private readonly IExamVersionRepository _repository;

        public FileService(IExamVersionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Upload(string version, IFormFile file)
        {
            if (file == null || file.Length <= 0) return false;
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FileName);
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    await file.CopyToAsync(stream);
                }

                await _repository.Set(version);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public byte[] Get()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FileName);
            return File.ReadAllBytes(path);
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace QuizWeb.Data.Services
{
    public interface IFileService
    {
        Task<bool> Upload(string version, IFormFile file);
        byte[] Get();
    }
}
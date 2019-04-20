using System.Collections.Generic;
using System.Threading.Tasks;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories
{
    public interface IStudentRepository
    {
        Task<List<StudentModel>> Get();
        Task<StudentModel> Get(string login);
        Task<StudentModel> Get(int id);
        Task<int> Add(StudentModel model);
        Task<bool> Update(StudentModel model);
    }
}
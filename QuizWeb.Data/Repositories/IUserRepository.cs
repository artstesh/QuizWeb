using System.Collections.Generic;
using System.Threading.Tasks;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserModel>> Get();
        Task<UserModel> Get(string login);
        Task<bool> Add(UserModel model);
        Task<bool> Update(UserModel model);
        Task<UserModel> Get(int id);
        Task<UserModel> CheckPassword(string login, string password);
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Helpers;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> Get()
        {
            {
                var result = (await _context.Users.ToListAsync()).Select(e => e.ToDto()).ToList();
                return result;
            }
        }

        public async Task<UserModel> Get(string login)
        {
            {
                var result = await _context.Users.FirstOrDefaultAsync(e => e.Login == login);
                return result.ToDto();
            }
        }

        public async Task<UserModel> CheckPassword(string login, string password)
        {
            {
                var pass = PasswordHashHelper.HashPassword(password);
                var result = await _context.Users.FirstOrDefaultAsync(e => e.Login == login &&
                                                                           e.Password == pass);
                return result.ToDto();
            }
        }

        public async Task<UserModel> Get(int id)
        {
            {
                var result = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
                return result.ToDto();
            }
        }

        public async Task<bool> Add(UserModel model)
        {
            {
                model.Password = PasswordHashHelper.HashPassword(model.Password);
                _context.Users.Add(model.FromDto());
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> Update(UserModel model)
        {
            {
                var result = await _context.Users.FirstOrDefaultAsync(e => e.Id == model.Id);
                if (result == null) return false;
                result.IsActive = model.IsActive;
                result.Password = model.Password;
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
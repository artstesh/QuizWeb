using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<StudentModel>> Get()
        {
            try
            {
                {
                    var result = (await _context.Students.ToListAsync()).Select(e => e.ToDto()).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<StudentModel> Get(string login)
        {
            {
                var result = await _context.Students.FirstOrDefaultAsync(e => e.Login == login);
                return result.ToDto();
            }
        }

        public async Task<StudentModel> Get(int id)
        {
            {
                var result = await _context.Students.FirstOrDefaultAsync(e => e.Id == id);
                return result.ToDto();
            }
        }

        public async Task<bool> Add(StudentModel model)
        {
            try
            {
                {
                    _context.Students.Add(model.FromDto());
                    return await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> Update(StudentModel model)
        {
            {
                var result = await _context.Students.FirstOrDefaultAsync(e => e.Id == model.Id);
                if (result == null) return false;
                result.ExamTime = model.ExamTime;
                result.Name = model.Name;
                result.ExamThemeId = model.ExamThemeId;
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
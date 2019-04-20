using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Data.Repositories.Implementation;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Repositories
{
    public class StudentRepositoryTests
    {
        private readonly DataContext _context;
        private readonly StudentRepository _repository;

        public StudentRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase();
            _context = new DataContext(builder.Options);
            _repository = new StudentRepository(_context);
        }

        [Theory]
        [AutoMoqData]
        public async Task Get_By_Login_Success(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            //
            var result = await _repository.Get(student.Login);
            //
            Assert.True(result.Equals(student.ToDto()));
        }

        [Theory]
        [AutoMoqData]
        public async Task Get_By_Login_Not_Found(string login)
        {
            var result = await _repository.Get(login);
            //
            Assert.Null(result);
        }

        [Theory, AutoMoqData]
        public async Task Get_By_Id_Success(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            //
            var result = await _repository.Get(student.Id);
            //
            Assert.True(result.Equals(student.ToDto()));
        }
        
        [Theory]
        [AutoMoqData]
        public async Task  Get_By_Id_Not_Found(int id)
        {
            var result = await _repository.Get(id);
            //
            Assert.Null(result);
        }

        [Theory, AutoMoqData]
        public async Task Add_Success(StudentModel model)
        {
            var result = await _repository.Add(model);
            //
            var saved = _context.Students.First(e => e.Name == model.Name);
            Assert.True(saved.ToDto().Equals(model));
            Assert.True(result == saved.Id);
        }

        [Theory, AutoMoqData]
        public async Task Update_Success(Student student, DateTime examTime, string name, int themeId)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            var model = student.ToDto();
            model.Name = name;
            model.ExamTime = examTime;
            model.ExamThemeId = themeId;
            //
            await _repository.Update(model);
            //
            Assert.Equal(student.Name, name);
            Assert.Equal(student.ExamTime, examTime);
            Assert.Equal(student.ExamThemeId, themeId);
        }
    }
}
using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Converters
{
    public class StudentConverterTests
    {
        [Theory]
        [AutoMoqData]
        public void ToDto_Success(Student origin)
        {
            var model = new StudentModel
            {
                Name = origin.Name, Login = origin.Login, ExamTime = origin.ExamTime, Id = origin.Id,
                ExamThemeId = origin.ExamThemeId
            };
            var result = origin.ToDto();
            Assert.True(result.Equals(model));
        }

        [Theory]
        [AutoMoqData]
        public void FromDto_Success(StudentModel origin)
        {
            var model = new Student
            {
                Name = origin.Name, Login = origin.Login, ExamTime = origin.ExamTime, Id = origin.Id,
                ExamThemeId = origin.ExamThemeId
            };
            var result = origin.FromDto();
            Assert.True(result.Equals(model));
        }

        [Fact]
        public void FromDto_Null()
        {
            var result = ((StudentModel) null).FromDto();
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_Null()
        {
            var result = ((Student) null).ToDto();
            Assert.Null(result);
        }
    }
}
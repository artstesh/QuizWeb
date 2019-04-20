using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Converters
{
    public class UserConverterTests
    {
        [Theory]
        [AutoMoqData]
        public void ToDto_Success(User origin)
        {
            var model = new UserModel
            {
                Password = origin.Password, Login = origin.Login, IsActive = origin.IsActive, Id = origin.Id
            };
            var result = origin.ToDto();
            Assert.True(result.Equals(model));
        }

        [Theory]
        [AutoMoqData]
        public void FromDto_Success(UserModel origin)
        {
            var model = new User
            {
                Password = origin.Password, Login = origin.Login, IsActive = origin.IsActive, Id = origin.Id
            };
            var result = origin.FromDto();
            Assert.True(result.Equals(model));
        }

        [Fact]
        public void FromDto_Null()
        {
            var result = ((UserModel) null).FromDto();
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_Null()
        {
            var result = ((User) null).ToDto();
            Assert.Null(result);
        }
    }
}
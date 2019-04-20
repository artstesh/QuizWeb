using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Converters
{
    public class UserSessionConverterTests
    {
        [Theory]
        [AutoMoqData]
        public void ToDto_Success(UserSession origin)
        {
            var model = new UserSessionModel
            {
                Name = origin.Login, Guid = origin.Guid, Created = origin.Created
            };
            var result = origin.ToDto();
            Assert.True(result.Equals(model));
        }

        [Theory]
        [AutoMoqData]
        public void FromDto_Success(UserSessionModel origin)
        {
            var model = new UserSession
            {
                Login = origin.Name, Guid = origin.Guid, Created = origin.Created
            };
            var result = origin.FromDto();
            Assert.True(result.Equals(model));
        }

        [Fact]
        public void FromDto_Null()
        {
            var result = ((UserSessionModel) null).FromDto();
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_Null()
        {
            var result = ((UserSession) null).ToDto();
            Assert.Null(result);
        }
    }
}
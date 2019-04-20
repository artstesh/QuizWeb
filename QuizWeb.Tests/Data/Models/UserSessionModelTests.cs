using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Models
{
    public class UserSessionModelTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(UserSessionModel origin)
        {
            var model = new UserSessionModel
            {
                Name = origin.Name, Guid = origin.Guid, Created = origin.Created
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Guid(UserSessionModel origin, string Guid)
        {
            var model = new UserSessionModel
            {
                Name = origin.Name, Guid = Guid, Created = origin.Created
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(UserSessionModel origin, string Name)
        {
            var model = new UserSessionModel
            {
                Name = Name, Guid = origin.Guid, Created = origin.Created
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(UserSessionModel origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(UserSessionModel origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(UserSessionModel origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
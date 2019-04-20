using QuizWeb.Data.Entities;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Entities
{
    public class UserSessionTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(UserSession origin)
        {
            var model = new UserSession
            {
                Login = origin.Login, Guid = origin.Guid, Created = origin.Created
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Guid(UserSession origin, string Guid)
        {
            var model = new UserSession
            {
                Login = origin.Login, Guid = Guid, Created = origin.Created
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(UserSession origin, string Name)
        {
            var model = new UserSession
            {
                Login = Name, Guid = origin.Guid, Created = origin.Created
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(UserSession origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(UserSession origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(UserSession origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
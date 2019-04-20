using QuizWeb.Data.Entities;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Entities
{
    public class UserTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(User origin)
        {
            var model = new User
            {
                Password = origin.Password, Login = origin.Login, IsActive = origin.IsActive
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(User origin, string Name)
        {
            var model = new User
            {
                Password = Name, Login = origin.Login, IsActive = origin.IsActive
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Login(User origin, string Login)
        {
            var model = new User
            {
                Password = origin.Password, Login = Login, IsActive = origin.IsActive
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ActiveSessionTill(User origin)
        {
            var model = new User
            {
                Password = origin.Password, Login = origin.Login, IsActive = !origin.IsActive
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(User origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(User origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(User origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
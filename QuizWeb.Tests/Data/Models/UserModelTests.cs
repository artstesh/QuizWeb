using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Models
{
    public class UserModelTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(UserModel origin)
        {
            var model = new UserModel
            {
                Password = origin.Password, Login = origin.Login, IsActive = origin.IsActive, Id = origin.Id
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(UserModel origin, string Name)
        {
            var model = new UserModel
            {
                Password = Name, Login = origin.Login, IsActive = origin.IsActive, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Id(UserModel origin, int Id)
        {
            var model = new UserModel
            {
                Password = origin.Password, Login = origin.Login, IsActive = origin.IsActive, Id = Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Login(UserModel origin, string Login)
        {
            var model = new UserModel
            {
                Password = origin.Password, Login = Login, IsActive = origin.IsActive, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ActiveSessionTill(UserModel origin, bool isActive)
        {
            var model = new UserModel
            {
                Password = origin.Password, Login = origin.Login, IsActive = isActive, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(UserModel origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(UserModel origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(UserModel origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Models
{
    public class SessionSettingsTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(SessionSettings origin)
        {
            var model = new SessionSettings
            {
                Guid = origin.Guid, Login = origin.Login, QuizCount = origin.QuizCount, ThemeId = origin.ThemeId
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Guid(SessionSettings origin, string Guid)
        {
            var model = new SessionSettings
            {
                Guid = Guid, Login = origin.Login, QuizCount = origin.QuizCount, ThemeId = origin.ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_UserName(SessionSettings origin, string UserName)
        {
            var model = new SessionSettings
            {
                Guid = origin.Guid, Login = UserName, QuizCount = origin.QuizCount, ThemeId = origin.ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_QuizCount(SessionSettings origin, int QuizCount)
        {
            var model = new SessionSettings
            {
                Guid = origin.Guid, Login = origin.Login, QuizCount = QuizCount, ThemeId = origin.ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ThemeId(SessionSettings origin, int ThemeId)
        {
            var model = new SessionSettings
            {
                Guid = origin.Guid, Login = origin.Login, QuizCount = origin.QuizCount, ThemeId = ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(SessionSettings origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(SessionSettings origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(SessionSettings origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
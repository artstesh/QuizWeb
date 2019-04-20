using QuizWeb.Data.Entities;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Entities
{
    public class AnswerLogTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(AnswerLog origin)
        {
            var model = new AnswerLog
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct,
                ThemeId = origin.ThemeId
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_SessionId(AnswerLog origin, string SessionId)
        {
            var model = new AnswerLog
            {
                SessionId = SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct, ThemeId = origin.ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_AnswerId(AnswerLog origin, int AnswerId)
        {
            var model = new AnswerLog
            {
                SessionId = origin.SessionId, AnswerId = AnswerId, Correct = origin.Correct, ThemeId = origin.ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Correct(AnswerLog origin)
        {
            var model = new AnswerLog
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = !origin.Correct,
                ThemeId = origin.ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ThemeId(AnswerLog origin, int ThemeId)
        {
            var model = new AnswerLog
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct, ThemeId = ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(AnswerLog origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(AnswerLog origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(AnswerLog origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
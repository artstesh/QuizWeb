using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Models
{
    public class AnswerLogModelModelTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(AnswerLogModel origin)
        {
            var model = new AnswerLogModel
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct,
                ThemeId = origin.ThemeId, Id = origin.Id
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_SessionId(AnswerLogModel origin, string SessionId)
        {
            var model = new AnswerLogModel
            {
                SessionId = SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct, ThemeId = origin.ThemeId,
                Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_AnswerId(AnswerLogModel origin, int AnswerId)
        {
            var model = new AnswerLogModel
            {
                SessionId = origin.SessionId, AnswerId = AnswerId, Correct = origin.Correct, ThemeId = origin.ThemeId,
                Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Id(AnswerLogModel origin, int Id)
        {
            var model = new AnswerLogModel
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct,
                ThemeId = origin.ThemeId, Id = Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Correct(AnswerLogModel origin, bool Correct)
        {
            var model = new AnswerLogModel
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = Correct, ThemeId = origin.ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ThemeId(AnswerLogModel origin, int ThemeId)
        {
            var model = new AnswerLogModel
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct, ThemeId = ThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(AnswerLogModel origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(AnswerLogModel origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(AnswerLogModel origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
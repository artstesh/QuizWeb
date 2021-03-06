using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Converters
{
    public class AnswerLogConverterTests
    {
        [Theory]
        [AutoMoqData]
        public void ToDto_Success(AnswerLog origin)
        {
            var model = new AnswerLogModel
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct,
                ThemeId = origin.ThemeId, Id = origin.Id
            };
            var result = origin.ToDto();
            Assert.True(result.Equals(model));
        }

        [Theory]
        [AutoMoqData]
        public void FromDto_Success(AnswerLogModel origin)
        {
            var model = new AnswerLog
            {
                SessionId = origin.SessionId, AnswerId = origin.AnswerId, Correct = origin.Correct,
                ThemeId = origin.ThemeId, Id = origin.Id
            };
            var result = origin.FromDto();
            Assert.True(result.Equals(model));
        }

        [Fact]
        public void FromDto_Null()
        {
            var result = ((AnswerLogModel) null).FromDto();
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_Null()
        {
            var result = ((AnswerLog) null).ToDto();
            Assert.Null(result);
        }
    }
}
using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Converters
{
    public class AnswerConverterTests
    {
        [Theory]
        [AutoMoqData]
        public void ToDto_Success(Answer origin)
        {
            var model = new AnswerModel
            {
                Text = origin.Text, Id = origin.Id, IsCorrect = origin.IsCorrect, QuestionId = origin.QuestionId
            };
            var result = origin.ToDto();
            Assert.True(result.Equals(model));
        }

        [Theory]
        [AutoMoqData]
        public void FromDto_Success(AnswerModel origin)
        {
            var model = new Answer
            {
                Text = origin.Text, Id = origin.Id, IsCorrect = origin.IsCorrect, QuestionId = origin.QuestionId
            };
            var result = origin.FromDto();
            Assert.True(result.Equals(model));
        }

        [Fact]
        public void FromDto_Null()
        {
            var result = ((AnswerModel) null).FromDto();
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_Null()
        {
            var result = ((Answer) null).ToDto();
            Assert.Null(result);
        }
    }
}
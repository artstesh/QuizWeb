using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Converters
{
    public class QuestionConverterTests
    {
        [Theory]
        [AutoMoqData]
        public void ToDto_Success(Question origin)
        {
            var model = new QuestionModel
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, Id = origin.Id
            };
            var result = origin.ToDto();
            Assert.True(result.Equals(model));
        }

        [Theory]
        [AutoMoqData]
        public void FromDto_Success(QuestionModel origin)
        {
            var model = new Question
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, Id = origin.Id
            };
            var result = origin.FromDto();
            Assert.True(result.Equals(model));
        }

        [Fact]
        public void FromDto_Null()
        {
            var result = ((QuestionModel) null).FromDto();
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_Null()
        {
            var result = ((Question) null).ToDto();
            Assert.Null(result);
        }
    }
}
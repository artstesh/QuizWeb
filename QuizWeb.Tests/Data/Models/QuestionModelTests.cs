using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Models
{
    public class QuestionModelTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(QuestionModel origin)
        {
            var model = new QuestionModel
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, Id = origin.Id
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Text(QuestionModel origin, string Text)
        {
            var model = new QuestionModel
            {
                Text = Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_LevelId(QuestionModel origin, int LevelId)
        {
            var model = new QuestionModel
            {
                Text = origin.Text, LevelId = LevelId, ThemeId = origin.ThemeId, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ThemeId(QuestionModel origin, int ThemeId)
        {
            var model = new QuestionModel
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = ThemeId, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Id(QuestionModel origin, int Id)
        {
            var model = new QuestionModel
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, Id = Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(QuestionModel origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(QuestionModel origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(QuestionModel origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
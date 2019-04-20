using QuizWeb.Data.Entities;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Entities
{
    public class QuestionTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(Question origin)
        {
            var model = new Question
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, IsDeleted = origin.IsDeleted
            };
            Assert.True(model.Equals(origin));
        }
        
        [Theory]
        [AutoMoqData]
        public void Equals_IsDeleted(Question origin)
        {
            var model = new Question
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, IsDeleted = !origin.IsDeleted
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Text(Question origin, string Text)
        {
            var model = new Question
            {
                Text = Text, LevelId = origin.LevelId, ThemeId = origin.ThemeId, IsDeleted = origin.IsDeleted
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_LevelId(Question origin, int LevelId)
        {
            var model = new Question
            {
                Text = origin.Text, LevelId = LevelId, ThemeId = origin.ThemeId, IsDeleted = origin.IsDeleted
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ThemeId(Question origin, int ThemeId)
        {
            var model = new Question
            {
                Text = origin.Text, LevelId = origin.LevelId, ThemeId = ThemeId, IsDeleted = origin.IsDeleted
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(Question origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(Question origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(Question origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
using QuizWeb.Data.Entities;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Entities
{
    public class AnswerTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(Answer origin)
        {
            var model = new Answer
            {
                Text = origin.Text, IsCorrect = origin.IsCorrect, QuestionId = origin.QuestionId
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_IsCorrect(Answer origin, bool IsCorrect)
        {
            var model = new Answer
            {
                Text = origin.Text, IsCorrect = !origin.IsCorrect, QuestionId = origin.QuestionId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_QuestionId(Answer origin, int QuestionId)
        {
            var model = new Answer
            {
                Text = origin.Text, IsCorrect = origin.IsCorrect, QuestionId = QuestionId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Text(Answer origin, string Text)
        {
            var model = new Answer
            {
                Text = Text, IsCorrect = origin.IsCorrect, QuestionId = origin.QuestionId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(Answer origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(Answer origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(Answer origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
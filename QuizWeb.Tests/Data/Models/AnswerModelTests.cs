using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Models
{
    public class AnswerModelTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(AnswerModel origin)
        {
            var model = new AnswerModel
            {
                Text = origin.Text, IsCorrect = origin.IsCorrect, QuestionId = origin.QuestionId, Id = origin.Id
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_IsCorrect(AnswerModel origin)
        {
            var model = new AnswerModel
            {
                Text = origin.Text, IsCorrect = !origin.IsCorrect, QuestionId = origin.QuestionId, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_QuestionId(AnswerModel origin, int QuestionId)
        {
            var model = new AnswerModel
            {
                Text = origin.Text, IsCorrect = origin.IsCorrect, QuestionId = QuestionId, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Id(AnswerModel origin, int Id)
        {
            var model = new AnswerModel
            {
                Text = origin.Text, IsCorrect = origin.IsCorrect, QuestionId = origin.QuestionId, Id = Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Text(AnswerModel origin, string Text)
        {
            var model = new AnswerModel
            {
                Text = Text, IsCorrect = origin.IsCorrect, QuestionId = origin.QuestionId, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(AnswerModel origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(AnswerModel origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(AnswerModel origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
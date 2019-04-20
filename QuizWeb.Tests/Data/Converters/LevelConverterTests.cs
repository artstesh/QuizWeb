using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Converters
{
    public class LevelConverterTests
    {
        [Theory]
        [AutoMoqData]
        public void ToDto_Success(Level origin)
        {
            var model = new LevelModel
            {
                Name = origin.Name, Id = origin.Id
            };
            var result = origin.ToDto();
            Assert.True(result.Equals(model));
        }

        [Theory]
        [AutoMoqData]
        public void FromDto_Success(LevelModel origin)
        {
            var model = new Level
            {
                Name = origin.Name, Id = origin.Id
            };
            var result = origin.FromDto();
            Assert.True(result.Equals(model));
        }

        [Fact]
        public void FromDto_Null()
        {
            var result = ((LevelModel) null).FromDto();
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_Null()
        {
            var result = ((Level) null).ToDto();
            Assert.Null(result);
        }
    }
}
using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Converters
{
    public class ThemeConverterTests
    {
        [Theory]
        [AutoMoqData]
        public void ToDto_Success(Theme origin)
        {
            var model = new ThemeModel
            {
                Name = origin.Name, Id = origin.Id, ParentThemeId = origin.ParentThemeId
            };
            var result = origin.ToDto();
            Assert.True(result.Equals(model));
        }

        [Theory]
        [AutoMoqData]
        public void FromDto_Success(ThemeModel origin)
        {
            var model = new Theme
            {
                Name = origin.Name, Id = origin.Id, ParentThemeId = origin.ParentThemeId
            };
            var result = origin.FromDto();
            Assert.True(result.Equals(model));
        }

        [Fact]
        public void FromDto_Null()
        {
            var result = ((ThemeModel) null).FromDto();
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_Null()
        {
            var result = ((Theme) null).ToDto();
            Assert.Null(result);
        }
    }
}
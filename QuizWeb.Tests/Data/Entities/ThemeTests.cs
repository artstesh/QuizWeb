using QuizWeb.Data.Entities;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Entities
{
    public class ThemeTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(Theme origin)
        {
            var model = new Theme
            {
                Name = origin.Name, ParentTheme = origin.ParentTheme, Id = origin.Id,
                ParentThemeId = origin.ParentThemeId
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(Theme origin, string name)
        {
            var model = new Theme
            {
                Name = name, ParentTheme = origin.ParentTheme, Id = origin.Id, ParentThemeId = origin.ParentThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ParentTheme(Theme origin, Theme parentTheme)
        {
            var model = new Theme
            {
                Name = origin.Name, ParentTheme = parentTheme, Id = origin.Id, ParentThemeId = origin.ParentThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ParentThemeId(Theme origin, int parentThemeId)
        {
            var model = new Theme
            {
                Name = origin.Name, ParentTheme = origin.ParentTheme, Id = origin.Id, ParentThemeId = parentThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(Theme origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(Theme origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(Theme origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
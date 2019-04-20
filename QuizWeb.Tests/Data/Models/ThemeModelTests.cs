using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Models
{
    public class ThemeModelTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(ThemeModel origin)
        {
            var model = new ThemeModel
            {
                Name = origin.Name, Id = origin.Id, ParentThemeId = origin.ParentThemeId
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(ThemeModel origin, string name)
        {
            var model = new ThemeModel
            {
                Name = name, Id = origin.Id, ParentThemeId = origin.ParentThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Id(ThemeModel origin, int Id)
        {
            var model = new ThemeModel
            {
                Name = origin.Name, Id = Id, ParentThemeId = origin.ParentThemeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ParentThemeModelId(ThemeModel origin, int parentThemeModelId)
        {
            var model = new ThemeModel
            {
                Name = origin.Name, Id = origin.Id, ParentThemeId = parentThemeModelId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(ThemeModel origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(ThemeModel origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(ThemeModel origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
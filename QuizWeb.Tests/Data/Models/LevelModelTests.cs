using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Models
{
    public class LevelModelTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(LevelModel origin)
        {
            var model = new LevelModel
            {
                Name = origin.Name, Id = origin.Id
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(LevelModel origin, string name)
        {
            var model = new LevelModel
            {
                Name = name, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Id(LevelModel origin, int Id)
        {
            var model = new LevelModel
            {
                Name = origin.Name, Id = Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(LevelModel origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(LevelModel origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(LevelModel origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
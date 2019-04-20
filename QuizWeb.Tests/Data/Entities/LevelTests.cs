using QuizWeb.Data.Entities;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Entities
{
    public class LevelTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(Level origin)
        {
            var model = new Level
            {
                Name = origin.Name, Id = origin.Id
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(Level origin, string name)
        {
            var model = new Level
            {
                Name = name, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(Level origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(Level origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(Level origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
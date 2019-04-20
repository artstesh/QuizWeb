using AutoFixture.Xunit2;

namespace QuizWeb.Tests.FakeFactories
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(FakeFactory.Fixture)
        {
        }
    }
}
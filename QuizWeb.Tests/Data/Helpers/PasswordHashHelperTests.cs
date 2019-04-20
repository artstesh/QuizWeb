using QuizWeb.Data.Helpers;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Helpers
{
    public class PasswordHashHelperTests
    {
        [Theory]
        [AutoMoqData]
        public void HashPassword_Verify_True(string text)
        {
            var hashed = PasswordHashHelper.HashPassword(text);
            var hashed2 = PasswordHashHelper.HashPassword(text);
            Assert.True(hashed == hashed2);
        }

        [Theory]
        [AutoMoqData]
        public void HashPassword_Verify_False(string text, string text2)
        {
            var hashed = PasswordHashHelper.HashPassword(text);
            var hashed2 = PasswordHashHelper.HashPassword(text2);
            Assert.False(hashed == hashed2);
        }
    }
}
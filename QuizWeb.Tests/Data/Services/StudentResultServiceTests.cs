using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using QuizWeb.Data.Models;
using QuizWeb.Data.Repositories;
using QuizWeb.Data.Services;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Services
{
    public class StudentResultServiceTests
    {
        private readonly Mock<IAnswerLogRepository> _answerLogRepository;
        private readonly StudentResultService _service;
        private readonly Mock<IThemeRepository> _themeRepository;
        private readonly Mock<IUserSessionRepository> _userSessionRepository;

        public StudentResultServiceTests()
        {
            _answerLogRepository = new Mock<IAnswerLogRepository>(MockBehavior.Strict);
            _themeRepository = new Mock<IThemeRepository>(MockBehavior.Strict);
            _userSessionRepository = new Mock<IUserSessionRepository>(MockBehavior.Strict);
            _service = new StudentResultService(_answerLogRepository.Object, _themeRepository.Object,
                _userSessionRepository.Object);
        }

        [Theory]
        [AutoMoqData]
        public async Task GetResults_Success(string login, string sessionId, AnswerLogModel log, ThemeModel theme,
            ThemeModel parentTheme)
        {
            log.ThemeId = theme.Id;
            theme.ParentThemeId = parentTheme.Id;
            _userSessionRepository.Setup(e => e.GetLastSession(login)).ReturnsAsync(sessionId);
            _answerLogRepository.Setup(e => e.GetBySession(sessionId)).ReturnsAsync(new List<AnswerLogModel> {log});
            _themeRepository.Setup(e => e.GetThemes()).ReturnsAsync(new List<ThemeModel> {theme, parentTheme});
            _themeRepository.Setup(e => e.GetAllThemes()).ReturnsAsync(new List<ThemeModel> {theme, parentTheme});
            var expectedCorrect = log.Correct ? 1 : 0;
            //
            var result = await _service.GetResults(login);
            //
            Assert.True(result.ThemeName == parentTheme.Name);
            Assert.True(result.TotalAnswers == 1);
            Assert.True(result.CorrectAnswers == expectedCorrect);
            Assert.True(result.SubThemesResult.First().ThemeName == theme.Name);
            Assert.True(result.SubThemesResult.First().TotalAnswers == 1);
            Assert.True(result.SubThemesResult.First().CorrectAnswers == expectedCorrect);
        }
    }
}
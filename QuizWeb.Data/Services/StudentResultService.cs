using System.Linq;
using System.Threading.Tasks;
using QuizWeb.Data.Models;
using QuizWeb.Data.Repositories;

namespace QuizWeb.Data.Services
{
    public class StudentResultService : IStudentResultService
    {
        private readonly IAnswerLogRepository _repository;
        private readonly IThemeRepository _themeRepository;
        private readonly IUserSessionRepository _userSessionRepository;

        public StudentResultService(IAnswerLogRepository repository, IThemeRepository themeRepository,
            IUserSessionRepository userSessionRepository)
        {
            _repository = repository;
            _themeRepository = themeRepository;
            _userSessionRepository = userSessionRepository;
        }

        public async Task<UserResult> GetResults(string login)
        {
            var sessionId = await _userSessionRepository.GetLastSession(login);
            var logs = await _repository.GetBySession(sessionId);
            if (!logs.Any()) return new UserResult();
            var themeIds = logs.Select(e => e.ThemeId).Distinct().ToList();
            var allThemes = await _themeRepository.GetAllThemes();
            var themes = allThemes.Where(e => themeIds.Contains(e.Id)).ToList();
            var resultDic = logs.GroupBy(e => e.ThemeId).ToDictionary(x => x.Key, x => x.ToList());
            var result = new UserResult
            {
                ThemeName = allThemes.First(e => e.Id == themes.First().ParentThemeId).Name,
                CorrectAnswers = logs.Count(e => e.Correct), TotalAnswers = logs.Count, Name = login
            };
            foreach (var themeBlock in resultDic)
            {
                var temp = new UserResult
                {
                    ThemeName = themes.First(e => e.Id == themeBlock.Key).Name,
                    CorrectAnswers = themeBlock.Value.Count(e => e.Correct),
                    TotalAnswers = themeBlock.Value.Count
                };
                result.SubThemesResult.Add(temp);
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Attributes;
using QuizWeb.Config;
using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;
using QuizWeb.Data.Repositories;
using QuizWeb.Data.Services;
using QuizWeb.Models;

namespace QuizWeb.Controllers.ApiControllers
{
    [BasicAuthorize]
    public class QuizAppController : ControllerBase
    {
        private readonly IAnswerLogRepository _answerLogRepository;
        private readonly IChallengeRepository _challengeRepository;
        private readonly IThemeRepository _themeRepository;
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentResultService _resultService;
        private readonly IExamVersionRepository _examVersionRepository;

        public QuizAppController(IChallengeRepository challengeRepository, IThemeRepository themeRepository,
            IUserSessionRepository userSessionRepository, IAnswerLogRepository answerLogRepository, IStudentRepository studentRepository, IStudentResultService resultService, IExamVersionRepository examVersionRepository)
        {
            _challengeRepository = challengeRepository;
            _themeRepository = themeRepository;
            _userSessionRepository = userSessionRepository;
            _answerLogRepository = answerLogRepository;
            _studentRepository = studentRepository;
            _resultService = resultService;
            _examVersionRepository = examVersionRepository;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> GetSession([Microsoft.AspNetCore.Mvc.FromBody] SessionSettings settings)
        {
            var student =await _studentRepository.Get(settings.Login);
            if (student == null) return Ok(ErrorDict.NoSuchStudent(settings.Login));
            if (student.ExamTime > DateTime.Now || student.ExamTime.AddMinutes(60) < DateTime.Now)
                return Ok(ErrorDict.NotEnrolled(student.Name));
            settings.ThemeId = student.ExamThemeId;
            _userSessionRepository.Add(new UserSession {Guid = settings.Guid, Login = settings.Login});
            var questions = _challengeRepository.GetChallenge(settings);
            return Ok(new SuccessResult<List<QuestionModel>>(questions));
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> CheckStudent(string name)
        {
            var student =await _studentRepository.Get(name);
            if (student == null) return Ok(ErrorDict.NoSuchStudent(name));
            if (student.ExamTime > DateTime.Now || student.ExamTime.AddMinutes(60) < DateTime.Now)
                return Ok(ErrorDict.NotEnrolled(student.Name));
            return Ok(new SuccessResult<bool>(true));
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> CheckVersion(string version)
        {
            var result = await _examVersionRepository.Get();
            return Ok(result == version);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> GetResult(string login)
        {
            var result = await _resultService.GetResults(login);
            return Ok(new SuccessResult<UserResult>(result));
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> GetThemes()
        {
            var themes = await _themeRepository.GetThemes();

            return Ok(new SuccessResult<List<ThemeModel>>(themes));
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public void SaveLog([Microsoft.AspNetCore.Mvc.FromBody] AnswerLogModel log)
        {
            _answerLogRepository.Log(log.FromDto());
        }
    }
}
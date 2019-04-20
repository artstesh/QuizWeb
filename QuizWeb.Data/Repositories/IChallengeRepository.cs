using System.Collections.Generic;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories
{
    public interface IChallengeRepository
    {
        List<QuestionModel> GetChallenge(SessionSettings settings);
    }
}
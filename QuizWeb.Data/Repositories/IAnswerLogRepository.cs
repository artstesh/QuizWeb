using System.Collections.Generic;
using System.Threading.Tasks;
using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Repositories
{
    public interface IAnswerLogRepository
    {
        Task<bool> Log(AnswerLog log);
        Task<List<AnswerLogModel>> GetBySession(string sessionId);
    }
}
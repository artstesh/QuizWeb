using System.Collections.Generic;

namespace QuizWeb.Models
{
    public class QuizViewModel
    {
        public int CurrentQuiz { get; set; }
        public List<SessionAnswerViewModel> Quizes { get; set; }
    }
}
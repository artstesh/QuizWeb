namespace QuizWeb.Models
{
    public class SessionAnswerViewModel
    {
        public int Id { get; set; }
        public string SessionKey { get; set; }

        public string ThemeName { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public int Answer1Id { get; set; }
        public int Answer2Id { get; set; }
        public int Answer3Id { get; set; }
        public int Answer4Id { get; set; }
        public int Answer5Id { get; set; }
        public int Answer6Id { get; set; }

        public string Answer1Text { get; set; }
        public string Answer2Text { get; set; }
        public string Answer3Text { get; set; }
        public string Answer4Text { get; set; }
        public string Answer5Text { get; set; }
        public string Answer6Text { get; set; }

        public int UserAnswerId { get; set; }
    }
}
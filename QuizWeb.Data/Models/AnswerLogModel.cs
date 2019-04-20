namespace QuizWeb.Data.Models
{
    public class AnswerLogModel
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public int AnswerId { get; set; }
        public bool Correct { get; set; }
        public int ThemeId { get; set; }

        public bool Equals(AnswerLogModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(SessionId, other.SessionId) && AnswerId == other.AnswerId &&
                   Correct == other.Correct && ThemeId == other.ThemeId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AnswerLogModel) obj);
        }
    }
}
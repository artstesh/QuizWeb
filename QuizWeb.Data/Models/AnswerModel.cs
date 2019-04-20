using System;

namespace QuizWeb.Data.Models
{
    public class AnswerModel : IEquatable<AnswerModel>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public virtual QuestionModel Question { get; set; }

        public bool Equals(AnswerModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Text, other.Text) && IsCorrect == other.IsCorrect &&
                   QuestionId == other.QuestionId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AnswerModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Text != null ? Text.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsCorrect.GetHashCode();
                hashCode = (hashCode * 397) ^ QuestionId;
                hashCode = (hashCode * 397) ^ (Question != null ? Question.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
using System;

namespace QuizWeb.Data.Models
{
    public class SessionSettings : IEquatable<SessionSettings>
    {
        public string Guid { get; set; }
        public string Login { get; set; }
        public int QuizCount { get; set; }
        public int ThemeId { get; set; }

        public bool Equals(SessionSettings other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Guid, other.Guid) && string.Equals(Login, other.Login) &&
                   QuizCount == other.QuizCount && ThemeId == other.ThemeId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SessionSettings) obj);
        }
    }
}
using System;

namespace QuizWeb.Data.Models
{
    public class UserSessionModel : IEquatable<UserSessionModel>
    {
        public string Name { get; set; }
        public string Guid { get; set; }
        public DateTime Created { get; set; }

        public bool Equals(UserSessionModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Guid, other.Guid) &&
                   Created == other.Created;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((UserSessionModel) obj);
        }
    }
}
using System;

namespace QuizWeb.Data.Models
{
    public class UserModel : IEquatable<UserModel>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public bool Equals(UserModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Login, other.Login) && string.Equals(Password, other.Password) &&
                   IsActive.Equals(other.IsActive);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((UserModel) obj);
        }
    }
}
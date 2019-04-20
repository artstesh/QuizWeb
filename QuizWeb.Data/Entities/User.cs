using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Data.Entities
{
    [Table("user")]
    public class User : BaseEntity, IEquatable<User>
    {
        [Column("Login")] public string Login { get; set; }

        [Column("Password")] public string Password { get; set; }

        [Column("IsActive")] public bool IsActive { get; set; }

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Login, other.Login) && string.Equals(Password, other.Password) &&
                   IsActive.Equals(other.IsActive);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((User) obj);
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Data.Entities
{
    [Table("user_session")]
    public class UserSession : BaseEntity, IEquatable<UserSession>
    {
        [Column("Login")] [MaxLength(100)] public string Login { get; set; }

        [Column("Guid")] public string Guid { get; set; }

        [Column("Created")] public DateTime Created { get; set; }

        public bool Equals(UserSession other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Login, other.Login) && string.Equals(Guid, other.Guid) &&
                   Created == other.Created;
        }
    }
}
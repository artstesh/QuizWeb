using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Converters
{
    public static class UserConverter
    {
        public static UserModel ToDto(this User origin)
        {
            if (origin == null) return null;
            return new UserModel
            {
                Password = origin.Password, Login = origin.Login, IsActive = origin.IsActive, Id = origin.Id
            };
        }

        public static User FromDto(this UserModel origin)
        {
            if (origin == null) return null;
            return new User
            {
                Password = origin.Password, Login = origin.Login, IsActive = origin.IsActive, Id = origin.Id
            };
        }
    }
}
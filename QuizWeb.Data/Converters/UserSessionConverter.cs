using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Converters
{
    public static class UserSessionConverter
    {
        public static UserSessionModel ToDto(this UserSession origin)
        {
            if (origin == null) return null;
            return new UserSessionModel
            {
                Name = origin.Login, Guid = origin.Guid, Created = origin.Created
            };
        }

        public static UserSession FromDto(this UserSessionModel origin)
        {
            if (origin == null) return null;
            return new UserSession
            {
                Login = origin.Name, Guid = origin.Guid, Created = origin.Created
            };
        }
    }
}
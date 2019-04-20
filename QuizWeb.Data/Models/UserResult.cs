using System;
using System.Collections.Generic;

namespace QuizWeb.Data.Models
{
    public class UserResult : IEquatable<UserResult>
    {
        public UserResult()
        {
            ThemeName = string.Empty;
            SubThemesResult = new List<UserResult>();
        }

        public int TotalAnswers { get; set; }

        public int CorrectAnswers { get; set; }
        public string ThemeName { get; set; }
        public string Name { get; set; }

        public List<UserResult> SubThemesResult { get; set; }

        public bool Equals(UserResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return TotalAnswers == other.TotalAnswers && CorrectAnswers == other.CorrectAnswers && Name == other.Name &&
                   string.Equals(ThemeName, other.ThemeName) && Equals(SubThemesResult, other.SubThemesResult);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((UserResult) obj);
        }
    }
}
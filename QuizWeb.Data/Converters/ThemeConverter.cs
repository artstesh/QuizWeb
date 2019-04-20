using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Converters
{
    public static class ThemeConverter
    {
        public static ThemeModel ToDto(this Theme origin)
        {
            if (origin == null) return null;
            return new ThemeModel
            {
                Name = origin.Name, Id = origin.Id, ParentThemeId = origin.ParentThemeId
            };
        }

        public static Theme FromDto(this ThemeModel origin)
        {
            if (origin == null) return null;
            return new Theme
            {
                Name = origin.Name, Id = origin.Id, ParentThemeId = origin.ParentThemeId
            };
        }
    }
}
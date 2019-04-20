using QuizWeb.Data.Entities;
using QuizWeb.Data.Models;

namespace QuizWeb.Data.Converters
{
    public static class LevelConverter
    {
        public static LevelModel ToDto(this Level origin)
        {
            if (origin == null) return null;
            return new LevelModel
            {
                Name = origin.Name, Id = origin.Id
            };
        }

        public static Level FromDto(this LevelModel origin)
        {
            if (origin == null) return null;
            return new Level
            {
                Name = origin.Name, Id = origin.Id
            };
        }
    }
}
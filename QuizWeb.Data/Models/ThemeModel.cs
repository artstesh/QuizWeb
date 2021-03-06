﻿using System;

namespace QuizWeb.Data.Models
{
    public class ThemeModel : IEquatable<ThemeModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentThemeId { get; set; }

        public bool Equals(ThemeModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Name, other.Name) && ParentThemeId == other.ParentThemeId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ThemeModel) obj);
        }
    }
}
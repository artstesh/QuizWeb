using System;
using QuizWeb.Data.Entities;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Entities
{
    public class StudentTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(Student origin)
        {
            var model = new Student
            {
                Name = origin.Name, Login = origin.Login, ExamTime = origin.ExamTime, ExamThemeId = origin.ExamThemeId
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(Student origin, string Name)
        {
            var model = new Student
            {
                Name = Name, Login = origin.Login, ExamTime = origin.ExamTime
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Login(Student origin, string Login)
        {
            var model = new Student
            {
                Name = origin.Name, Login = Login, ExamTime = origin.ExamTime
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ThemeId(Student origin, int themeId)
        {
            var model = new Student
            {
                Name = origin.Name, Login = origin.Login, ExamTime = origin.ExamTime, Id = origin.Id,
                ExamThemeId = themeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ActiveSessionTill(Student origin, DateTime ActiveSessionTill)
        {
            var model = new Student
            {
                Name = origin.Name, Login = origin.Login, ExamTime = ActiveSessionTill
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(Student origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(Student origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(Student origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
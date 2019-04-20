using System;
using QuizWeb.Data.Models;
using QuizWeb.Tests.FakeFactories;
using Xunit;

namespace QuizWeb.Tests.Data.Models
{
    public class StudentModelTests
    {
        [Theory]
        [AutoMoqData]
        public void Equals_True(StudentModel origin)
        {
            var model = new StudentModel
            {
                Name = origin.Name, Login = origin.Login, ExamTime = origin.ExamTime, Id = origin.Id,
                ExamThemeId = origin.ExamThemeId
            };
            Assert.True(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Name(StudentModel origin, string Name)
        {
            var model = new StudentModel
            {
                Name = Name, Login = origin.Login, ExamTime = origin.ExamTime, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Id(StudentModel origin, int Id)
        {
            var model = new StudentModel
            {
                Name = origin.Name, Login = origin.Login, ExamTime = origin.ExamTime, Id = Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ThemeId(StudentModel origin, int themeId)
        {
            var model = new StudentModel
            {
                Name = origin.Name, Login = origin.Login, ExamTime = origin.ExamTime, Id = origin.Id,
                ExamThemeId = themeId
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Login(StudentModel origin, string Login)
        {
            var model = new StudentModel
            {
                Name = origin.Name, Login = Login, ExamTime = origin.ExamTime, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_ActiveSessionTill(StudentModel origin, DateTime ActiveSessionTill)
        {
            var model = new StudentModel
            {
                Name = origin.Name, Login = origin.Login, ExamTime = ActiveSessionTill, Id = origin.Id
            };
            Assert.False(model.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Null(StudentModel origin)
        {
            Assert.False(origin.Equals(null));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_True_Self(StudentModel origin)
        {
            Assert.True(origin.Equals(origin));
        }

        [Theory]
        [AutoMoqData]
        public void Equals_False_Wrong_Type(StudentModel origin)
        {
            Assert.False(origin.Equals(new object()));
        }
    }
}
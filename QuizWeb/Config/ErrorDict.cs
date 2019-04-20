using System;
using QuizWeb.Models;

namespace QuizWeb.Config
{
    public static class ErrorDict
    {
        public static readonly Result Ok = new Result(0, "ОК");
        
        public static Result NoSuchStudent(string name)
        {
            var message = String.Format($"Студент {name} не зарегистрирован.");
            return new Result(1000, message);
        }
        
        public static Result NotEnrolled(string name)
        {
            var message = String.Format($"{name}, у вас нет запланированных экзаменов.");
            return new Result(1100, message);
        }
    }
}
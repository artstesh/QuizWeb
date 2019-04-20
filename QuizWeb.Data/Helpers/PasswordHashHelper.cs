using System;
using System.Security.Cryptography;
using System.Text;

namespace QuizWeb.Data.Helpers
{
    public static class PasswordHashHelper
    {
        /// <summary>
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            using (HashAlgorithm algorithm = new SHA256CryptoServiceProvider())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var passwordHashBytes = algorithm.ComputeHash(passwordBytes);

                return Convert.ToBase64String(passwordHashBytes);
            }
        }
    }
}
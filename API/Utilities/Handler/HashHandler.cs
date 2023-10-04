﻿namespace API.Utilities.Handler
{
    public class HashHandler
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        public static String HashPassword(string Password)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password, GetRandomSalt());
        }

        public static bool verifvyPassword()
        {
            return true;
        }

    }
}

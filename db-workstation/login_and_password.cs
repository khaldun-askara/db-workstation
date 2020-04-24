using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace db_workstation
{
    class login_and_password
    {
        private static readonly Regex loginRegex = new Regex("^[А-ЯЁа-яёA-Za-z0-9 \\f\\n\\r\\t\\v~`!@\\#\\$%\\^&\\.,\\*\\(\\)_\\+\\-=\"'№;:\\?\\{\\}\\[\\]\\<\\>\\|/\\\\]{1,50}$");
        private static int salt_size = 86;
        private static int hash_size = 86;
        public static int iterations = 100000;
        public static bool CorrectLogin(string login)
        {
            return loginRegex.IsMatch(DelSpaces(login));
        }
        public static string DelSpaces(string str)
        {
            Regex spaces = new Regex("\\s+");
            return spaces.Replace(DelBorderSpaces(str), " ");
        }
        public static string DelBorderSpaces(string str)
        {
            Regex spaces1 = new Regex("(?<![^ \\f\\n\\r\\t\\v])[ \\f\\n\\r\\t\\v]{1,}(?=[^ \\f\\n\\r\\t\\v])");
            Regex spaces2 = new Regex("(?<=[^ \\f\\n\\r\\t\\v])[ \\f\\n\\r\\t\\v]{1,}(?![^ \\f\\n\\r\\t\\v])");
            return spaces2.Replace(spaces1.Replace(str, ""), "");
        }
        public static int PasswordScore(string pass)
        {
            var zx = new Zxcvbn.Zxcvbn();
            var result = zx.EvaluatePassword(pass, null);
            return result.Score;
        }
        public static byte[] GetSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[salt_size];
            provider.GetBytes(salt);
            return salt;
        }
        public static byte[] GetHash(string password, byte[] salt)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            return pbkdf2.GetBytes(hash_size);
        }
        public static bool VerifyPassword(string password, string salt, string good_hash)
        {
            byte[] byte_mass_salt = Convert.FromBase64String(salt);
            return good_hash == Convert.ToBase64String(GetHash(password, byte_mass_salt));
        }
    }
}

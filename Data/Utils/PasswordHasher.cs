using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    public static class PasswordHasher
    {

        public static string GetSalt() 
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] byteSalt = new byte[10];
            rng.GetBytes(byteSalt);
            return Convert.ToBase64String(byteSalt);
        }

        public static string HashPwd(string password, string salt)
        {
            byte[] byteSalt = Encoding.Unicode.GetBytes(salt);
            var pwdHash = new Rfc2898DeriveBytes(password, byteSalt, 1000).GetBytes(20);
            return Convert.ToBase64String(pwdHash);
        }
    }
}

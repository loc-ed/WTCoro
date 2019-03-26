using System;
using System.Text;
using System.Security.Cryptography;
using WTCoro_AW.Models;

/*
namespace WTCoro_AW
{
    public static class Crypto
    {
        public static string Hash(Person person)
        {
            //generate salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[8]);
            person.Password.PasswordSalt = Convert.ToBase64String(salt);

            //Concatenate the password to the salt and hash it with a hashing function.
          var pbkdf2 = new Rfc2898DeriveBytes(person.Password1, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(44);
            byte[] hashBytes = new byte[52];

            Array.Copy(salt, 0, hashBytes, 0, 8);
            Array.Copy(hash, 0, hashBytes, 8, 44);

            return Convert.ToBase64String(hashBytes);

        }
    }
}
*/
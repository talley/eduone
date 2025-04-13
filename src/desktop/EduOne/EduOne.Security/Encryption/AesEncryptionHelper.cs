using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Security.Encryption
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public static class AesEncryptionHelper
    {
        private const int SaltSize = 32; // 256 bits
        private const int KeySize = 32;  // 256 bits
        private const int IvSize = 16;   // 128 bits
        private const int Iterations = 100_000;

        public static string EncryptString(string plainText)
        {
            string passphrase = "Iam123@#$&_$_FGS_%";
            // Generate a random salt
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Derive key and IV
            var keyIv = new Rfc2898DeriveBytes(passphrase, salt, Iterations);
            byte[] key = keyIv.GetBytes(KeySize);
            byte[] iv = keyIv.GetBytes(IvSize);

            byte[] encrypted;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;

                using (var encryptor = aes.CreateEncryptor())
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    encrypted = ms.ToArray();
                }
            }

            // Combine salt + encrypted bytes
            byte[] combined = new byte[SaltSize + encrypted.Length];
            Buffer.BlockCopy(salt, 0, combined, 0, SaltSize);
            Buffer.BlockCopy(encrypted, 0, combined, SaltSize, encrypted.Length);

            return Convert.ToBase64String(combined);
        }

        public static string DecryptString(string cipherText)
        {
            string passphrase = "Iam123@#$&_$_FGS_%";
            byte[] combined = Convert.FromBase64String(cipherText);

            // Extract salt
            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(combined, 0, salt, 0, SaltSize);

            // Extract encrypted data
            byte[] encrypted = new byte[combined.Length - SaltSize];
            Buffer.BlockCopy(combined, SaltSize, encrypted, 0, encrypted.Length);

            // Derive key and IV again
            var keyIv = new Rfc2898DeriveBytes(passphrase, salt, Iterations);
            byte[] key = keyIv.GetBytes(KeySize);
            byte[] iv = keyIv.GetBytes(IvSize);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;

                using (var decryptor = aes.CreateDecryptor())
                using (var ms = new MemoryStream(encrypted))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }

}

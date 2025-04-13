using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Security.Encryption
{

public static class HexEncryptionHelper
        {
        private const int SaltSize = 32;
        private const int KeySize = 32;
        private const int IvSize = 16;
        private const int Iterations = 100_000;

        public static string EncryptString(string plainText)
        {
            string passphrase = "Iam123@#$&_$_FGS_%";
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

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

            // Combine salt + ciphertext
            byte[] combined = new byte[salt.Length + encrypted.Length];
            Buffer.BlockCopy(salt, 0, combined, 0, salt.Length);
            Buffer.BlockCopy(encrypted, 0, combined, salt.Length, encrypted.Length);

            return BytesToHex(combined);
        }

        public static string DecryptString(string hexString)
        {
            Console.WriteLine($"🔍 Received hex string: {hexString}");
            Console.WriteLine($"🔍 Length: {hexString.Length}");

            string passphrase = "Iam123@#$&_$_FGS_%";
            byte[] combined = HexToBytes(hexString);

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(combined, 0, salt, 0, SaltSize);

            byte[] encrypted = new byte[combined.Length - SaltSize];
            Buffer.BlockCopy(combined, SaltSize, encrypted, 0, encrypted.Length);

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

        private static string BytesToHex(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        private static byte[] HexToBytes(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentException("Hex string is null or empty.");

            if (hex.Length % 2 != 0)
                throw new FormatException("Hex string length is not even.");

            int len = hex.Length;
            byte[] bytes = new byte[len / 2];
            for (int i = 0; i < len; i += 2)
            {
                string hexPair = hex.Substring(i, 2);
                Console.WriteLine($"Parsing pair: {hexPair}");

                try
                {
                    bytes[i / 2] = Convert.ToByte(hexPair, 16);
                }
                catch (FormatException ex)
                {
                    throw new FormatException($"Invalid hex pair '{hexPair}' at position {i}: {ex.Message}");
                }
            }

            return bytes;
        }

    }

}

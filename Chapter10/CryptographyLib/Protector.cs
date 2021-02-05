﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using static System.Convert;

// namespace CryptographyLib
namespace Packt.Shared
{
    public static class Protector
    {
        // salt size must be at least 8 bytes, we will use 16 bytes
        private static readonly byte[] salt =
            Encoding.Unicode.GetBytes("7BANANAS");

        // iterations should be high enough to take at least 100ms to
        // generate a Key and IV on the target machine.5 50,000 iterations
        // takes 131ms on my 3.3 GHz Dual-Core Intel Core i7 MacBook Pro
        private static readonly int iterations = 50_000;

        public static string Encrypt(
            string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

            var aes = Aes.Create(); // abstract class factory method

            var pbkdf2 = new Rfc2898DeriveBytes(
                password, salt, iterations
            );

            aes.Key = pbkdf2.GetBytes(32); // set a 256-bit key
            aes.IV = pbkdf2.GetBytes(16); // set a 128-bit key

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(
                    ms, aes.CreateEncryptor(),
                    CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }
            return Convert.ToBase64String(encryptedBytes);
        }

            public static string Decrypt(
                string cryptoText, string password)
            {
                byte[] plainBytes;
                byte[] cryptoBytes = Convert.
                    FromBase64String(cryptoText);

                var aes = Aes.Create();

                var pbkdf2 = new Rfc2898DeriveBytes(
                    password, salt, iterations);

                aes.Key = pbkdf2.GetBytes(32);
                aes.IV = pbkdf2.GetBytes(16);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(
                        ms, aes.CreateDecryptor(),
                        CryptoStreamMode.Write))
                    {
                        cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                    }
                    plainBytes = ms.ToArray();
                }
                return Encoding.Unicode.GetString(plainBytes);
            }
            
        
    }
}

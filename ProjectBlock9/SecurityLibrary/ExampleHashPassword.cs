﻿using System.Security.Cryptography;
using System.Text;

namespace SecurityLibrary
{
    public class ExampleHashPassword
    {
        public string ComputeSha256Hash(string rawData)
        {
            // Проверка входных данных
            if (string.IsNullOrEmpty(rawData))
                throw new ArgumentNullException(nameof(rawData));

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

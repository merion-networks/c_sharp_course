using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class AesEncryption
    {

        public void Start()
        {

            using (Aes myAes = Aes.Create())
            {
                string original = "Привет академия!";

                Console.WriteLine($"myAes.Key: {BitConverter.ToString(myAes.Key)}");
                Console.WriteLine($"myAes.IV: {BitConverter.ToString(myAes.IV)}");


                byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);


                string decrypted = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                Console.WriteLine($"Оригинальная строка: {original}");
                Console.WriteLine($"Зашифрованная строка: {BitConverter.ToString(encrypted)}");
                Console.WriteLine($"Расшифрованная строка: {decrypted}");

            }
        }

        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
        {
            // Проверки параметров
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));

            byte[] encripted;

            using (Aes aesAlg = Aes.Create())
            {

                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform cryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream csEncript = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncript))
                        {
                            swEncrypt.Write(plainText);
                        }

                        encripted = ms.ToArray();
                    }
                }
            }
            return encripted;
        }



        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Проверки параметров

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));  
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));

            string planText;

            using (Aes aesAlg = Aes.Create())
            {

                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform cryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            planText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return planText;
        }

    }
}

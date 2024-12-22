using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RsaEncryption
    {


        public void Start()
        {

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                string original = "Привет академия!";

                RSAParameters publicKey = rsa.ExportParameters(false); // Публичный ключ
                RSAParameters privateKey = rsa.ExportParameters(true); // Приватный ключ

                byte[] encrypted = EncryptData(original, publicKey, true);


                string decrypted = DecryptData(encrypted, privateKey, true);

                Console.WriteLine($"Оригинальная строка: {original}");
                Console.WriteLine($"Зашифрованная строка: {BitConverter.ToString(encrypted)}");
                Console.WriteLine($"Расшифрованная строка: {decrypted}");
            }
            
        }

        private void Gererate()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                RSAParameters publicKey = rsa.ExportParameters(false); // Публичный ключ
                RSAParameters privateKey = rsa.ExportParameters(true); // Приватный ключ
            }
        }

        public byte[] EncryptData(string dataToEncrypt, RSAParameters publicKey, bool doOAEPPadding)
        {
            byte[] dataToEncryptBytes = Encoding.UTF8.GetBytes(dataToEncrypt);
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                return rsa.Encrypt(dataToEncryptBytes, doOAEPPadding);
            }
        }

        public string DecryptData(byte[] dataToDecrypt, RSAParameters privateKey, bool doOAEPPadding)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                byte[] decryptedBytes = rsa.Decrypt(dataToDecrypt, doOAEPPadding);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyASPNET.Helper
{
    /// <summary>
    /// Encrypt a string
    /// </summary>
    public class Cryptography
    {
        public class EncryptDecrypt
        {
            /// <summary>
            /// Retorn a string Encrypt
            /// </summary>
            /// <param name="entryText"></param>
            /// <returns></returns>
            public static string Encrypt(string entryText)
            {
                var Key = new byte[] { 12, 2, 56, 117, 12, 67, 33, 23, 12, 2, 56, 117, 12, 67, 33, 23 }; //key;
                var IniVetor = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                var Algorithm = Aes.Create();

                byte[] symEncryptedData;

                var dataToProtectAsArray = Encoding.UTF8.GetBytes(entryText);
                using (var encryptor = Algorithm.CreateEncryptor(Key, IniVetor))
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(dataToProtectAsArray, 0, dataToProtectAsArray.Length);
                    cryptoStream.FlushFinalBlock();
                    symEncryptedData = memoryStream.ToArray();
                }
                Algorithm.Dispose();
                return Convert.ToBase64String(symEncryptedData);
            }

            /// <summary>
            /// Retorn a string Decrypt
            /// </summary>
            /// <param name="entryText"></param>
            /// <returns></returns>
            public static string Decrypt(string entryText)
            {
                var Key = new byte[] { 12, 2, 56, 117, 12, 67, 33, 23, 12, 2, 56, 117, 12, 67, 33, 23 }; //key;
                var IniVetor = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                var Algorithm = Aes.Create();

                var symEncryptedData = Convert.FromBase64String(entryText);
                byte[] symUnencryptedData;
                using (var decryptor = Algorithm.CreateDecryptor(Key, IniVetor))
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(symEncryptedData, 0, symEncryptedData.Length);
                    cryptoStream.FlushFinalBlock();
                    symUnencryptedData = memoryStream.ToArray();
                }
                Algorithm.Dispose();
                return System.Text.Encoding.Default.GetString(symUnencryptedData);
            }
        }

    }
}

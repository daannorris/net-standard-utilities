using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    /// <summary>
    /// Cryptography Utilities
    /// </summary>
    public class Cryptography
    {
        /// <summary>
        /// Encrypts the specified text using AES.
        /// </summary>
        /// <param name="text">Plain text</param>
        /// <param name="key">Plain text password</param>
        /// <param name="mode">AES Cipher Mode</param>
        /// <param name="padding">AES Padding Mode</param>
        /// <returns>Returns a Base64 encrypted string</returns>
        public static string Encrypt(string text, string key, CipherMode mode = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException(nameof(text));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException(nameof(key));
            }

            var buffer = Encoding.UTF8.GetBytes(text);

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.Mode = mode;
                aes.Padding = padding;

                using (var stream = new MemoryStream())
                {
                    using (var encryptor = aes.CreateEncryptor())
                    {
                        using (var cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(buffer, 0, buffer.Length);
                        }
                    }

                    return Convert.ToBase64String(stream.ToArray());
                }
            }
        }

        /// <summary>
        /// Decrypts the specified text using AES.
        /// </summary>
        /// <param name="text">Base64 encoded encrypted buffer</param>
        /// <param name="key">Plain text password</param>
        /// <param name="mode">AES Cipher Mode</param>
        /// <param name="padding">AES Padding Mode</param>
        /// <returns>Returns plain text</returns>
        public static string Decrypt(string text, string key, CipherMode mode = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException(nameof(text));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException(nameof(key));
            }

            var buffer = Convert.FromBase64String(text);

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.Mode = mode;
                aes.Padding = padding;

                using (var stream = new MemoryStream())
                {
                    using (var decryptor = aes.CreateDecryptor())
                    {
                        using (var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(buffer, 0, buffer.Length);
                        }
                    }

                    return Encoding.UTF8.GetString(stream.ToArray());
                }
            }
        }
    }
}
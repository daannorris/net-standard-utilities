using System;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace UtilsTests
{
    /// <summary>
    /// Cryptography Tests
    /// </summary>
    [TestClass]
    public class CryptographyTests
    {
        private string _text = "test";
        private string _secret = "wBX4fsjNdFxTt3UM";
        private string _shortKey = "key";
        private string _encryptedText = "3grVzm7/F9lu+v59f4Vgxg==";

        /// <summary>
        /// Encrypt empty string using ECB Mode and PKCS7 Padding Test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncryptEmptyTextECBPKCS7Test()
        {
            _ = Cryptography.Encrypt(string.Empty, string.Empty);
        }

        /// <summary>
        /// Encrypt string with empty key using ECB Mode and PKCS7 Padding Test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncryptEmptyKeyECBPKCS7Test()
        {
            _ = Cryptography.Encrypt(_text, string.Empty);
        }

        /// <summary>
        /// Encrypt string with short key using ECB Mode and PKCS7 Padding Test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CryptographicException))]
        public void EncryptShortKeyECBPKCS7Test()
        {
            _ = Cryptography.Encrypt(_text, _shortKey);
        }

        /// <summary>
        /// Encrypt string using ECB Mode and PKCS7 Padding Test
        /// </summary>
        [TestMethod]
        public void EncryptECBPKCS7Test()
        {
            var result = Cryptography.Encrypt(_text, _secret);
            Assert.AreEqual(_encryptedText, result);
        }

        /// <summary>
        /// Decrypt empty string using ECB Mode and PKCS7 Padding Test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DecryptEmptyTextECBPKCS7Test()
        {
            _ = Cryptography.Decrypt(string.Empty, string.Empty);
        }

        /// <summary>
        /// Decrypt string with empty key using ECB Mode and PKCS7 Padding Test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DecryptEmptyKeyECBPKCS7Test()
        {
            _ = Cryptography.Encrypt(_text, string.Empty);
        }

        /// <summary>
        /// Decrypt string with short key using ECB Mode and PKCS7 Padding Test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CryptographicException))]
        public void DecryptShortKeyECBPKCS7Test()
        {
            _ = Cryptography.Decrypt(_text, _shortKey);
        }

        /// <summary>
        /// Decrypt string using ECB Mode and PKCS7 Padding Test
        /// </summary>
        [TestMethod]
        public void DecryptECBPKCS7Test()
        {
            var result = Cryptography.Decrypt(_encryptedText, _secret);
            Assert.AreEqual(_text, result);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class CryptographyTests
    {
        [TestMethod]
        public void EncryptECBPKCS7Test()
        {
            var result = Cryptography.Encrypt("test", "wBX4fsjNdFxTt3UM");
            Assert.AreEqual("3grVzm7/F9lu+v59f4Vgxg==", result);
        }

        [TestMethod]
        public void DecryptECBPKCS7Test()
        {
            var result = Cryptography.Decrypt("3grVzm7/F9lu+v59f4Vgxg==", "wBX4fsjNdFxTt3UM");
            Assert.AreEqual("test", result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Utilities.Tests
{
    /// <summary>
    /// Strings Utilities Tests
    /// </summary>
    [TestClass]
    public class StringsTests
    {
        private string _uppercase = "A-Z";

        private string _lowercase = "a-z";

        private string _numbers = "\\d";

        /// <summary>
        /// Generate empty random string test
        /// </summary>
        [TestMethod]
        public void GenerateRandomEmptyTest()
        {
            var data = Strings.GenerateRandom(0);
            Assert.AreEqual(string.Empty, data);
        }

        /// <summary>
        /// Generate basic random string test
        /// </summary>
        [TestMethod]
        public void GenerateRandomBasicTest()
        {
            var regex = new Regex("^.{12}");
            var data = Strings.GenerateRandom(12);
            Assert.IsTrue(regex.IsMatch(data));
        }

        /// <summary>
        /// Generate only uppercase random string test
        /// </summary>
        [TestMethod]
        public void GenerateRandomOnlyUppercaseTest()
        {
            var regex = new Regex($"^[{_uppercase}]{{12}}");
            var data = Strings.GenerateRandom(12, true, false, false, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        /// <summary>
        /// Generate only lowercase random string test
        /// </summary>
        [TestMethod]
        public void GenerateRandomOnlyLowercaseTest()
        {
            var regex = new Regex($"^[{_lowercase}]{{12}}");
            var data = Strings.GenerateRandom(12, false, true, false, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        /// <summary>
        /// Generate only numbers random string test
        /// </summary>
        [TestMethod]
        public void GenerateRandomOnlyNumbersTest()
        {
            var regex = new Regex($"^[{_numbers}]{{12}}");
            var data = Strings.GenerateRandom(12, false, false, true, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        /// <summary>
        /// Generate only uppercase and numbers random string test
        /// </summary>
        [TestMethod]
        public void GenerateRandomOnlyUppercaseAndNumbersTest()
        {
            var regex = new Regex($"^[{_uppercase}{_numbers}]{{12}}");
            var data = Strings.GenerateRandom(12, true, false, true, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        /// <summary>
        /// Generate only lowercase and numbers random string test
        /// </summary>
        [TestMethod]
        public void GenerateRandomOnlyLowercaseAndNumbersTest()
        {
            var regex = new Regex($"^[{_lowercase}{_numbers}]{{12}}");
            var data = Strings.GenerateRandom(12, false, true, true, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        /// <summary>
        /// Generate only uppercase and lowercase random string test
        /// </summary>
        [TestMethod]
        public void GenerateRandomOnlyUppercaseAndLowercaseTest()
        {
            var regex = new Regex($"^[{_uppercase}{_lowercase}]{{12}}");
            var data = Strings.GenerateRandom(12, true, true, false, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        /// <summary>
        /// Generate only uppercase, lowercase and numbers random string test
        /// </summary>
        [TestMethod]
        public void GenerateRandomOnlyUppercaseAndLowercaseAndNumbersTest()
        {
            var regex = new Regex($"^[{_uppercase}{_lowercase}{_numbers}]{{12}}");
            var data = Strings.GenerateRandom(12, true, true, true, false);
            Assert.IsTrue(regex.IsMatch(data));
        }
    }
}

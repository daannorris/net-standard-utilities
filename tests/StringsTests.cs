using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class StringsTests
    {
        [TestMethod]
        public void GenerateRandomEmptyTest()
        {
            var data = Strings.GenerateRandom(0);
            Assert.AreEqual(string.Empty, data);
        }

        [TestMethod]
        public void GenerateRandomBasicTest()
        {
            var regex = new Regex("^.{12}");
            var data = Strings.GenerateRandom(12);
            Assert.IsTrue(regex.IsMatch(data));
        }

        [TestMethod]
        public void GenerateRandomOnlyUppercaseTest()
        {
            var regex = new Regex($"^[{uppercase}]{12}");
            var data = Strings.GenerateRandom(12, true, false, false, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        [TestMethod]
        public void GenerateRandomOnlyLowercaseTest()
        {
            var regex = new Regex($"^[{lowercase}]{12}");
            var data = Strings.GenerateRandom(12, false, true, false, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        [TestMethod]
        public void GenerateRandomOnlyNumbersTest()
        {
            var regex = new Regex($"^[{numbers}]{12}");
            var data = Strings.GenerateRandom(12, false, false, true, false);
            Assert.IsTrue(regex.IsMatch(data));
        }
        [TestMethod]
        public void GenerateRandomOnlyUppercaseAndNumbersTest()
        {
            var regex = new Regex($"^[{uppercase}{numbers}]{12}");
            var data = Strings.GenerateRandom(12, true, false, true, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        [TestMethod]
        public void GenerateRandomOnlyLowercaseAndNumbersTest()
        {
            var regex = new Regex($"^[{lowercase}{numbers}]{12}");
            var data = Strings.GenerateRandom(12, false, true, true, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        [TestMethod]
        public void GenerateRandomOnlyUppercaseAndLowercaseTest()
        {
            var regex = new Regex($"^[{uppercase}{lowercase}]{12}");
            var data = Strings.GenerateRandom(12, true, true, false, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        [TestMethod]
        public void GenerateRandomOnlyUppercaseAndLowercaseAndNumbersTest()
        {
            var regex = new Regex($"^[{uppercase}{lowercase}{numbers}]{12}");
            var data = Strings.GenerateRandom(12, true, true, true, false);
            Assert.IsTrue(regex.IsMatch(data));
        }

        private string uppercase => "A-Z";
        private string lowercase => "a-z";
        private string numbers => "\\d";
    }
}

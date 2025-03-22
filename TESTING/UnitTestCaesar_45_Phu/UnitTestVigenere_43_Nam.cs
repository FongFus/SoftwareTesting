using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SoftwareTesting;

namespace UnitTestSoftwareTesting
{

    [TestClass]
    public class UnitTestVigenere_43_Nam
    {
        [TestMethod]
        public void TC01_43_Nam_VigenereEncrypt_ShouldReturnCorrectCipherText()
        {
            // Arrange
            string input = "HELLO";
            string key = "KEY";
            string expectedOutput = "RIJVS";

            // Act
            string actualOutput = VigenereCipher_43_Nam.VigenereEncrypt(input, key);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "Mã hóa Vigenère bị sai.");
        }

        [TestMethod]
        public void TC02_43_Nam_VigenereDecrypt_ShouldReturnCorrectPlainText()
        {
            // Arrange
            string input = "RIJVS";
            string key = "KEY";
            string expectedOutput = "HELLO";

            // Act
            string actualOutput = VigenereCipher_43_Nam.VigenereDecrypt(input, key);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "Giải mã Vigenère bị sai.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC03_43_Nam_VigenereEncrypt_EmptyString_ShouldThrowException()
        {
            string input = "";
            string key = "KEY";

            VigenereCipher_43_Nam.VigenereEncrypt(input, key);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TC04_43_Nam_VigenereEncrypt_InvalidKey_ShouldThrowException()
        {
            string input = "HELLO";
            string key = ""; // Khóa không hợp lệ

            VigenereCipher_43_Nam.VigenereEncrypt(input, key);
        }
    }
}

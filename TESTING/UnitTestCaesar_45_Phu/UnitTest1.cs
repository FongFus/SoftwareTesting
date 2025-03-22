using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using SoftwareTesting;

namespace UnitTestSoftwareTesting
{
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void Setup_45_Phu()
        {
            
        }

        // TC01_EP_EncryptValidInput_ReturnsExpected_45_Phu
        [TestMethod]
        public void TC01_EP_EncryptValidInput_ReturnsExpected_45_Phu()
        {
            string input = "HELLO";
            int shift = 3;
            string expected = "KHOOR";
            string actual = CaesarCipher_45_Phu.Encrypt_45_Phu(input, shift);
            Assert.AreEqual(expected, actual, "Encryption with valid input failed.");
        }

        // TC02_EP_EncryptInvalidShift_ThrowsException_45_Phu
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC02_EP_EncryptInvalidShift_ThrowsException_45_Phu()
        {
            string input = "HELLO";
            int shift = -1; // Invalid shift
            CaesarCipher_45_Phu.Encrypt_45_Phu(input, shift);
        }

        // TC03_BVA_EncryptMinShift_ReturnsExpected_45_Phu
        [TestMethod]
        public void TC03_BVA_EncryptMinShift_ReturnsExpected_45_Phu()
        {
            string input = "HELLO";
            int shift = 1;
            string expected = "IFMMP";
            string actual = CaesarCipher_45_Phu.Encrypt_45_Phu(input, shift);
            Assert.AreEqual(expected, actual, "Encryption at minimum shift failed.");
        }

        // TC04_BVA_EncryptMaxShift_ReturnsExpected_45_Phu
        [TestMethod]
        public void TC04_BVA_EncryptMaxShift_ReturnsExpected_45_Phu()
        {
            string input = "HELLO";
            int shift = 25;
            string expected = "GDKKN";
            string actual = CaesarCipher_45_Phu.Encrypt_45_Phu(input, shift);
            Assert.AreEqual(expected, actual, "Encryption at maximum shift failed.");
        }

        // TC05_DT_EncryptWithNumbersAndSymbols_ReturnsExpected_45_Phu
        [TestMethod]
        public void TC05_DT_EncryptWithNumbersAndSymbols_ReturnsExpected_45_Phu()
        {
            string input = "HELLO123!";
            int shift = 3;
            string expected = "KHOOR123!"; // Only letters are shifted
            string actual = CaesarCipher_45_Phu.Encrypt_45_Phu(input, shift);
            Assert.AreEqual(expected, actual, "Encryption with mixed characters failed.");
        }

        // TC06_ST_EncryptThenDecrypt_ReturnsOriginal_45_Phu
        [TestMethod]
        public void TC06_ST_EncryptThenDecrypt_ReturnsOriginal_45_Phu()
        {
            string input = "HELLO";
            int shift = 3;
            string encrypted = CaesarCipher_45_Phu.Encrypt_45_Phu(input, shift);
            string decrypted = CaesarCipher_45_Phu.Decrypt_45_Phu(encrypted, shift);
            Assert.AreEqual(input, decrypted, "Decryption after encryption failed.");
        }

        // TC07_EP_DecryptInvalidShift_ThrowsException_45_Phu
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC07_EP_DecryptInvalidShift_ThrowsException_45_Phu()
        {
            string input = "KHOOR";
            int shift = -1; // Invalid shift
            CaesarCipher_45_Phu.Decrypt_45_Phu(input, shift);
        }

        // TC08_BVA_DecryptMinShift_ReturnsExpected_45_Phu
        [TestMethod]
        public void TC08_BVA_DecryptMinShift_ReturnsExpected_45_Phu()
        {
            string input = "IFMMP";
            int shift = 1;
            string expected = "HELLO";
            string actual = CaesarCipher_45_Phu.Decrypt_45_Phu(input, shift);
            Assert.AreEqual(expected, actual, "Decryption at minimum shift failed.");
        }

        // TC09_BVA_DecryptMaxShift_ReturnsExpected_45_Phu
        [TestMethod]
        public void TC09_BVA_DecryptMaxShift_ReturnsExpected_45_Phu()
        {
            string input = "GDKKN";
            int shift = 25;
            string expected = "HELLO";
            string actual = CaesarCipher_45_Phu.Decrypt_45_Phu(input, shift);
            Assert.AreEqual(expected, actual, "Decryption at maximum shift failed.");
        }

        // TC10_DT_DecryptWithNumbersAndSymbols_ReturnsExpected_45_Phu
        [TestMethod]
        public void TC10_DT_DecryptWithNumbersAndSymbols_ReturnsExpected_45_Phu()
        {
            string input = "KHOOR123!";
            int shift = 3;
            string expected = "HELLO123!";
            string actual = CaesarCipher_45_Phu.Decrypt_45_Phu(input, shift);
            Assert.AreEqual(expected, actual, "Decryption with mixed characters failed.");
        }

        // TC11_ST_EncryptDecryptWithZeroShift_ReturnsOriginal_45_Phu
        [TestMethod]
        public void TC11_ST_EncryptDecryptWithZeroShift_ReturnsOriginal_45_Phu()
        {
            string input = "HELLO";
            int shift = 0;
            string encrypted = CaesarCipher_45_Phu.Encrypt_45_Phu(input, shift);
            string decrypted = CaesarCipher_45_Phu.Decrypt_45_Phu(encrypted, shift);
            Assert.AreEqual(input, decrypted, "Zero shift should return original input.");
        }

        public TestContext TestContext { get; set; }

        //TC12_TestCaesarCipherWithExcel_45_Phu
        // TC12: DataSource chỉ định nguồn dữ liệu từ tệp CSV và bảng dữ liệu sẽ sử dụng
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data_45_Phu\TestData_Caesar_45_Phu.csv", "TestData_Caesar_45_Phu#csv", DataAccessMethod.Sequential)]

        [TestMethod]
        public void TC12_TestCaesarCipherWithExcel_45_Phu()
        {
            // Lấy dữ liệu từ .csv
            string input_45_Phu = TestContext.DataRow[0].ToString();
            int k_45_Phu = int.Parse(TestContext.DataRow[1].ToString());
            string operation_45_Phu = TestContext.DataRow[2].ToString();
            string expected_45_Phu = TestContext.DataRow[3].ToString();

            // Thực hiện hành động
            string actual_45_Phu;
            if (operation_45_Phu == "Encrypt")
            {
                actual_45_Phu = CaesarCipher_45_Phu.Encrypt_45_Phu(input_45_Phu, k_45_Phu);
            }
            else if (operation_45_Phu == "Decrypt")
            {
                actual_45_Phu = CaesarCipher_45_Phu.Decrypt_45_Phu(input_45_Phu, k_45_Phu);
            }
            else
            {
                Assert.Fail("Operation không hợp lệ: " + operation_45_Phu);
                return;
            }

            // Kiểm tra kết quả
            Assert.AreEqual(expected_45_Phu, actual_45_Phu, $"Input: {input_45_Phu}, K: {k_45_Phu}, Operation: {operation_45_Phu}");
        }
    }
}
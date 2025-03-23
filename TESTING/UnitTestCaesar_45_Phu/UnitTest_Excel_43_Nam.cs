using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SoftwareTesting;

using ExcelDataReader;
using System.IO;
using System.Data;

namespace UnitTestSoftwareTesting
{
    /// <summary>
    /// Summary description for UnitTest_Excel_43_Nam
    /// </summary>
    [TestClass]
    public class UnitTest_Excel_43_Nam
    {
        private static IEnumerable<object[]> GetTestCases_43_Nam()
        {
            string filePath_43_Nam = @"Data_43_Nam\data_43_Nam.xlsx";
            var testCases_43_Nam = new List<object[]>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream_43_Nam = File.Open(filePath_43_Nam, FileMode.Open, FileAccess.Read))
            using (var reader_43_Nam = ExcelReaderFactory.CreateReader(stream_43_Nam))
            {
                var result_43_Nam = reader_43_Nam.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                var table = result_43_Nam.Tables[0];

                Console.WriteLine($"📋 Đọc {table.Rows.Count} dòng từ file Excel:");

                foreach (DataRow row in table.Rows)
                {
                    string crypto_43_Nam = row["cryptography"].ToString(); /*Lấy dữ liệu từ cột "cryptography" của dòng hiện tại.*/
                    string mode_43_Nam = row["mode"].ToString(); /*Lấy dữ liệu từ cột "x" của dòng hiện tại.*/
                    string Input_43_Nam = row["Input"].ToString();
                    string K_43_Nam = row["K"].ToString();
                    string Expected_43_Nam = row["Expected"].ToString();

                    testCases_43_Nam.Add(new object[] { crypto_43_Nam, mode_43_Nam, Input_43_Nam, K_43_Nam, Expected_43_Nam });
                }
            }
            return testCases_43_Nam;
        }

        [DataTestMethod]/* Đánh dấu đây là một test case. MSTest sẽ tự động gọi nó khi chạy test*/
        [DynamicData(nameof(GetTestCases_43_Nam), DynamicDataSourceType.Method)]    /*Đưa vào danh sách TC*/
        public void TestEncryptionDecryption_43_Nam(string cryptography_43_Nam, string mode_43_Nam, string Input_43_Nam, string key_43_Nam, string expectedCipher_43_Nam)
        {
            string actualResult_43_Nam = "";

            if (cryptography_43_Nam == "Caesar")
            {
                int shift_43_Nam = int.Parse(key_43_Nam);
                if (mode_43_Nam == "Encrypt")
                    actualResult_43_Nam = CaesarCipher_45_Phu.Encrypt_45_Phu(Input_43_Nam, shift_43_Nam);
                else
                    actualResult_43_Nam = CaesarCipher_45_Phu.Decrypt_45_Phu(Input_43_Nam, shift_43_Nam);
            }
            else if (cryptography_43_Nam == "Vigenere")
            {
                if (mode_43_Nam == "Encrypt")
                    actualResult_43_Nam = VigenereCipher_43_Nam.VigenereEncrypt_43_Nam(Input_43_Nam, key_43_Nam);
                else
                    actualResult_43_Nam = VigenereCipher_43_Nam.VigenereDecrypt_43_Nam(Input_43_Nam, key_43_Nam);
            }

            Assert.AreEqual(expectedCipher_43_Nam, actualResult_43_Nam,
                $"❌ Failed: {cryptography_43_Nam} - {mode_43_Nam} | P: {Input_43_Nam}, K: {key_43_Nam} | Expected: {expectedCipher_43_Nam}, Got: {actualResult_43_Nam}");
        }
    }
}

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
        private static List<TestCaseData> testCases;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            testCases = ReadTestCasesFromExcel(@"Data_43_Nam\data_43_Nam.xlsx");
        }

        public static List<TestCaseData> ReadTestCasesFromExcel(string filePath)
        {
            var testCases = new List<TestCaseData>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true // Bỏ qua header tự động
                    }
                });

                var table = result.Tables[0];

                Console.WriteLine($"📋 Đọc {table.Rows.Count} dòng từ file Excel (đã bỏ header):");

                foreach (DataRow row in table.Rows) // Duyệt tất cả dòng, không bỏ dòng đầu nữa
                {
                    string crypto = row["cryptography"].ToString();
                    string mode = row["mode"].ToString();
                    string P = row["P"].ToString();
                    string K = row["K"].ToString();
                    string C = row["C"].ToString();

                    Console.WriteLine($"{crypto}\t{mode}\t{P}\t{K}\t{C}");
                    testCases.Add(new TestCaseData(crypto, mode, P, K, C));
                }
            }
            return testCases;
        }


        [TestMethod]
        public void RunExcelTestCases()
        {
            foreach (var testCase in testCases)
            {
                string actualResult = "";

                if (testCase.Cryptography == "Caesar")
                {
                    int shift = int.Parse(testCase.Key);
                    if (testCase.Mode == "Encrypt")
                        actualResult = CaesarCipher_45_Phu.Encrypt_45_Phu(testCase.P, shift);
                    else
                        actualResult = CaesarCipher_45_Phu.Decrypt_45_Phu(testCase.P, shift);
                }
                else if (testCase.Cryptography == "Vigenere")
                {
                    if (testCase.Mode == "Encrypt")
                        actualResult = VigenereCipher_43_Nam.VigenereEncrypt(testCase.P, testCase.Key);
                    else
                        actualResult = VigenereCipher_43_Nam.VigenereDecrypt(testCase.P, testCase.Key);
                }

                Assert.AreEqual(testCase.C, actualResult,
                    $"Failed for {testCase.Cryptography} - {testCase.Mode} | P: {testCase.P}, K: {testCase.Key}");
            }
        }

        public class TestCaseData
        {
            public string Cryptography { get; }
            public string Mode { get; }
            public string P { get; }
            public string Key { get; }
            public string C { get; }

            public TestCaseData(string cryptography, string mode, string p, string key, string c)
            {
                Cryptography = cryptography;
                Mode = mode;
                P = p;
                Key = key;
                C = c;
            }
        }
    }
}

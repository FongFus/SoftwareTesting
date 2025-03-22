using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareTesting
{
    public class VigenereCipher_43_Nam
    {
        // Kiểm tra dữ liệu đầu vào
        private static void ValidateVigenereInput(string text, string key)
        {
            if (string.IsNullOrEmpty(key) || !System.Text.RegularExpressions.Regex.IsMatch(key, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Khóa Vigenère không hợp lệ! Không được để trống và chỉ chứa chữ cái.");
            }

            if (string.IsNullOrEmpty(text) || !System.Text.RegularExpressions.Regex.IsMatch(text, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Văn bản đầu vào không hợp lệ! Chỉ được chứa chữ cái.");
            }
        }

        // Mã hóa Vigenère
        public static string VigenereEncrypt(string text, string key)
        {
            ValidateVigenereInput(text, key); // Kiểm tra đầu vào trước khi xử lý

            string result = "";
            int keyIndex = 0;
            key = key.ToUpper();
            foreach (char c in text.ToUpper())
            {
                int shift = key[keyIndex % key.Length] - 'A';
                result += (char)('A' + (c - 'A' + shift) % 26);
                keyIndex++;
            }
            return result;
        }

        // Giải mã Vigenère
        public static string VigenereDecrypt(string text, string key)
        {
            ValidateVigenereInput(text, key); // Kiểm tra đầu vào trước khi xử lý

            string result = "";
            int keyIndex = 0;
            key = key.ToUpper();
            foreach (char c in text.ToUpper())
            {
                int shift = key[keyIndex % key.Length] - 'A';
                result += (char)('A' + (c - 'A' - shift + 26) % 26);
                keyIndex++;
            }
            return result;
        }
    }

}

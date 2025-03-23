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
        private static void ValidateVigenereInput_43_Nam(string text, string key)
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
        public static string VigenereEncrypt_43_Nam(string text_43_Nam, string key_43_Nam)
        {
            ValidateVigenereInput_43_Nam(text_43_Nam, key_43_Nam); // Kiểm tra đầu vào trước khi xử lý

            string result_43_Nam = "";
            int keyIndex_43_Nam = 0;
            key_43_Nam = key_43_Nam.ToUpper();
            foreach (char c in text_43_Nam.ToUpper())
            {
                int shift_43_Nam = key_43_Nam[keyIndex_43_Nam % key_43_Nam.Length] - 'A';
                result_43_Nam += (char)('A' + (c - 'A' + shift_43_Nam) % 26);
                keyIndex_43_Nam++;
            }
            return result_43_Nam;
        }

        // Giải mã Vigenère
        public static string VigenereDecrypt_43_Nam(string text_43_Nam, string key_43_Nam)
        {
            ValidateVigenereInput_43_Nam(text_43_Nam, key_43_Nam); // Kiểm tra đầu vào trước khi xử lý

            string result_43_Nam = "";
            int keyIndex_43_Nam = 0;
            key_43_Nam = key_43_Nam.ToUpper();
            foreach (char c in text_43_Nam.ToUpper())
            {
                int shift_43_Nam = key_43_Nam[keyIndex_43_Nam % key_43_Nam.Length] - 'A';
                result_43_Nam += (char)('A' + (c - 'A' - shift_43_Nam + 26) % 26);
                keyIndex_43_Nam++;
            }
            return result_43_Nam;
        }
    }

}

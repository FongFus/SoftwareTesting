using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTesting
{
    public class CaesarCipher_45_Phu
    {

        public static string Encrypt_45_Phu(string text, int shift)
        {
            text = text.ToUpper();
            // Chuyển shift âm thành shift dương tương đương
            shift = (shift % 26 + 26) % 26;

            if (shift == 0) return text;

            StringBuilder result = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char encryptedChar = (char)(((c - offset + shift) % 26) + offset);
                    result.Append(encryptedChar);
                }
                else
                {
                    result.Append(c); // Giữ nguyên khoảng trắng và ký tự đặc biệt
                }
            }
            return result.ToString();
        }

        public static string Decrypt_45_Phu(string text, int shift)
        {
            text = text.ToUpper();
            // Chuyển shift âm thành shift dương tương đương
            shift = (shift % 26 + 26) % 26;

            if (shift == 0) return text;

            return Encrypt_45_Phu(text, 26 - shift); // Giải mã bằng cách dịch ngược lại
        }


    }
}

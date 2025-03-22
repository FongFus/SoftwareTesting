using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTesting
{
    public class CaesarCipher_45_Phu
    {
        public const int DefaultN_45_Phu = 26; // Đặt n mặc định là 26
        // Hàm mã hóa Caesar
        public static string Encrypt_45_Phu(string input_45_Phu, int k_45_Phu)
        {
            char[] buffer_45_Phu = input_45_Phu.ToUpper().ToCharArray();

            for (int i_45_Phu = 0; i_45_Phu < buffer_45_Phu.Length; i_45_Phu++)
            {
                if (char.IsLetter(buffer_45_Phu[i_45_Phu]))
                {
                    char offset_45_Phu = 'A';
                    buffer_45_Phu[i_45_Phu] = (char)((buffer_45_Phu[i_45_Phu] - offset_45_Phu + k_45_Phu) % DefaultN_45_Phu + offset_45_Phu);
                }
            }
            return new string(buffer_45_Phu);
        }

        // Hàm giải mã Caesar
        public static string Decrypt_45_Phu(string input_45_Phu, int k_45_Phu)
        {
            return Encrypt_45_Phu(input_45_Phu, DefaultN_45_Phu - k_45_Phu);
        }
    }
}

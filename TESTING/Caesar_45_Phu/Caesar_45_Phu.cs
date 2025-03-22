using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareTesting
{
    public partial class SoftwareTesting : Form
    {
        public SoftwareTesting()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện nút Mã hóa
        private void btnEncryption_45_Phu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs_45_Phu(out int k_45_Phu, out string input_45_Phu)) return;
            txtOutput_45_Phu.Text = CaesarCipher_45_Phu.Encrypt_45_Phu(input_45_Phu, k_45_Phu);
        }

        // Xử lý sự kiện nút Giải mã
        private void btnDecoding_45_Phu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs_45_Phu(out int k_45_Phu, out string input_45_Phu)) return;
            txtOutput_45_Phu.Text = CaesarCipher_45_Phu.Decrypt_45_Phu(input_45_Phu, k_45_Phu);
        }

        // Kiểm tra dữ liệu đầu vào
        public bool ValidateInputs_45_Phu(out int k_45_Phu, out string input_45_Phu)
        {
            input_45_Phu = txtInput_45_Phu.Text;
            if (string.IsNullOrWhiteSpace(input_45_Phu))
            {
                MessageBox.Show("Vui lòng nhập văn bản cần mã hóa hoặc giải mã!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k_45_Phu = 0;
                return false;
            }

            if (!int.TryParse(txtK_45_Phu.Text, out k_45_Phu) || k_45_Phu < 0)
            {
                MessageBox.Show("Vui lòng nhập số nguyên dương cho khóa k!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }

            return true;
        }

        // Sự kiện khi nhấn nút Reset
        private void btnReset_45_Phu_Click(object sender, EventArgs e)
        {
            txtInput_45_Phu.Clear();
            txtK_45_Phu.Clear();
            txtOutput_45_Phu.Clear();
            txtInput_45_Phu.Focus();
        }

        // Sự kiện khi nhấn nút Thoát
        private void btnCancel_45_Phu_Click(object sender, EventArgs e)
        {
            DialogResult result_45_Phu = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result_45_Phu == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

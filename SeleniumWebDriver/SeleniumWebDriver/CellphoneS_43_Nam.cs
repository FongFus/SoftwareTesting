using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver
{
    public partial class CellphoneS_43_Nam : Form
    {
        public CellphoneS_43_Nam()
        {
            InitializeComponent();
        }

        private void btn_SelectStoreLocation_43_Nam_Click(object sender, EventArgs e)
        {
            // Khởi tạo WebDriver (giả sử dùng Chrome)
            IWebDriver driver_45_Phu_43_Nam = new OpenQA.Selenium.Chrome.ChromeDriver();

            try
            {
                // Tạo instance của trang CellphoneSPage_43_45
                CellphoneSPage_43_45 page_43_Nam = new CellphoneSPage_43_45(driver_45_Phu_43_Nam);
                page_43_Nam.SelectStoreLocation_43_Nam("7", "136");

                // Kiểm tra xem cửa hàng mong muốn có hiển thị không
                bool storeExists = page_43_Nam.IsStoreDisplayed_43_Nam("CellphoneS 15C - 18C Đại Lộ Đồng Khởi, P. Phú Khương, TP. Bến Tre");

                if (storeExists)
                {
                    MessageBox.Show("Cửa hàng đã được hiển thị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy cửa hàng mong muốn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng trình duyệt sau khi hoàn thành
                driver_45_Phu_43_Nam.Quit();
            }
        }

        private void btn_SubscribeNewsletter_43_Nam_Click(object sender, EventArgs e)
        {
            string email_43_Nam = txt_Email_43_Nam.Text;
            string phone_43_Nam = txt_Phone_43_Nam.Text;

            if (string.IsNullOrWhiteSpace(email_43_Nam) || string.IsNullOrWhiteSpace(phone_43_Nam))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IWebDriver driver_45_Phu_43_Nam = new OpenQA.Selenium.Chrome.ChromeDriver();
            try
            {
                CellphoneSPage_43_45 page_43_Nam = new CellphoneSPage_43_45(driver_45_Phu_43_Nam);
                page_43_Nam.SubscribeNewsletter(email_43_Nam, phone_43_Nam);

                // Chờ 2 giây trước khi kiểm tra để đảm bảo thông báo có đủ thời gian hiển thị
                System.Threading.Thread.Sleep(2000);

                bool isSubscribed = page_43_Nam.IsSubscriptionSuccessful_43_Nam(
                    "Cảm ơn Quý Khách đã đăng ký. CellphoneS sẽ gửi email kèm mã khuyến mãi nếu hợp lệ trong vòng 24h. Nhớ kiểm tra email bạn nhé!"
                );

                if (isSubscribed)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đăng ký không thành công. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                driver_45_Phu_43_Nam.Quit();
            }
        }
    }
}

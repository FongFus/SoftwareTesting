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
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SeleniumWebDriver
{
    public partial class SearchProducts_45_Phu : Form
    {
        public SearchProducts_45_Phu()
        {
            InitializeComponent();
        }

        private void btn_iP_45_Phu_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo ChromeDriver
                IWebDriver driver_45_Phu = new ChromeDriver();

                // Tạo đối tượng trang CellphoneS
                CellphoneSPage_43_45 cellphonePage_45_Phu = new CellphoneSPage_43_45(driver_45_Phu);

                // Mở trang chủ
                cellphonePage_45_Phu.OpenHomePage_43_45();

                // Tìm kiếm sản phẩm
                cellphonePage_45_Phu.SearchProduct_45_Phu("iPhone 16 Pro Max 256GB");

                // Xác định đường dẫn XPath của sản phẩm
                string productXPath_45_Phu = "//a[@href='/iphone-16-pro-max.html']";

                // Kiểm tra xem sản phẩm có hiển thị không
                if (cellphonePage_45_Phu.IsProductDisplayed_45_Phu(productXPath_45_Phu))
                {
                    // Nhấp vào liên kết sản phẩm
                    cellphonePage_45_Phu.Click_45_Phu(productXPath_45_Phu);

                    // Tùy chọn: Xác minh URL sau khi nhấp
                    string currentUrl_45_Phu = cellphonePage_45_Phu.GetCurrentUrl_45_Phu();
                    MessageBox.Show($"Đã điều hướng đến: {currentUrl_45_Phu}");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }

        }


        private void btn_Price_45_Phu_Click(object sender, EventArgs e)
        {
            IWebDriver driver_45_Phu = null;
            try
            {
                driver_45_Phu = new ChromeDriver();
                CellphoneSPage_43_45 cellphonePage_45_Phu = new CellphoneSPage_43_45(driver_45_Phu);

                // Mở trang chủ
                cellphonePage_45_Phu.OpenHomePage_43_45();
                
                // Mở dropdown khu vực
                cellphonePage_45_Phu.OpenRegionDropdown_45_Phu();
                // Xác định đường dẫn XPath của khu vực
                // Lấy tên khu vực từ TextBox
                string locationName_45_Phu = txtLocation_45_Phu.Text.Trim();
                if (string.IsNullOrEmpty(locationName_45_Phu))
                {
                    MessageBox.Show("Vui lòng nhập tên khu vực vào TextBox!");
                    return;
                }

                // Xác định đường dẫn XPath của khu vực dựa trên tên nhập vào
                string locationXPath_45_Phu = $"//ul[@class='menu-list']//a[contains(normalize-space(),'{locationName_45_Phu}')]";

                // Kiểm tra xem sản phẩm có hiển thị không
                if (cellphonePage_45_Phu.IsProductDisplayed_45_Phu(locationXPath_45_Phu))
                {
                    // Nhấp vào liên kết sản phẩm
                    cellphonePage_45_Phu.Click_45_Phu(locationXPath_45_Phu);

                    
                    MessageBox.Show($"Đã chọn khu vực thành công");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khu vực!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                driver_45_Phu?.Quit(); // Đảm bảo tài nguyên được giải phóng
            }
        }

    }
}
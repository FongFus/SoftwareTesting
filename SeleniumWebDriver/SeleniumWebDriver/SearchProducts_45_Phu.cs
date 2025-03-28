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
            // Tạo một đối tượng driver_45_Phu kiểu IWebDriver để điều khiển trình duyệt Chrome
            IWebDriver driver_45_Phu = new ChromeDriver();

            // Điều hướng trình duyệt đến URL Cellphones
            driver_45_Phu.Navigate().GoToUrl("https://cellphones.com.vn/");

            // Tìm phần tử input có id "inp$earch" trên trang Cellphones (trường tìm kiếm)
            IWebElement element_45_Phu = driver_45_Phu.FindElement(By.Id("inp$earch"));

            // Gõ từ khóa vào ô tìm kiếm
            element_45_Phu.SendKeys("iPhone 16 Pro Max 256GB");

            // Gửi yêu cầu tìm kiếm bằng cách nhấn Enter
            element_45_Phu.SendKeys(OpenQA.Selenium.Keys.Enter);

            // Đợi một khoảng thời gian để trang kết quả tìm kiếm tải xong
            System.Threading.Thread.Sleep(5000); // Chờ 5 giây (có thể điều chỉnh)

            // Tìm liên kết sản phẩm bằng CSS Selector
            //IWebElement productLink_45_Phu = driver_45_Phu.FindElement(By.CssSelector("a[href='https://cellphones.com.vn/iphone-16-pro-max.html']"));
            IWebElement productLink_45_Phu = driver_45_Phu.FindElement(By.XPath("//a[@href='https://cellphones.com.vn/iphone-16-pro-max.html']"));

            // Sử dụng Actions để thực hiện thao tác nhấp chuột
            Actions actions_45_Phu = new Actions(driver_45_Phu);

            // Vòng lặp để kiểm tra và tắt popup cho đến khi nhấp được vào sản phẩm
            bool isClickable_45_Phu = false;
            int maxAttempts_45_Phu = 5; // Số lần thử tối đa để tránh vòng lặp vô hạn
            int attempt_45_Phu = 0;

            while (!isClickable_45_Phu && attempt_45_Phu < maxAttempts_45_Phu)
            {
                try
                {
                    // Thử nhấp vào liên kết sản phẩm
                    productLink_45_Phu.Click();
                    isClickable_45_Phu = true; // Nếu nhấp thành công, thoát vòng lặp
                }
                catch (ElementClickInterceptedException)
                {
                    // Nếu không nhấp được (do popup cản trở), nhấp vào vùng trống để tắt popup
                    try
                    {
                        // Nhấp vào vùng trống (ví dụ: thẻ <body>)
                        IWebElement body_45_Phu = driver_45_Phu.FindElement(By.TagName("body"));
                        actions_45_Phu.MoveToElement(body_45_Phu, 50, 50).Click().Perform(); // Nhấp vào tọa độ (50, 50) trên thẻ <body>
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể nhấp vào vùng trống: " + ex.Message);
                    }

                    // Đợi một chút để popup biến mất
                    System.Threading.Thread.Sleep(1000); // Chờ 1 giây
                    attempt_45_Phu++;
                }
                catch (StaleElementReferenceException)
                {
                    isClickable_45_Phu = false;
                    attempt_45_Phu = 0;
                }
            }

            // Nếu sau số lần thử tối đa mà vẫn không nhấp được, thông báo lỗi
            if (!isClickable_45_Phu)
            {
                throw new Exception("Không thể nhấp vào liên kết sản phẩm sau " + maxAttempts_45_Phu + " lần thử.");
            }


        }
    }
}
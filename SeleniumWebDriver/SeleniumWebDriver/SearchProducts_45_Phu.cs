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

            // Chờ trang tải
            Thread.Sleep(5000); 

            // Tìm liên kết sản phẩm bằng XPath
            IWebElement productLink_45_Phu = driver_45_Phu.FindElement(By.XPath("//a[@href='/iphone-16-pro-max.html']"));
            productLink_45_Phu.Click();

        }
    }
}
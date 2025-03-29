using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeleniumTest_43_45
{
    [TestClass]
    public class SeleniumTest_43_45
    {
        private IWebDriver driver_45_Phu;

        [TestInitialize]
        public void Setup_45_Phu()
        {
            // Khởi tạo WebDriver cho Chrome
            driver_45_Phu = new ChromeDriver();
            driver_45_Phu.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TC_01_Open_Homepage_45_Phu()
        {
            // Mở trang Cellphones
            driver_45_Phu.Navigate().GoToUrl("https://cellphones.com.vn/");

            // Kiểm tra xem tiêu đề trang có chứa "CellphoneS" không
            string pageTitle_45_Phu = driver_45_Phu.Title;
            Assert.IsTrue(pageTitle_45_Phu.Contains("CellphoneS"), "Không thể mở trang chủ.");
        }

        [TestMethod]
        public void TC_02_Search_Product_45_Phu()
        {
            driver_45_Phu.Navigate().GoToUrl("https://cellphones.com.vn/");

            // Tìm ô tìm kiếm bằng ID
            IWebElement searchBox_45_Phu = driver_45_Phu.FindElement(By.Id("inp$earch"));
            searchBox_45_Phu.SendKeys("iPhone 16 Pro Max 256GB");

            // Chờ trang tải kết quả (tạm dùng Sleep cho đơn giản)
            Thread.Sleep(5000);

            // Kiểm tra xem có sản phẩm nào xuất hiện trong kết quả tìm kiếm không
            IWebElement firstProduct_45_Phu = driver_45_Phu.FindElement(By.XPath("//a[@href='/iphone-16-pro-max.html']"));
            Assert.IsNotNull(firstProduct_45_Phu, "Không tìm thấy sản phẩm.");
        }

        [TestMethod]
        public void TC_03_Click_On_Product_Link_45_Phu()
        {
            driver_45_Phu.Navigate().GoToUrl("https://cellphones.com.vn/");

            IWebElement searchBox_45_Phu = driver_45_Phu.FindElement(By.Id("inp$earch"));
            searchBox_45_Phu.SendKeys("iPhone 16 Pro Max 256GB");

            // Đợi trang tải
            Thread.Sleep(5000); 

            // Nhấn vào sản phẩm
            IWebElement productLink_45_Phu = driver_45_Phu.FindElement(By.XPath("//a[@href='/iphone-16-pro-max.html']"));
            productLink_45_Phu.Click();

            // Đợi trang tải
            Thread.Sleep(5000); 

            // Kiểm tra URL có đúng trang sản phẩm không
            string currentUrl_45_Phu = driver_45_Phu.Url;
            Assert.IsTrue(currentUrl_45_Phu.Contains("https://cellphones.com.vn/iphone-16-pro-max.html"), "Không mở đúng trang sản phẩm.");
        }

        [TestCleanup]
        public void Cleanup_45_Phu()
        {
            // Đóng trình duyệt sau mỗi bài kiểm thử
            driver_45_Phu?.Quit();
        }
    }
}

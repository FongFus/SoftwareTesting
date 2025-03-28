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
            // Khởi tạo ChromeDriver thực tế
            driver_45_Phu = new ChromeDriver();
        }

        [TestMethod]
        public void Test_SearchAndClick_Success_45_Phu()
        {
            // Arrange
            driver_45_Phu.Navigate().GoToUrl("https://cellphones.com.vn/");

            // Act
            IWebElement searchInput_45_Phu = driver_45_Phu.FindElement(By.Id("inp$earch"));
            searchInput_45_Phu.SendKeys("iPhone 16 Pro Max 256GB");
            searchInput_45_Phu.SendKeys(Keys.Enter);

            Thread.Sleep(5000); // Chờ trang tải (có thể thay bằng WebDriverWait)

            IWebElement productLink_45_Phu = driver_45_Phu.FindElement(By.XPath("//a[@href='https://cellphones.com.vn/iphone-16-pro-max.html']"));
            productLink_45_Phu.Click();

            // Assert
            string currentUrl_45_Phu = driver_45_Phu.Url;
            Assert.IsTrue(currentUrl_45_Phu.Contains("iphone-16-pro-max"), "Không điều hướng đến trang sản phẩm mong muốn.");
        }

        [TestMethod]
        public void Test_SearchAndClick_WithPopup_45_Phu()
        {
            // Arrange
            driver_45_Phu.Navigate().GoToUrl("https://cellphones.com.vn/");

            // Act
            IWebElement searchInput_45_Phu = driver_45_Phu.FindElement(By.Id("inp$earch"));
            searchInput_45_Phu.SendKeys("iPhone 16 Pro Max 256GB");
            searchInput_45_Phu.SendKeys(Keys.Enter);

            Thread.Sleep(5000); // Chờ trang tải

            IWebElement productLink_45_Phu = driver_45_Phu.FindElement(By.XPath("//a[@href='https://cellphones.com.vn/iphone-16-pro-max.html']"));
            bool isClickable_45_Phu = false;
            int maxAttempts_45_Phu = 5;
            int attempt_45_Phu = 0;

            while (!isClickable_45_Phu && attempt_45_Phu < maxAttempts_45_Phu)
            {
                try
                {
                    productLink_45_Phu.Click();
                    isClickable_45_Phu = true;
                }
                catch (ElementClickInterceptedException)
                {
                    IWebElement body_45_Phu = driver_45_Phu.FindElement(By.TagName("body"));
                    body_45_Phu.Click(); // Nhấp để tắt popup
                    Thread.Sleep(1000); // Chờ popup biến mất
                    attempt_45_Phu++;
                }
            }

            // Assert
            if (isClickable_45_Phu)
            {
                Assert.IsTrue(driver_45_Phu.Url.Contains("iphone-16-pro-max"), "Không điều hướng đến trang sản phẩm sau khi xử lý popup.");
            }
            else
            {
                Assert.Fail("Không thể nhấp vào liên kết sản phẩm sau 5 lần thử.");
            }
        }

        [TestCleanup]
        public void Cleanup_45_Phu()
        {
            // Đóng trình duyệt sau mỗi bài kiểm thử
            driver_45_Phu?.Quit();
        }
    }
}

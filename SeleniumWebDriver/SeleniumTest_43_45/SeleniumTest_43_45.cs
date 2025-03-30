//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;
//using System.Threading;
//using OpenQA.Selenium.Support.UI;
//using System.Linq;

//namespace SeleniumTest_43_45
//{
//    [TestClass]
//    public class SeleniumTest_43_45
//    {
//        private IWebDriver driver_45_Phu_43_Nam;

//        [TestInitialize]
//        public void Setup_45_Phu()
//        {
//            // Khởi tạo WebDriver cho Chrome
//            driver_45_Phu_43_Nam = new ChromeDriver();
//            driver_45_Phu_43_Nam.Manage().Window.Maximize();
//        }

//        [TestMethod]
//        public void TC_01_Open_Homepage_45_Phu()
//        {
//            // Mở trang Cellphones
//            driver_45_Phu_43_Nam.Navigate().GoToUrl("https://cellphones.com.vn/");

//            // Kiểm tra xem tiêu đề trang có chứa "CellphoneS" không
//            string pageTitle_45_Phu = driver_45_Phu_43_Nam.Title;
//            Assert.IsTrue(pageTitle_45_Phu.Contains("CellphoneS"), "Không thể mở trang chủ.");
//        }

//        [TestMethod]
//        public void TC_02_Search_Product_45_Phu()
//        {
//            driver_45_Phu_43_Nam.Navigate().GoToUrl("https://cellphones.com.vn/");

//            // Tìm ô tìm kiếm bằng ID
//            IWebElement searchBox_45_Phu = driver_45_Phu_43_Nam.FindElement(By.Id("inp$earch"));
//            searchBox_45_Phu.SendKeys("iPhone 16 Pro Max 256GB");

//            // Chờ trang tải kết quả (tạm dùng Sleep cho đơn giản)
//            Thread.Sleep(5000);

//            // Kiểm tra xem có sản phẩm nào xuất hiện trong kết quả tìm kiếm không
//            IWebElement firstProduct_45_Phu = driver_45_Phu_43_Nam.FindElement(By.XPath("//a[@href='/iphone-16-pro-max.html']"));
//            Assert.IsNotNull(firstProduct_45_Phu, "Không tìm thấy sản phẩm.");
//        }

//        [TestMethod]
//        public void TC_03_Click_On_Product_Link_45_Phu()
//        {
//            driver_45_Phu_43_Nam.Navigate().GoToUrl("https://cellphones.com.vn/");

//            IWebElement searchBox_45_Phu = driver_45_Phu_43_Nam.FindElement(By.Id("inp$earch"));
//            searchBox_45_Phu.SendKeys("iPhone 16 Pro Max 256GB");

//            // Đợi trang tải
//            Thread.Sleep(5000);

//            // Nhấn vào sản phẩm
//            IWebElement productLink_45_Phu = driver_45_Phu_43_Nam.FindElement(By.XPath("//a[@href='/iphone-16-pro-max.html']"));
//            productLink_45_Phu.Click();

//            // Đợi trang tải
//            Thread.Sleep(5000);

//            // Kiểm tra URL có đúng trang sản phẩm không
//            string currentUrl_45_Phu = driver_45_Phu_43_Nam.Url;
//            Assert.IsTrue(currentUrl_45_Phu.Contains("https://cellphones.com.vn/iphone-16-pro-max.html"), "Không mở đúng trang sản phẩm.");
//        }

//        [TestMethod]
//        public void TC_04_Select_Store_Location_43_Nam()
//        {
//            driver_45_Phu_43_Nam.Navigate().GoToUrl("https://cellphones.com.vn/");

//            WebDriverWait wait = new WebDriverWait(driver_45_Phu_43_Nam, TimeSpan.FromSeconds(10));

//            // Click vào "Cửa hàng gần bạn"
//            IWebElement storeButton_43_Nam = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@class, 'button__link-address')]")));
//            storeButton_43_Nam.Click();

//            // Chuyển sang tab mới nếu có
//            // Đợi cho đến khi có nhiều hơn 1 tab mở ra
//            wait.Until(drv => drv.WindowHandles.Count > 1);

//            // Lấy danh sách tất cả tab
//            var allTabs = driver_45_Phu_43_Nam.WindowHandles;

//            // Chuyển sang tab mới (phần tử cuối cùng trong danh sách)
//            driver_45_Phu_43_Nam.SwitchTo().Window(allTabs[allTabs.Count - 1]);


//            // Chờ dropdown xuất hiện và chọn tỉnh Bến Tre
//            IWebElement provinceDropdown_43_Nam = wait.Until(drv => drv.FindElement(By.Id("boxSearchProvince")));
//            provinceDropdown_43_Nam.Click();
//            provinceDropdown_43_Nam.FindElement(By.CssSelector("option[value='7']")).Click();

//            // Chờ dropdown quận/huyện xuất hiện và chọn Thành phố Bến Tre
//            IWebElement districtDropdown_43_Nam = wait.Until(drv => drv.FindElement(By.Id("boxSearchDistrict")));
//            districtDropdown_43_Nam.Click();
//            districtDropdown_43_Nam.FindElement(By.CssSelector("option[value='136']")).Click();

//            // Kiểm tra giá trị đã chọn
//            string selectedProvince_43_Nam = provinceDropdown_43_Nam.GetAttribute("value");
//            string selectedDistrict_43_Nam = districtDropdown_43_Nam.GetAttribute("value");

//            Assert.AreEqual("7", selectedProvince_43_Nam, "Không chọn đúng tỉnh Bến Tre.");
//            Assert.AreEqual("136", selectedDistrict_43_Nam, "Không chọn đúng Thành phố Bến Tre.");
//            // Tìm tất cả các cửa hàng trong phần tử boxMap-stores
//            IWebElement storesContainer_43_Nam = wait.Until(drv => drv.FindElement(By.ClassName("boxMap-stores")));
//            var storeElements_43_Nam = storesContainer_43_Nam.FindElements(By.ClassName("boxMap-store-address"));

//            // Tên cửa hàng cần tìm
//            string expectedStoreName_43_Nam = "CellphoneS 15C - 18C Đại Lộ Đồng Khởi, P. Phú Khương, TP. Bến Tre";

//            // Kiểm tra xem cửa hàng có tồn tại không
//            bool storeFound_43_Nam = storeElements_43_Nam.Any(store => store.Text.Trim().Equals(expectedStoreName_43_Nam, StringComparison.OrdinalIgnoreCase));

//            // Xác nhận kết quả
//            Assert.IsTrue(storeFound_43_Nam, "Không tìm thấy cửa hàng mong muốn.");
//        }


//        [TestMethod]
//        public void TC_05_Subscribe_Newsletter_43_Nam()
//        {
//            driver_45_Phu_43_Nam.Navigate().GoToUrl("https://cellphones.com.vn/");
//            WebDriverWait wait = new WebDriverWait(driver_45_Phu_43_Nam, TimeSpan.FromSeconds(20));

//            // Scroll xuống cuối trang để tìm ô nhập email
//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver_45_Phu_43_Nam;
//            IWebElement emailInput = wait.Until(drv => drv.FindElement(By.Id("inputEmail")));
//            js.ExecuteScript("arguments[0].scrollIntoView();", emailInput);

//            // Nhập email
//            emailInput.SendKeys("testemail@gmail.com");

//            // Nhập số điện thoại
//            IWebElement phoneInput = wait.Until(drv => drv.FindElement(By.Id("inputPhone")));
//            phoneInput.SendKeys("0887654356");

//            // Click vào nút đăng ký
//            IWebElement subscribeButton = wait.Until(drv => drv.FindElement(By.CssSelector(".group-btn .subscriber-form-submit")));
//            subscribeButton.Click();

//            // Đợi thông báo xuất hiện
//            IWebElement successMessage = wait.Until(drv => drv.FindElement(By.CssSelector(".toasted.toasted-primary.success")));

//            // Kiểm tra nội dung thông báo
//            string expectedMessage = "Cảm ơn Quý Khách đã đăng ký. CellphoneS sẽ gửi email kèm mã khuyến mãi nếu hợp lệ trong vòng 24h. Nhớ kiểm tra email bạn nhé!";
//            string actualMessage = successMessage.Text.Trim();
//            Assert.AreEqual(expectedMessage, actualMessage, "Thông báo đăng ký không đúng.");
//        }




//        [TestCleanup]
//        public void Cleanup_45_Phu()
//        {
//            // Đóng trình duyệt sau mỗi bài kiểm thử
//            driver_45_Phu_43_Nam?.Quit();
//        }
//    }
//}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver;

namespace SeleniumTest_43_45
{
    [TestClass]
    public class SeleniumTest_45_Phu
    {
        private IWebDriver driver_43_45;
        private CellphoneSPage_43_45 page_43_45;

        [TestInitialize]
        public void Setup_43_45()
        {
            driver_43_45 = new ChromeDriver();
            driver_43_45.Manage().Window.Maximize();
            page_43_45 = new CellphoneSPage_43_45(driver_43_45);
        }

        [TestMethod]
        public void TC_01_Open_Homepage_45_Phu()
        {
            page_43_45.OpenHomePage_43_45();
            string pageTitle_43_Nam = page_43_45.GetPageTitle_45_Phu();
            Assert.IsTrue(pageTitle_43_Nam.Contains("CellphoneS"), "Không thể mở trang chủ.");

            Cleanup_43_45();
        }

        [TestMethod]
        public void TC_02_Search_Product_45_Phu()
        {
            page_43_45.OpenHomePage_43_45();
            page_43_45.SearchProduct_45_Phu("iPhone 16 Pro Max 256GB");
            bool isProductFound_43_Nam = page_43_45.IsProductDisplayed_45_Phu("//a[@href='/iphone-16-pro-max.html']");
            Assert.IsTrue(isProductFound_43_Nam, "Không tìm thấy sản phẩm.");

            Cleanup_43_45();
        }

        [TestMethod]
        public void TC_03_Click_On_Product_Link_45_Phu()
        {
            page_43_45.OpenHomePage_43_45();
            page_43_45.SearchProduct_45_Phu("iPhone 16 Pro Max 256GB");
            page_43_45.ClickOnProduct_45_Phu("//a[@href='/iphone-16-pro-max.html']");
            string currentUrl_43_Nam = page_43_45.GetCurrentUrl_45_Phu();
            Assert.IsTrue(currentUrl_43_Nam.Contains("https://cellphones.com.vn/iphone-16-pro-max.html"), "Không mở đúng trang sản phẩm.");

            Cleanup_43_45();
        }

        [TestMethod]
        public void TC_04_Select_Store_Location_43_Nam()
        {
            page_43_45.SelectStoreLocation_43_Nam("7", "136");
            bool storeExists = page_43_45.IsStoreDisplayed_43_Nam("CellphoneS 15C - 18C Đại Lộ Đồng Khởi, P. Phú Khương, TP. Bến Tre");
            Assert.IsTrue(storeExists, "Không tìm thấy cửa hàng mong muốn.");

            Cleanup_43_45();
        }

        [TestMethod]
        public void TC_05_Subscribe_Newsletter_43_Nam()
        {
            page_43_45.OpenHomePage_43_45();
            page_43_45.SubscribeNewsletter("testemail@gmail.com", "0887654356");
            string expectedMessage = "Cảm ơn Quý Khách đã đăng ký. CellphoneS sẽ gửi email kèm mã khuyến mãi nếu hợp lệ trong vòng 24h. Nhớ kiểm tra email bạn nhé!";
            Assert.IsTrue(page_43_45.IsSubscriptionSuccessful_43_Nam(expectedMessage), "Thông báo đăng ký không đúng.");

            Cleanup_43_45();
        }


        public void Cleanup_43_45()
        {
            driver_43_45.Quit();
        }
    }
}

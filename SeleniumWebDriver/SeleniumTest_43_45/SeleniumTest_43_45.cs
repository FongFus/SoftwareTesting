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
            string pageTitle_45_Phu = page_43_45.GetPageTitle_45_Phu();
            Assert.IsTrue(pageTitle_45_Phu.Contains("CellphoneS"), "Không thể mở trang chủ.");

            Cleanup_43_45();
        }

        [TestMethod]
        public void TC_02_Search_Product_45_Phu()
        {
            page_43_45.OpenHomePage_43_45();
            page_43_45.SearchProduct_45_Phu("iPhone 16 Pro Max 256GB");
            bool isProductFound_45_Phu = page_43_45.IsProductDisplayed_45_Phu("//a[@href='/iphone-16-pro-max.html']");
            Assert.IsTrue(isProductFound_45_Phu, "Không tìm thấy sản phẩm.");

            Cleanup_43_45();
        }

        [TestMethod]
        public void TC_03_Click_On_Product_Link_45_Phu()
        {
            page_43_45.OpenHomePage_43_45();
            page_43_45.SearchProduct_45_Phu("iPhone 16 Pro Max 256GB");
            page_43_45.Click_45_Phu("//a[@href='/iphone-16-pro-max.html']");
            string currentUrl_45_Phu = page_43_45.GetCurrentUrl_45_Phu();
            Assert.IsTrue(currentUrl_45_Phu.Contains("https://cellphones.com.vn/iphone-16-pro-max.html"), "Không mở đúng trang sản phẩm.");

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
            Assert.IsTrue(page_43_45.IsSubscriptionSuccessful_43_Nam(), "Đăng ký thất bại.");

            Cleanup_43_45();
        }

        [TestMethod]
        public void TC_06_Choose_Location_45_Phu()
        {
            page_43_45.OpenHomePage_43_45();

            // Lấy khu vực mặc định trước khi thay đổi
            string defaultRegion_45_Phu = page_43_45.GetCurrentRegion_45_Phu();
            Assert.IsFalse(string.IsNullOrEmpty(defaultRegion_45_Phu), "Không tìm thấy khu vực mặc định.");

            page_43_45.OpenRegionDropdown_45_Phu();

            // Xác định XPath của khu vực "An Giang" trong dropdown
            string locationXPath_45_Phu = "//ul[@class='menu-list']//a[contains(normalize-space(),'An Giang')]";

            page_43_45.Click_45_Phu(locationXPath_45_Phu);

            // Lấy khu vực hiện tại sau khi chọn
            string selectedRegion_45_Phu = page_43_45.GetCurrentRegion_45_Phu();

            // Kiểm tra xem khu vực đã thay đổi thành "An Giang" chưa
            Assert.AreEqual("An Giang", selectedRegion_45_Phu,
                "Khu vực 'An Giang' không được chọn hoặc hiển thị đúng.");

            Cleanup_43_45();
        }

        [TestMethod]
        public void TC_07_Find_Product_by_Brand_and_List_by_Name_43_Nam()
        {
            // Tên sản phẩm để tìm kiếm
            string productName_43_Nam = "Xiaomi Redmi Note 11 Pro 5G";

            // Gọi hàm để nhấp vào thương hiệu từ tên sản phẩm
            page_43_45.FindProductbyBrandandListByName_43_Nam(productName_43_Nam);
            
            Assert.IsTrue(page_43_45.IsProductPageLoadedCorrectly_43_Nam(productName_43_Nam), "Sản phẩm tìm thấy không đúng.");

            Cleanup_43_45();
        }

        public void Cleanup_43_45()
        {
            driver_43_45.Quit();
        }
    }
}

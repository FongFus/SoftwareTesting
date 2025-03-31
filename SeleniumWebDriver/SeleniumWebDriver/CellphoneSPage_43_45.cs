using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace SeleniumWebDriver
{
    public class CellphoneSPage_43_45
    {
        private IWebDriver driver_45_Phu_43_Nam;
        private WebDriverWait wait_43_45;

        public CellphoneSPage_43_45(IWebDriver driver_43_45)
        {
            this.driver_45_Phu_43_Nam = driver_43_45;
            this.wait_43_45 = new WebDriverWait(driver_43_45, TimeSpan.FromSeconds(10));
        }

        public void OpenHomePage_43_45()
        {
            driver_45_Phu_43_Nam.Navigate().GoToUrl("https://cellphones.com.vn/");
            driver_45_Phu_43_Nam.Manage().Window.Maximize();
        }

        public string GetPageTitle_45_Phu()
        {
            return driver_45_Phu_43_Nam.Title;
        }

        public void SearchProduct_45_Phu(string productName_45_Phu)
        {
            IWebElement searchBox_45_Phu = driver_45_Phu_43_Nam.FindElement(By.Id("inp$earch"));
            searchBox_45_Phu.SendKeys(productName_45_Phu);
            Thread.Sleep(5000);
        }

        public bool IsProductDisplayed_45_Phu(string productXpath_45_Phu)
        {
            try
            {
                return driver_45_Phu_43_Nam.FindElement(By.XPath(productXpath_45_Phu)) != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Click_45_Phu(string productXpath_45_Phu)
        {
            IWebElement productLink_45_Phu = driver_45_Phu_43_Nam.FindElement(By.XPath(productXpath_45_Phu));
            productLink_45_Phu.Click();
            Thread.Sleep(5000);
        }

        public string GetCurrentUrl_45_Phu()
        {
            return driver_45_Phu_43_Nam.Url;
        }

        public void SelectStoreLocation_43_Nam(string provinceValue_43_Nam, string districtValue_45_Phu)
        {
            OpenHomePage_43_45();

            IWebElement storeButton_43_Nam = wait_43_45.Until(drv => drv.FindElement(By.XPath("//a[contains(@class, 'button__link-address')]")));
            storeButton_43_Nam.Click();

            wait_43_45.Until(drv => drv.WindowHandles.Count > 1);
            driver_45_Phu_43_Nam.SwitchTo().Window(driver_45_Phu_43_Nam.WindowHandles.Last());

            IWebElement provinceDropdown_43_Nam = wait_43_45.Until(drv => drv.FindElement(By.Id("boxSearchProvince")));
            provinceDropdown_43_Nam.Click();
            provinceDropdown_43_Nam.FindElement(By.CssSelector($"option[value='{provinceValue_43_Nam}']")).Click();

            IWebElement districtDropdown_43_Nam = wait_43_45.Until(drv => drv.FindElement(By.Id("boxSearchDistrict")));
            districtDropdown_43_Nam.Click();
            districtDropdown_43_Nam.FindElement(By.CssSelector($"option[value='{districtValue_45_Phu}']")).Click();
        }


        public bool IsStoreDisplayed_43_Nam(string expectedStoreName_43_Nam)
        {
            IWebElement storesContainer_43_Nam = wait_43_45.Until(drv => drv.FindElement(By.ClassName("boxMap-stores")));
            var storeElements_43_Nam = storesContainer_43_Nam.FindElements(By.ClassName("boxMap-store-address"));

            return storeElements_43_Nam.Any(store => store.Text.Trim().Equals(expectedStoreName_43_Nam, StringComparison.OrdinalIgnoreCase));
        }

        public void SubscribeNewsletter(string email_43_Nam, string phoneNumber_43_Nam)
        {
            OpenHomePage_43_45();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver_45_Phu_43_Nam;
            IWebElement emailInput = wait_43_45.Until(drv => drv.FindElement(By.Id("inputEmail")));
            js.ExecuteScript("arguments[0].scrollIntoView();", emailInput);

            emailInput.SendKeys(email_43_Nam);

            IWebElement phoneInput_43_Nam = wait_43_45.Until(drv => drv.FindElement(By.Id("inputPhone")));
            phoneInput_43_Nam.SendKeys(phoneNumber_43_Nam);

            IWebElement subscribeButton_43_Nam = wait_43_45.Until(drv => drv.FindElement(By.CssSelector(".group-btn .subscriber-form-submit")));
            subscribeButton_43_Nam.Click();
        }
        public bool IsSubscriptionSuccessful_43_Nam(string expectedMessage_43_Nam)
        {
            IWebElement successMessage_43_Nam = wait_43_45.Until(drv => drv.FindElement(By.CssSelector(".toasted.toasted-primary.success")));
            return successMessage_43_Nam.Text.Trim().Equals(expectedMessage_43_Nam);
        }

        public void Cleanup_43_45()
        {
            driver_45_Phu_43_Nam.Quit();
        }

        
        public void OpenRegionDropdown_45_Phu()
        {
            IWebElement regionButton_45_Phu = wait_43_45.Until(drv =>
            {
                IWebElement element_45_Phu = drv.FindElement(By.CssSelector(".box-local-store.button__change-province"));
                if (element_45_Phu.Displayed && element_45_Phu.Enabled)
                    return element_45_Phu;
                return null;
            });
            regionButton_45_Phu.Click();
        }

        public string GetCurrentRegion_45_Phu()
        {
            IWebElement regionElement_45_Phu = wait_43_45.Until(drv =>
            {
                IWebElement element_45_Phu = drv.FindElement(By.CssSelector(".box-local-store.button__change-province"));
                if (element_45_Phu.Displayed && element_45_Phu.Enabled)
                    return element_45_Phu;
                return null;
            });

            // Lấy nội dung của phần tử <span> bên trong (chứa tên khu vực)
            IWebElement regionSpan_45_Phu = regionElement_45_Phu.FindElement(By.TagName("span"));
            return regionSpan_45_Phu.Text.Trim();
        }

        public void FindProductbyBrandandListByName_43_Nam(string productName_43_Nam)
        {
            // Mở trang chủ
            OpenHomePage_43_45();

            // Danh sách hãng điện thoại
            List<string> brands_43_Nam = new List<string> { "Apple", "Samsung", "Xiaomi", "OPPO", "vivo", "realme", "ASUS", "TECNO", "Nokia", "Infinix" };

            // Tìm hãng từ tên sản phẩm
            string brand_43_Nam;
            if (productName_43_Nam.IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                brand_43_Nam = "Apple";
            }
            else
            {
                brand_43_Nam = brands_43_Nam.FirstOrDefault(b => productName_43_Nam.IndexOf(b, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (string.IsNullOrEmpty(brand_43_Nam))
            {
                throw new Exception("Không tìm thấy hãng phù hợp trong danh sách.");
            }

            // Đợi phần danh sách thương hiệu hiển thị
            IWebElement brandList_43_Nam = wait_43_45.Until(drv => drv.FindElement(By.ClassName("list-related-tag")));

            // Tìm thẻ <a> chứa tên hãng
            IWebElement brandLink_43_Nam = brandList_43_Nam.FindElements(By.TagName("a"))
                                                .FirstOrDefault(a => a.Text.Equals(brand_43_Nam, StringComparison.OrdinalIgnoreCase));

            if (brandLink_43_Nam == null)
            {
                throw new Exception("Không tìm thấy liên kết thương hiệu phù hợp.");
            }

            // Click vào liên kết thương hiệu
            brandLink_43_Nam.Click();


            // Đợi danh sách sản phẩm tải xong
            wait_43_45.Until(drv => drv.FindElement(By.ClassName("block-product-list-filter")));

            bool productFound_43_Nam = false;

            while (!productFound_43_Nam)
            {
                // Lấy danh sách sản phẩm trong block-product-list-filter
                IWebElement productList_43_Nam = driver_45_Phu_43_Nam.FindElement(By.ClassName("block-product-list-filter"));
                var products_43_Nam = productList_43_Nam.FindElements(By.ClassName("product-item"));

                foreach (var product_43_Nam in products_43_Nam)
                {
                    try
                    {
                        string productNameText_43_Nam = product_43_Nam.FindElement(By.CssSelector(".product__name h3")).Text;
                        if (productNameText_43_Nam.Equals(productName_43_Nam, StringComparison.OrdinalIgnoreCase))
                        {
                            product_43_Nam.FindElement(By.ClassName("product__link")).Click();
                            productFound_43_Nam = true;
                            Console.WriteLine($"Tìm thấy sản phẩm: {productName_43_Nam}");
                            Thread.Sleep(2000);
                            break;
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        continue; // Bỏ qua nếu sản phẩm không có thông tin phù hợp
                    }
                }

                if (!productFound_43_Nam)
                {
                    try
                    {
                        var showMoreButton = driver_45_Phu_43_Nam.FindElement(By.ClassName("button__show-more-product"));
                        if (showMoreButton.Displayed)
                        {
                            showMoreButton.Click();
                            Thread.Sleep(2000); // Đợi trang tải thêm sản phẩm
                        }
                        else
                        {
                            break; // Không còn nút "Xem thêm" để nhấn
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        break; // Không tìm thấy nút "Xem thêm", dừng vòng lặp
                    }
                }
            }

            if (!productFound_43_Nam)
            {
                Cleanup_43_45();
                throw new Exception($"Không tìm thấy sản phẩm: {productName_43_Nam}");
                
            }
        }


        public bool IsProductPageLoadedCorrectly_43_Nam(string productName_43_Nam)
        {
            try
            {
                // Đợi cho phần chứa tên sản phẩm xuất hiện
                IWebElement productTitleElement_43_Nam = wait_43_45.Until(drv =>
                    drv.FindElement(By.CssSelector(".box-product-name h1")));

                // Lấy nội dung văn bản trong thẻ <h1>
                string productTitle_43_Nam = productTitleElement_43_Nam.Text.Trim();

                // Kiểm tra xem tên sản phẩm có chứa productName không (bỏ qua chữ hoa/thường)
                return productTitle_43_Nam.IndexOf(productName_43_Nam, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            catch (NoSuchElementException)
            {
                return false; // Nếu không tìm thấy phần tử, trả về false
            }
        }

    }
}

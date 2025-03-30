using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

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

    }
}

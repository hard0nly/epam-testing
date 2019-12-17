using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestAutomation.Pages
{
    class CarBooking
    {
        private IWebDriver driver { get; set; }

        [FindsBy(How = How.Name, Using = "quantity")]
        private IWebElement quantityDaysinput { get; set; }

        [FindsBy(How = How.Id, Using = "button-cart")]
        private IWebElement orderButton { get; set; }

        [FindsBy(How = How.Id, Using = "cart-total")]
        private IWebElement cartIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href = 'https://rent-cars.by/index.php?route=checkout/onepagecheckout']")]
        private IWebElement checkoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title = 'Удалить']")]
        private IWebElement removeButton { get; set; }

        public CarBooking(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public CarBooking InputDaysQuantity(int daysQuantity)
        {
            quantityDaysinput.Clear();
            quantityDaysinput.SendKeys(daysQuantity.ToString());
            return this;
        }

        public CarBooking ClickOrderButton()
        {
            orderButton.Click();
            return this;
        }

        public string GetCartTotalText()
        {
            return cartIcon.Text;
        }

        public string GetAlertText()
        {
            return new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.AlertIsPresent()).Text;
        }

        public CarBooking GoToCheckout()
        {
            cartIcon.Click();
            checkoutButton.Click();
            return this;
        }

        public CarBooking OpenCartPreview()
        {
            cartIcon.Click();
            return this;
        }

        public CarBooking RemoveBooking()
        {
            removeButton.Click();
            return this;
        }
    }
}

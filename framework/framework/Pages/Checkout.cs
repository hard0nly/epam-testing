using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using TestAutomation.Models;

namespace TestAutomation.Pages
{
    class Checkout
    {
        private IWebDriver driver { get; set; }

        [FindsBy(How = How.Id, Using = "ajax-button-confirm")]
        private IWebElement checkoutButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "error")]
        private IWebElement errorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "firstname-ch")]
        private IWebElement nameField { get; set; }

        [FindsBy(How = How.Id, Using = "telephone-ch")]
        private IWebElement phoneField { get; set; }

        [FindsBy(How = How.Id, Using = "city-ch")]
        private IWebElement cityField { get; set; }

        [FindsBy(How = How.Id, Using = "date_from_field")]
        private IWebElement dateFromField { get; set; }

        [FindsBy(How = How.Id, Using = "date_to_field")]
        private IWebElement dateToField { get; set; }

        public Checkout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public Checkout SubmitCheckout()
        {
            checkoutButton.Click();
            return this;
        }

        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }

        public Checkout WriteBookingInfo(BookingInfo bookingInfo)
        {
            nameField.SendKeys(bookingInfo.Name);
            phoneField.SendKeys(bookingInfo.Phone);
            cityField.SendKeys(bookingInfo.City);
            dateFromField.SendKeys(bookingInfo.DateFrom);
            dateToField.SendKeys(bookingInfo.DateTo);
            return this;
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomation.Pages
{
    class Contacts
    {
        [FindsBy(How = How.XPath, Using = "//input[@value = 'Применить']")]
        private IWebElement applyButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.text-danger")]
        private IWebElement dangerMessage { get; set; }

        public Contacts(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public Contacts SendMessage()
        {
            applyButton.Click();
            return this;
        }

        public string GetDangerMessage()
        {
            return dangerMessage.Text;
        }
    }
}

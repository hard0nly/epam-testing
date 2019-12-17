using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomation.Pages
{
    class Reviews
    {

        [FindsBy(How = How.Id, Using = "button-review")]
        private IWebElement sendReviewButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-danger")]
        private IWebElement dangerMessage { get; set; }

        public Reviews(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public Reviews SendReview()
        {
            sendReviewButton.Click();
            return this;
        }

        public string GetDangerMessageText()
        {
            return dangerMessage.Text;
        }

    }
}

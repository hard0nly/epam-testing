using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace page_object.Pages
{
    class Reviews
    {

        [FindsBy(How = How.Id, Using = "button-review")]
        private IWebElement sendReviewButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-danger")]
        private IWebElement dangerMessage { get; set; }

        public Reviews(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
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

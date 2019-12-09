using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace page_object.Pages
{
    class HomePage
    {

        [FindsBy(How = How.XPath, Using = "//a[@href = '/otzyvy/']")]
        private IWebElement reviewTab { get; set; }

        [FindsBy(How = How.Id, Using = "form-language")]
        private IWebElement languageForm { get; set; }

        [FindsBy(How = How.Name, Using = "en-gb")]
        private IWebElement enLangButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href = 'https://rent-cars.by/biznes-klass/']")]
        private IWebElement businessClassButton { get; set; }

        public HomePage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public HomePage ChangeToEnglishLanguage()
        {
            languageForm.Click();
            enLangButton.Click();
            return this;
        }

        public string GetReviewTabText()
        {
            return reviewTab.Text;
        }

        public HomePage ClickReviewTab()
        {
            reviewTab.Click();
            return this;
        }

        public HomePage ChooseBusinessClass()
        {
            businessClassButton.Click();
            return this;
        }

    }
}

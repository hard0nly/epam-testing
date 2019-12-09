using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace page_object.Pages
{
    class BusinessClass
    {

        [FindsBy(How = How.ClassName, Using = "caption-title")]
        private IWebElement firstBusinessCar { get; set; }

        public BusinessClass(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public BusinessClass SelectFirstBusinessCar()
        {
            firstBusinessCar.Click();
            return this;
        }

    }
}

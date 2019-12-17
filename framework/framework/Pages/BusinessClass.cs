using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestAutomation.Models;

namespace TestAutomation.Pages
{
    class BusinessClass
    {

        [FindsBy(How = How.ClassName, Using = "caption-title")]
        private IWebElement firstBusinessCar { get; set; }

        [FindsBy(How = How.Id, Using = "input-sort")]
        private IWebElement sortSelection { get; set; }

        [FindsBy(How = How.ClassName, Using = "price")]
        private IWebElement firstBusinessCarPrice { get; set; }

        public BusinessClass(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public BusinessClass SelectFirstBusinessCar()
        {
            firstBusinessCar.Click();
            return this;
        }

        public BusinessClass SelectSortByPriceFromBiggerToSmaller()
        {
            new SelectElement(sortSelection).SelectByText(WarningsAndLetterings.PriceFromBiggerToSmaller);
            return this;
        }

        public string GetFirstBusinessCarPriceText()
        {
            return firstBusinessCarPrice.Text;
        }

    }
}

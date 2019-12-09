using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace page_object.Pages
{
    class CarBooking
    {

        [FindsBy(How = How.Name, Using = "quantity")]
        private IWebElement quantityDaysinput { get; set; }

        [FindsBy(How = How.Id, Using = "button-cart")]
        private IWebElement orderButton { get; set; }

        [FindsBy(How = How.Id, Using = "cart-total")]
        private IWebElement cartTotalInfo { get; set; }

        public CarBooking(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
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
            return cartTotalInfo.Text;
        }
    }
}

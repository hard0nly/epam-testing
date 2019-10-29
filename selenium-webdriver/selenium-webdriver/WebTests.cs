using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace selenium_webdriver
{
    [TestFixture]
    public class WebTests
    {
        public IWebDriver webDriver;

        [SetUp]
        public void StartBrowserAndGoToTheSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("https://rent-cars.by");
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }

        [Test]
        // testCase2
        public void EmptyReviewSend()
        { 
            var reviewTab = webDriver.FindElement(By.XPath("//a[@href = '/otzyvy/']"));
            reviewTab.Click();

            var sendReviewButton = webDriver.FindElement(By.XPath("//button[@id = 'button-review']"));
            sendReviewButton.Click();

            var dangerMessage = webDriver.FindElement(By.XPath("//div[@class = 'alert alert-danger']"));
            Assert.AreEqual("Пожалуйста, выберите оценку!", dangerMessage.Text);
        }

        [Test]
        // testCase5
        public void ReservationWithoutEnteringInformation()
        {
            var catalogTab = webDriver.FindElement(By.XPath("//a[@href = 'https://rent-cars.by/index.php?route=']"));
            catalogTab.Click();

            var businessClassButton = webDriver.FindElement(By.XPath("//div[@class = 'category-layout col-lg-4 col-md-4 col-sm-6 col-xs-6']"));
            businessClassButton.Click();

            var firstBusinessCar = webDriver.FindElement(By.XPath("//div[@class ='product-layout product-grid col-lg-4 col-md-4 col-sm-6 col-xs-12']"));
            firstBusinessCar.Click();

            var inputDaysQuantity = webDriver.FindElement(By.XPath("//input[@name = 'quantity']"));
            inputDaysQuantity.Clear();
            inputDaysQuantity.SendKeys("2");

            var ordersQuantityBefore = webDriver.FindElement(By.XPath("//span[@id = 'cart-total']")).Text;

            var orderButton = webDriver.FindElement(By.XPath("//button[@id ='button-cart']"));
            orderButton.Click();

            var ordersQuantityAfter = webDriver.FindElement(By.XPath("//span[@id = 'cart-total']")).Text;
            Assert.AreNotEqual(inputDaysQuantity, ordersQuantityAfter);
        }

        [Test]
        // testCase7
        public void LanguageChange()
        {
            var languageForm = webDriver.FindElement(By.XPath("//form[@id = 'form-language']"));
            languageForm.Click();

            var enLangButton = webDriver.FindElement(By.XPath("//button[@name = 'en-gb']"));
            enLangButton.Click();

            var reviewTab = webDriver.FindElement(By.XPath("//a[@href = '/otzyvy/']"));
            Assert.AreEqual("REVIEWS", reviewTab.Text);
        }
    }
}

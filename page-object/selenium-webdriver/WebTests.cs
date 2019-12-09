using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using page_object.Pages;

namespace page_object
{
    [TestFixture]
    public class WebTests
    {

        private IWebDriver Browser;
        private static string HomePageUrl = "https://rent-cars.by/";

        [SetUp]
        public void OpenBrouserWithSite()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Browser.Navigate().GoToUrl(HomePageUrl);
        }

        [TearDown]
        public void QuitDriver()
        {
            if (Browser != null)
                Browser.Quit();
        }

        [Test]
        // testCase2
        public void SendEmptyReview()
        {
            HomePage homePage = new HomePage(Browser)
                .ClickReviewTab();

            Reviews reviews = new Reviews(Browser)
                .SendReview();

            Assert.AreEqual("Пожалуйста, выберите оценку!", reviews.GetDangerMessageText());
        }

        [Test]
        // testCase5
        public void CountNumberOfServices()
        {
            HomePage homePage = new HomePage(Browser)
                .ChooseBusinessClass();

            BusinessClass businessClass = new BusinessClass(Browser)
                .SelectFirstBusinessCar();

            CarBooking carBooking = new CarBooking(Browser)
                .InputDaysQuantity(2)
                .ClickOrderButton();

            Assert.AreNotEqual("0 0.00 BYN", carBooking.GetCartTotalText());
        }

        [Test]
        // testCase7
        public void TranslateToOtherLanguage()
        {
            HomePage homePage = new HomePage(Browser)
                .ChangeToEnglishLanguage();

            Assert.AreEqual("REVIEWS", homePage.GetReviewTabText());
        }

    }
}

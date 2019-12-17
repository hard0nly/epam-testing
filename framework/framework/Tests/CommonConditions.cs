using TestAutomation.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using TestAutomation.Utils;
using TestAutomation.Logging;

namespace TestAutomation
{
    public class CommonConditions
    {
        protected IWebDriver Driver { get; set; }
        protected string HomePageUrl = "https://rent-cars.by/";

        [SetUp]
        public void StartBrowserAndGoToTheSite()
        {
            Logger.InitLogger();
            Logger.Log.Warn("Start driver initializing.");
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl(HomePageUrl);
            Logger.Log.Info("Driver initialized.");
        }

        [TearDown]
        public void ClearDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Logger.Log.Error("Test failed. Taking screenshot.");
                ScreenshotCreater.SaveScreenShot(Driver);
                Logger.Log.Info("Took screenshot.");
            }

            Logger.Log.Warn("Driver is closing.");
            DriverSingleton.CloseDriver();
            Logger.Log.Info("Driver closed.");
        }
    }
}

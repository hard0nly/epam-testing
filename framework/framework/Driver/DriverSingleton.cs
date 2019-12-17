using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;

namespace TestAutomation.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                    case "firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                }
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(20));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}

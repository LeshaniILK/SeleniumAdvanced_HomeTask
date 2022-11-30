using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvanced_HomeTask_PageObject
{
    internal class WebDriver
    {
        private static IWebDriver? driver;

        private WebDriver(IWebDriver _driver)
        {
            driver = _driver;
        }
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                driver = new ChromeDriver(chromeOptions);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return driver;
        }

    }
}

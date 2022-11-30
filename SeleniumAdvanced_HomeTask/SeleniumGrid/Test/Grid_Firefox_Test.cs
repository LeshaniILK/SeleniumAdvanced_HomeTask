using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace SeleniumAdvanced_HomeTask.SeleniumGrid.Test
{
    internal class Grid_Firefox_Test
    {
        IWebDriver driver;
        string hubUrl;

        [SetUp]
        public void OpenBrowser()
        {
            hubUrl = "http://192.168.1.34:4445/wd/hub";
            TimeSpan time = new TimeSpan(10, 33, 10);
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            driver = new RemoteWebDriver(
                            new Uri(hubUrl),
                            firefoxOptions.ToCapabilities(),
                            time
                            );
        }

        [Test]
        public void LoginToSite()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//input[@name='user-name']")).SendKeys("standard_user");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("secret_sauce");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}

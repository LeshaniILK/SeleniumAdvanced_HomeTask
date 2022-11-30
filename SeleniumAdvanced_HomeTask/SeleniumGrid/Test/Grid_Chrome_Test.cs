using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvanced_HomeTask.SeleniumGrid.Test
{
    public class Grid_Chrome_Test
    {
        IWebDriver driver;
        string hubUrl;

        [SetUp]
        public void OpenBrowser()
        {
            hubUrl = "http://192.168.1.34:4445/wd/hub";
            TimeSpan time = new TimeSpan(0, 33, 0);
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new RemoteWebDriver(
                            new Uri(hubUrl),
                            chromeOptions.ToCapabilities(),
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

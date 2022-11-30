using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvanced_HomeTask_PageObject.PageObjects
{
    internal class HomePage
    {
        protected Base baseClass;

        public HomePage(Base _baseClass)
        {
            this.baseClass = _baseClass;
        }

        public static IWebElement Email => WebDriver.GetInstance().FindElement(By.XPath("//*[@id='philadelphia-field-email']"));
        public static IWebElement SubmitBtn => WebDriver.GetInstance().FindElement(By.XPath("//*[@id='philadelphia-field-submit']"));
        public static IWebElement InsProjectTab => WebDriver.GetInstance().FindElement(By.XPath("//a[text()='Insurance Project']"));
        public static IWebElement Category => WebDriver.GetInstance().FindElement(By.XPath("//li[@class='item118 parent']"));
        public static IWebElement Course => WebDriver.GetInstance().FindElement(By.XPath("//li[@class='item121']"));
        public static IWebElement From => WebDriver.GetInstance().FindElement(By.XPath("//*[@id='credit2']/a"));
        public static IWebElement To => WebDriver.GetInstance().FindElement(By.XPath("//*[@id='bank']/li"));
        public static IWebElement Link => WebDriver.GetInstance().FindElement(By.XPath("//button[text()='Double-Click Me To See Alert']"));
        public static IWebElement RLink => WebDriver.GetInstance().FindElement(By.CssSelector(".context-menu-one"));
        public static IWebElement Item => WebDriver.GetInstance().FindElement(By.CssSelector(".context-menu-icon-copy"));
        public static IWebElement LoginBtn => WebDriver.GetInstance().FindElement(By.Name("btnLogin"));


        public void SubmitEmail()
        {
            baseClass.openBrowser();
            Email.Clear();
            Email.SendKeys("abc123@gmail.com");

            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            SubmitBtn.Click(); 
            
            IAlert AlertBox = WebDriver.GetInstance().SwitchTo().Alert();
            string AlertText = AlertBox.Text;
            Console.WriteLine(AlertText);
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            AlertBox.Accept();
            baseClass.closeBrowser();
        }

        public void SelectProject()
        {
            baseClass.openBrowser();
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            InsProjectTab.Click();
            WebDriver.GetInstance().Navigate().Back();
            baseClass.closeBrowser();

        }

        public void SelectCourse()
        {
            baseClass.openBrowser();
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Actions action = new Actions(WebDriver.GetInstance());
            action.MoveToElement(Category).Perform();
            action.MoveToElement(Course).Click().Perform();
            baseClass.closeBrowser();
        }

        public void DragnDrop()
        {
            WebDriver.GetInstance().Url = "http://demo.guru99.com/test/drag_drop.html";
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Actions action = new Actions(WebDriver.GetInstance());
            action.DragAndDrop(From, To).Build().Perform();
            baseClass.closeBrowser();
        }

        public void DoubleClick()
        {
            WebDriver.GetInstance().Url = "http://demo.guru99.com/test/simple_context_menu.html";
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Actions action = new Actions(WebDriver.GetInstance());
            action.DoubleClick(Link).Perform();
            IAlert alert = WebDriver.GetInstance().SwitchTo().Alert();
            string AlertText = alert.Text;
            Console.WriteLine(AlertText);
            alert.Accept();
            baseClass.closeBrowser();
        }

        public void RightClick()
        {
            WebDriver.GetInstance().Url = "http://demo.guru99.com/test/simple_context_menu.html";
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Actions action = new Actions(WebDriver.GetInstance());
            action.ContextClick(RLink).Perform();
            Item.Click();
            IAlert alert = WebDriver.GetInstance().SwitchTo().Alert();
            string AlertText = alert.Text;
            Console.WriteLine(AlertText);
            alert.Accept();
            baseClass.closeBrowser();
        }

        public void ClickJSExecuter()
        {
            WebDriver.GetInstance().Url = "http://demo.guru99.com/V4/";
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor) WebDriver.GetInstance();

            WebDriver.GetInstance().FindElement(By.Name("uid")).SendKeys("mngr458985");
            WebDriver.GetInstance().FindElement(By.Name("password")).SendKeys("UpEnUnU");

            jsExecutor.ExecuteScript("arguments[0].click();", LoginBtn);
            jsExecutor.ExecuteScript("alert('Welcome to Guru99');");
            baseClass.closeBrowser();
        }

        public void HighlightElement()
        {

            WebDriver.GetInstance().Url = "http://demo.guru99.com/V4/";
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            IWebElement UserID = WebDriver.GetInstance().FindElement(By.Name("uid"));

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)WebDriver.GetInstance();

            jsExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border:2px solid red; background:yellow')", UserID);
            baseClass.closeBrowser();
        }
    }
}

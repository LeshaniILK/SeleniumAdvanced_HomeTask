using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvanced_HomeTask_PageObject.PageObjects
{
    internal class Base
    {
        public string url = "https://demo.guru99.com/test/guru99home/";

        public void openBrowser()
        {
            WebDriver.GetInstance().Navigate().GoToUrl(url);
        }

        public void closeBrowser()
        {
            WebDriver.GetInstance().Quit();
        }
    }
}

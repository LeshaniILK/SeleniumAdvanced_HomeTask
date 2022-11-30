using SeleniumAdvanced_HomeTask_PageObject.PageObjects;

namespace SeleniumAdvanced_HomeTask_PageObject
{
    public class UnitTests1
    {
        readonly static Base baseClass = new Base();
        readonly HomePage homePage = new HomePage(baseClass);

        [Test, Order(1)]
        public void VerifyPageTitleTest()
        {
            WebDriver.GetInstance().Navigate().GoToUrl("https://demo.guru99.com/test/guru99home/");
            Assert.That(WebDriver.GetInstance().Title, Is.EqualTo("Demo Guru99 Page"));
        }

        [Test, Order(2)]
        public void SubmitEmailTest()
        {
            homePage.SubmitEmail();
        }

        [Test, Order(3)]
        public void SelectProjectTest()
        {
            homePage.SelectProject();
            //Assert.That(WebDriver.GetInstance().Title, Is.EqualTo("Insurance Broker System - Login"));
        }

        [Test, Order(4)]
        public void SelectCourseTest()
        {
            homePage.SelectCourse();
            //Assert.That(WebDriver.GetInstance().Title, Is.EqualTo("Selenium Tutorial"));
        }

        [Test, Order(5)]
        public void DragnDrop()
        {
            homePage.DragnDrop();
        }

        [Test, Order(6)]
        public void DoubleClick()
        {
            homePage.DoubleClick();
        }

        [Test, Order(7)]
        public void RightClick()
        {
            homePage.RightClick();
        }

        [Test, Order(8)]
        public void ClickJSExecuter()
        {
            homePage.ClickJSExecuter();
        }

        [Test, Order(9)]
        public void HighlightElement()
        {
            homePage.HighlightElement();
        }
    }
}

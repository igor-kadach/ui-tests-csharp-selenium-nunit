using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.PageObjects;


namespace UITests.Tests
{
    class InfoLinkTest
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(TestDatas.testUrl);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Close();
        }

        [Test]
        public void InfoLink()
        {
            var checkInfoLink = new MainMenuPageObject(_webDriver);
            checkInfoLink
                .QuestionsFind()
                .IsLinkEnable();

            var actualResult = checkInfoLink.IsLinkEnable();

            Assert.IsTrue(actualResult);
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.PageObjects;

namespace UITests.Tests
{
    class InstagramIntegrationTest
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
        public void InstagramIntegration()
        {
            var checkUrl = new MainMenuPageObject(_webDriver);
            var actualResult = checkUrl.GetInstagramUrl();
            var expectedResult = "https://www.instagram.com/insta_avby/";

            Assert.AreEqual(expectedResult, actualResult, "!wrong url!");
        }
    }
}

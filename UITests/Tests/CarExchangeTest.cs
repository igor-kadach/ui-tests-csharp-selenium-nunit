using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using UITests.PageObjects;

namespace UITests.Tests
{
    class CarExchangeTest
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
        public void CarExchange()
        {
            var loginToOfferExchange = new MainMenuPageObject(_webDriver);
            loginToOfferExchange
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password);
                Thread.Sleep(2000);


            var findCarForExchange = new ParametrsForSearchingPageObject(_webDriver);
            findCarForExchange
                .FindCarForExcahge();

            var isMyOfferDisplayed = new CatalogPageObject(_webDriver);
            isMyOfferDisplayed.isMyOfferDisplayed();

            var actualResult = isMyOfferDisplayed.isMyOfferDisplayed();

            Assert.IsTrue(actualResult);
        }
    }
}

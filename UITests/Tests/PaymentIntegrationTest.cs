using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.PageObjects;

namespace UITests.Tests
{
    class PaymentIntegrationTest
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
        public void PaymentIntegration()
        {
            var loginToCheckPayment = new MainMenuPageObject(_webDriver);
            loginToCheckPayment
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password)
                .OpenPersonalArea()
                .AddMyPoints();

            var paymentByCard = new PersonalAreaPageObject(_webDriver);
            paymentByCard
                .isLogoDisplayed();

            var actualResult = paymentByCard.isLogoDisplayed();

            Assert.IsTrue(actualResult);
        }
    }
}

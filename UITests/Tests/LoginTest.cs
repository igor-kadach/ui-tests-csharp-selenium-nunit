using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.PageObjects;


namespace UITests.Tests
{
    class LoginTest
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
        public void Login()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password);

            var actualResult = mainMenu.GetProfileMenu();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!wrong user!");
        }
    }
}

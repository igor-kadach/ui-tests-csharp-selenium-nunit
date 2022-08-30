using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using UITests.PageObjects;

namespace UITests.Tests
{
    class ChangePasswordTest
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
            var goToPrivateArea = new MainMenuPageObject(_webDriver);
            goToPrivateArea
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.newPasswordForTest)
                .OpenPersonalArea();
            Thread.Sleep(2000);

            var openSetting = new PersonalAreaPageObject(_webDriver);
            openSetting.OpenSetting();
            Thread.Sleep(2000);

            var changePassword = new SettingsPageObject(_webDriver);
            changePassword.ChangePasswordBack();

            _webDriver.Close();
        }

       [Test]
        public void ChangePassword()
        {
            var goToPrivateArea = new MainMenuPageObject(_webDriver);
            goToPrivateArea
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password)
                .OpenPersonalArea();

            var openSetting = new PersonalAreaPageObject(_webDriver);
            openSetting.OpenSetting();

            var changePassword = new SettingsPageObject(_webDriver);
            changePassword.ChangePassword();

            Thread.Sleep(3000);
            var loginWithOldPassword = new MainMenuPageObject(_webDriver);
            loginWithOldPassword
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password);

            var errorMessage = new AuthorizationPageObject(_webDriver);
            errorMessage.IsErrorMessageDisplayed();

            var actualResult = errorMessage.IsErrorMessageDisplayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!password wasn't changeg!");
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.PageObjects;

namespace UITests.Tests
{
    class UploadPhotoTest
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
        public void UploadPhoto()
        {
            var goToPrivateArea = new MainMenuPageObject(_webDriver);
            goToPrivateArea
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password)
                .OpenPersonalArea()
                .AddPhoto();

            var checkPhoto = new PersonalAreaPageObject(_webDriver);
            checkPhoto.isAddedPhotoDisplayed();

            var actualResult = checkPhoto.isAddedPhotoDisplayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!image not found!");
        }
    }
}

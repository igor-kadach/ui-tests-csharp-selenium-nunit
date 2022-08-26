using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using UITests.PageObjects;

namespace UITests
{

    public class Tests
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
        public void LoginTest()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(TestDatas.emailAdress, TestDatas.password);

            var actualResult = mainMenu.GetProfileMenu();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!wrong user!");
        }

        [Test]
        public void ChooseCarTest()
        {
            var findCarByParametrs = new MainMenuPageObject(_webDriver);
            findCarByParametrs
            .OpenCatalog()
            .FindCar();

            var actResult = findCarByParametrs.GetNameOfCar();
            var expResult = "Audi";
            Assert.That(actResult, Does.Contain(expResult), "!wrong results of searching!");
        }

        [Test]

        public void CheckInstagramIntegrationTest()
        {
            var checkUrl = new MainMenuPageObject(_webDriver);

            var actualResult = checkUrl.GetInstagramUrl();
            var expectedResult = "https://www.instagram.com/insta_avby/";

            Assert.AreEqual(expectedResult, actualResult, "!wrong url!");
        }

        [Test]

        public void CheckFavoriteTest()
        {

            var loginForAdding = new MainMenuPageObject(_webDriver);
            loginForAdding
                .SignIn()
                .Login(TestDatas.emailAdress, TestDatas.password);

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var openCatalogToAdding = new MainMenuPageObject(_webDriver);
            openCatalogToAdding
                .OpenCatalog()
                .FindCar();

            Thread.Sleep(3000);

            var addToBookmarks = new CatalogPageObject(_webDriver);
            addToBookmarks.AddToBookmark();

            var profile = new MainMenuPageObject(_webDriver);
            profile.OpenPersonalArea();

            var openBookmarks = new PersonalAreaPageObject(_webDriver);
            openBookmarks.OpenBookmarks();

            var actualResult = openBookmarks.IsAudiDispayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!Audi not found!");

        }

        [Test]
        public void CheckUploadPhotoTest() {

            var goToPrivateArea = new MainMenuPageObject(_webDriver);
            goToPrivateArea
                .SignIn()
                .Login(TestDatas.emailAdress, TestDatas.password)
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


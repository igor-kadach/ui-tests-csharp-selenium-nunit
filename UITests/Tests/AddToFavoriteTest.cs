using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using UITests.PageObjects;


namespace UITests.Tests
{
    class CheckFavoriteTest
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
            Thread.Sleep(2000);
            var deleteBookmark = new SettingsPageObject(_webDriver);
            deleteBookmark.DeleteBookmark();

            _webDriver.Close();
        }

        [Test]
        public void CheckFavorite()
        {
            var loginForAdding = new MainMenuPageObject(_webDriver);
            loginForAdding
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password);

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
    }
}

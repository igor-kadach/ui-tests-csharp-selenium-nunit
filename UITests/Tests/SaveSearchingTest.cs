using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using UITests.PageObjects;

namespace UITests.Tests
{
    class SaveSearchingTest
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
            var deleteSearching = new SettingsPageObject(_webDriver);
            deleteSearching.DeleteSearchList();

            _webDriver.Close();
        }

        [Test]
        public void SaveSearching()
        {
            var findCarToSaveSeach = new MainMenuPageObject(_webDriver);
            findCarToSaveSeach
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password)
                .OpenCatalog()
                .FindCar();

            var saveSearch = new CatalogPageObject(_webDriver);
            saveSearch.
                SaveSearch();

            var openSearchList = new MainMenuPageObject(_webDriver);
            openSearchList.OpenSaveSearchList();

            var isSearhcIsDisplayed = new PersonalAreaPageObject(_webDriver);
            isSearhcIsDisplayed.isSearchIsSaved();

            var actualResult = isSearhcIsDisplayed.isSearchIsSaved();

            Assert.IsTrue(actualResult);
        }
    }
}

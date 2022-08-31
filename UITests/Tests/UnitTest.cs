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

        [Test, Order(1)]
        public void LoginTest()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password);

            var actualResult = mainMenu.GetProfileMenu();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!wrong user!");
        }

        [Test, Order(2)]
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

        [Test, Order(3)]
        public void CheckInstagramIntegrationTest()
        {
            var checkUrl = new MainMenuPageObject(_webDriver);

            var actualResult = checkUrl.GetInstagramUrl();
            var expectedResult = "https://www.instagram.com/insta_avby/";

            Assert.AreEqual(expectedResult, actualResult, "!wrong url!");
        }

        [Test, Order(4)]
        public void CheckFavoriteTest()
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

        [Test, Order(5)]
        public void CheckUploadPhotoTest()
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

        [Test, Order(6)]
        public void InfoLinkTest()
        {
            var checkInfoLink = new MainMenuPageObject(_webDriver);
            checkInfoLink
                .QuestionsFind()
                .IsLinkEnable();

            var actualResult = checkInfoLink.IsLinkEnable();

            Assert.IsTrue(actualResult);
        }

        [Test, Order(7)]
        public void CarExchangeTest()
        {
            var loginToOfferExchange = new MainMenuPageObject(_webDriver);
            loginToOfferExchange
                .SignIn()
                .Login(TestDatas.phoneNumber, TestDatas.password)
                .OpenCatalog();

            var findCarForExchange = new ParametrsForSearchingPageObject(_webDriver);
            findCarForExchange
                .FindCarForExcahge();

            var isMyOfferDisplayed = new CatalogPageObject(_webDriver);
            isMyOfferDisplayed.isMyOfferDisplayed();

            var actuakResul = isMyOfferDisplayed.isMyOfferDisplayed();

            Assert.IsTrue(actuakResul);
        }

        [Test, Order(8)]
        public void SaveSearchingTest()
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

        [Test, Order(9)]
        public void PaymentIntegrationTest()
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

        [Test, Order(10)]
        public void ChangePasswordTest()
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


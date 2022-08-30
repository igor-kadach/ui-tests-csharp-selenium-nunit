using OpenQA.Selenium;
using System.Threading;
using UITests.Tests;

namespace UITests.PageObjects
{
    class PersonalAreaPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _bookmarks = By.XPath("//a[@href='/profile/bookmarks']");
        private readonly By _nameAudi = By.XPath("//span[contains(text(),'Audi')]");
        private readonly By _buttonChange = By.CssSelector("a[class='mycard__action-control'] span");
        private readonly By _buttonChoosePhoto = By.XPath("//input[@id='p-21-photo']");
        private readonly By _buttonSaveChanges = By.XPath("//button[@class='button button--primary button--large']");
        private readonly By _findAddedPhoto = By.XPath("//div[@class='uploader__preview']/ul[@class='uploader__thumbs']/li[10]/div[1]");
        private readonly By _settingsButton = By.XPath("//main[@class='main']//li[6]//a");
        private readonly By _nameOfSearching = By.XPath("//a[contains(text(),'Audi')]");
        private readonly By _points = By.XPath("//main[@class='main']//li[1]//a[1]");
        private readonly By _pointsFor10Rubles = By.XPath("//span[contains(text(),'За 10 р.')]");
        private readonly By _payByCard = By.XPath("//a[contains(text(),'Банковской картой')]");
        private readonly By _goToPayService = By.XPath("//span[contains(text(),'Перейти на платёжный сервис')]");
        private readonly By _logoOfPayment = By.XPath("//img[@alt='logo']");

        public PersonalAreaPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject OpenBookmarks()
        {
            _webDriver.FindElement(_bookmarks).Click();

            return new MainMenuPageObject(_webDriver);
        }

        public bool IsAudiDispayed()
        {
            var isAudiDispayed = _webDriver.FindElement(_nameAudi).Displayed;

            return isAudiDispayed;
        }

        public MainMenuPageObject AddPhoto()
        {
            _webDriver.FindElement(_buttonChange).Click();
            IWebElement element = _webDriver.FindElement(_buttonChoosePhoto);
            element.SendKeys(TestDatas.filePath);

            Thread.Sleep(3000);
            _webDriver.FindElement(_buttonSaveChanges).Click();
            _webDriver.FindElement(_buttonChange).Click();

            return new MainMenuPageObject(_webDriver);
        }

        public bool isAddedPhotoDisplayed()
        {
            var isAddedPhotoDisplayed = _webDriver.FindElement(_findAddedPhoto).Displayed;

            return isAddedPhotoDisplayed;
        }

        public SettingsPageObject OpenSetting()
        {
            _webDriver.FindElement(_settingsButton).Click();

            return new SettingsPageObject(_webDriver);
        }

        public bool isSearchIsSaved()
        {
            var isSearchIsSaved = _webDriver.FindElement(_nameOfSearching).Displayed;

            return isSearchIsSaved;
        }

        public MainMenuPageObject AddMyPoints()
        {
            Thread.Sleep(1000);
            _webDriver.FindElement(_points).Click();
            _webDriver.FindElement(_pointsFor10Rubles).Click();
            _webDriver.FindElement(_payByCard).Click();
            _webDriver.FindElement(_goToPayService).Click();

            return new MainMenuPageObject(_webDriver);
        }

        public bool isLogoDisplayed()
        {
            var isLogoDisplayed = _webDriver.FindElement(_logoOfPayment).Displayed;

            return isLogoDisplayed;
        }
    }
}



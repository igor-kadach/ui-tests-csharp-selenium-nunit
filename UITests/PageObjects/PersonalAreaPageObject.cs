using OpenQA.Selenium;
using System.Threading;

namespace UITests.PageObjects
{
    class PersonalAreaPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _bookmarks = By.XPath("//a[@href='/profile/bookmarks']");
        private readonly By _nameAudi = By.XPath("//span[contains(text(),'Audi')]");
        private readonly By _buttonChange = By.XPath("//span[contains(text(),'Изменить')]");
        private readonly By _buttonChoosePhoto = By.XPath("//input[@id='p-21-photo']");
        private readonly By _buttonSaveChanges = By.XPath("//button[@class='button button--primary button--large']");
        private readonly By _findAddedPhoto = By.XPath("//div[@class='uploader__preview']/ul[@class='uploader__thumbs']/li[10]/div[1]");

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
    }

}



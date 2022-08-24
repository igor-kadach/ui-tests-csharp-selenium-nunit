using OpenQA.Selenium;


namespace UITests.PageObjects
{
    class PersonalAreaPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _bookmarks = By.XPath("//a[@href='/profile/bookmarks']");
        private readonly By _nameAudi = By.XPath("//span[contains(text(),'Audi')]");

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

    }
}

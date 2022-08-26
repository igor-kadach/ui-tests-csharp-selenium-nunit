using OpenQA.Selenium;

namespace UITests.PageObjects
{
    class CatalogPageObject
    {

        private IWebDriver _webDriver;

        private readonly By _bookmark = By.XPath("//div[@class='listing__items']//div[1]//div[1]//div[5]//button[1]//*[name()='svg']//*[name()='path' and contains(@class,'fill')]");

        public CatalogPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ParametrsForSearchingPageObject AddToBookmark()
        {
            _webDriver.FindElement(_bookmark).Click();

            return new ParametrsForSearchingPageObject(_webDriver);
        }

    }
}



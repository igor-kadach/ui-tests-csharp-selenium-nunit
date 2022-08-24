using OpenQA.Selenium;
using System;


namespace UITests.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _sighInButton = By.XPath("//span[contains(text(),'Войти')]");
        private readonly By _profile = By.XPath("//*[name()='path' and contains(@d,'M12 18a6 6')]");
        private readonly By _showCatalogButton = By.CssSelector(".button.button--secondary.button--block");
        private readonly By _nameOfCar = By.XPath("//span[contains(text(),'Audi')]");
        private readonly By _goToInstagram = By.XPath("//a[normalize-space()='Instagram']");


        public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorizationPageObject SignIn()
        {
            _webDriver.FindElement(_sighInButton).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            return new AuthorizationPageObject(_webDriver);
        }

        public bool GetProfileMenu()
        {

            var userName = _webDriver.FindElement(_profile).Displayed;

            return userName;
        }

        public ParametrsForSearchingPageObject OpenCatalog()
        {

            _webDriver.FindElement(_showCatalogButton).Click();
            return new ParametrsForSearchingPageObject(_webDriver);
        }

        public string GetNameOfCar()
        {

            var nameOfCar = _webDriver.FindElement(_nameOfCar).Text;
            return nameOfCar;
        }


        public string GetInstagramUrl()
        {

            _webDriver.FindElement(_goToInstagram).Click();
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[1]);

            var url = _webDriver.Url;

            return url;
        }

        public PersonalAreaPageObject OpenPersonalArea()
        {
            _webDriver.FindElement(_profile).Click();
            return new PersonalAreaPageObject(_webDriver);
        }
    }
}


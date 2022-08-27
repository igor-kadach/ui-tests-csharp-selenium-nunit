using OpenQA.Selenium;
using System;
using System.Threading;

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
        private readonly By _askQuestion = By.XPath("//a[contains(text(),'Задать вопрос')]");
        private readonly By _mostPopularQuestioms = By.XPath("//a[@href='https://av.by/pages/faq']");
        private readonly By _infoEmail = By.XPath("//u[normalize-space()='info@av.by']");
        private readonly By _saveSearchList = By.XPath("//a[@title='Сохранённые поиски']");

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
            Thread.Sleep(1000);
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

        public MainMenuPageObject QuestionsFind()
        {
            _webDriver.FindElement(_askQuestion).Click();
            _webDriver.FindElement(_mostPopularQuestioms).Click();

            return new MainMenuPageObject(_webDriver);
        }

        public bool IsLinkEnable()
        {
            var isLinkEnable = _webDriver.FindElement(_infoEmail).Enabled;

            return isLinkEnable;
        }

        public MainMenuPageObject OpenSaveSearchList() 
        {
            _webDriver.FindElement(_saveSearchList).Click();

            return new MainMenuPageObject(_webDriver);
        }

    }
}


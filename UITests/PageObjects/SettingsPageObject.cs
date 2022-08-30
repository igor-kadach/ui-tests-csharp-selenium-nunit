using OpenQA.Selenium;
using UITests.Tests;

namespace UITests.PageObjects
{
    class SettingsPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _changePassword = By.XPath("//a[@href='/profile/settings/password']//span[contains(text(),'Изменить')]");
        private readonly By _oldPassworField = By.XPath("//input[@id='old-password']");
        private readonly By _newPasswordField = By.XPath("//input[@id='new-password']");
        private readonly By _applyButton = By.XPath("//span[contains(text(),'Применить')]");
        private readonly By _exitButton = By.XPath("//div[@class='set-header__side']//span[contains(text(),'Выйти')]");
        private readonly By _logo = By.XPath("//a[@class='header__logo-wrap']");
        private readonly By _deleteSearchList = By.XPath("//button[@class='button button--xlink']");
        private readonly By _deleteBookmark = By.XPath("//button[@aria-busy='false']//*[name()='svg']");
        private readonly By _acceptDeleting = By.XPath("//button[@class='button button--action button--large']");

        public SettingsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public PersonalAreaPageObject ChangePassword()
        {
            _webDriver.FindElement(_changePassword).Click();
            _webDriver.FindElement(_oldPassworField).SendKeys(TestDatas.password);
            _webDriver.FindElement(_newPasswordField).SendKeys(TestDatas.newPasswordForTest);
            _webDriver.FindElement(_applyButton).Click();
            _webDriver.FindElement(_exitButton).Click();
            _webDriver.FindElement(_logo).Click();

            return new PersonalAreaPageObject(_webDriver);
        }

        public PersonalAreaPageObject ChangePasswordBack()
        {
            _webDriver.FindElement(_changePassword).Click();
            _webDriver.FindElement(_oldPassworField).SendKeys(TestDatas.newPasswordForTest);
            _webDriver.FindElement(_newPasswordField).SendKeys(TestDatas.password);
            _webDriver.FindElement(_applyButton).Click();
            _webDriver.FindElement(_exitButton).Click();
            _webDriver.FindElement(_logo).Click();

            return new PersonalAreaPageObject(_webDriver);
        }

        public MainMenuPageObject DeleteSearchList()
        {
            _webDriver.FindElement(_deleteSearchList).Click();
            _webDriver.FindElement(_acceptDeleting).Click();

            return new MainMenuPageObject(_webDriver);
        }

        public SettingsPageObject DeleteBookmark()
        {
            _webDriver.FindElement(_deleteBookmark).Click();

            return new SettingsPageObject(_webDriver);
        }
    }
}

using OpenQA.Selenium;

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

        public SettingsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public PersonalAreaPageObject ChangePassword() {
                        
            _webDriver.FindElement(_changePassword).Click();
            _webDriver.FindElement(_oldPassworField).SendKeys(TestDatas.password);
            _webDriver.FindElement(_newPasswordField).SendKeys(TestDatas.newPasswordForTest);
            _webDriver.FindElement(_applyButton).Click();
            _webDriver.FindElement(_exitButton).Click();
            _webDriver.FindElement(_logo).Click();

            return new PersonalAreaPageObject(_webDriver);
        }
    }
}

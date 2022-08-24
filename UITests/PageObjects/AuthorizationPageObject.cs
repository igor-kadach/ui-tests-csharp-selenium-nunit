using OpenQA.Selenium;

namespace UITests.PageObjects
{
    class AuthorizationPageObject
    {

        private IWebDriver _webDriver;

        private readonly By _byEmail = By.XPath("//button[contains(text(),'почте или логину')]");
        private readonly By _loginInputField = By.XPath("//input[@name='login']");
        private readonly By _passwordInputField = By.XPath("//input[@id='loginPassword']");
        private readonly By _logInButton = By.XPath("//span[@class='button__text'][contains(text(),'Войти')]");

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject Login(string login, string password)
        {
            _webDriver.FindElement(_byEmail).Click();
            _webDriver.FindElement(_loginInputField).SendKeys(login);
            _webDriver.FindElement(_passwordInputField).SendKeys(password);
            _webDriver.FindElement(_logInButton).Click();

            return new MainMenuPageObject(_webDriver);
        }
    }
}

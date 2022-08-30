using OpenQA.Selenium;

namespace UITests.PageObjects
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _byEmail = By.XPath("//button[contains(text(),'почте или логину')]");
        private readonly By _byPhone = By.XPath("//input[@id='authPhone']");
        private readonly By _loginInputField = By.XPath("//input[@name='login']");
        private readonly By _phoneInputField = By.XPath("//input[@id='authPhone']");
        private readonly By _passwordInputField = By.XPath("//input[@id='loginPassword']");
        private readonly By _passwordByPhoneInputField = By.XPath("//input[@id='passwordPhone']");
        private readonly By _logInButton = By.XPath("//span[@class='button__text'][contains(text(),'Войти')]");
        private readonly By _errorMessage = By.XPath("//div[@class='error-message']");

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject Login(string phoneNumber, string password)
        {
            //_webDriver.FindElement(_byEmail).Click();
            _webDriver.FindElement(_byPhone).Click();
            _webDriver.FindElement(_phoneInputField).SendKeys(phoneNumber);
            _webDriver.FindElement(_passwordByPhoneInputField).SendKeys(password);
            _webDriver.FindElement(_logInButton).Click();

            return new MainMenuPageObject(_webDriver);
        }

        public bool IsErrorMessageDisplayed()
        {
            var isErrorMessageDisplayed = _webDriver.FindElement(_errorMessage).Displayed;

            return isErrorMessageDisplayed;
        }

        public IWebElement UserName { get; set; }
    }
}

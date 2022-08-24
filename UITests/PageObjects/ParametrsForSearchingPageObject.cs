using OpenQA.Selenium;
using System;


namespace UITests.PageObjects
{
    class ParametrsForSearchingPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _carsName = By.XPath("//button[@title='Марка']");
        private readonly By _nameAudi = By.XPath("//button[normalize-space()='Audi']");
        private readonly By _transmissionAutomatic = By.XPath("//span[contains(text(),'автомат')]");
        private readonly By _buttonShow = By.XPath("//button[@class='button button--secondary button--block']//span[@class='button__text']");
        private readonly By _chooseFuel = By.XPath("//button[@name='p-15-engine_type']//span[@class='dropdown-button__value']");
        private readonly By _benzinFuel = By.XPath("//div[@id='p-15-engine_type']//li[1]//label[1]//span[1]");


        public ParametrsForSearchingPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject FindCar()
        {

            _webDriver.FindElement(_carsName).Click();
            _webDriver.FindElement(_nameAudi).Click();
            _webDriver.FindElement(_transmissionAutomatic).Click();
            _webDriver.FindElement(_chooseFuel).Click();
            _webDriver.FindElement(_benzinFuel).Click();
            _webDriver.FindElement(_chooseFuel).Click();
            _webDriver.FindElement(_buttonShow).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            return new MainMenuPageObject(_webDriver);
        }

    }
}

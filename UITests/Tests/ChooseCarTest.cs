using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.PageObjects;


namespace UITests.Tests
{
    class ChooseCarTest
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(TestDatas.testUrl);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Close();
        }

        [Test]
        public void ChooseCar()
        {
            var findCarByParametrs = new MainMenuPageObject(_webDriver);
            findCarByParametrs
            .OpenCatalog()
            .FindCar();

            var actResult = findCarByParametrs.GetNameOfCar();
            var expResult = "Audi";
            Assert.That(actResult, Does.Contain(expResult), "!wrong results of searching!");
        }
    }
}

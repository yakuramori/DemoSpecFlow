using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoSpecFlow.Tests.Support
{
    public class MyDriver
    {
        public string BaseUrl;
        private readonly ChromeDriver _driver;

        public MyDriver()
        {
            var appSettingsProvider = new AppSettingsProvider();
            _driver = new ChromeDriver("./");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            BaseUrl = appSettingsProvider.Get("BaseUrl");
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public void Close()
        {
            _driver?.Close();
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}

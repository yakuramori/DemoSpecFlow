using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoSpecFlow.Tests.Pages
{
    public class HomePage
    {
        public static string Title = "Home — Conduit";
        private readonly IWebDriver _driver;
        private readonly By _userNameLink = By.XPath("//a[contains(@ui-sref, 'currentUser.username')]");

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetUserName()
        {
            return _driver.FindElement(_userNameLink).Text;
        }

        public bool IsTitleCorrect()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleIs(Title));
            return string.Equals(Title, _driver.Title);
        }
    }
}

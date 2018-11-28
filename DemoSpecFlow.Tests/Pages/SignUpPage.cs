using DemoSpecFlow.Tests.Support;
using OpenQA.Selenium;

namespace DemoSpecFlow.Tests.Pages
{
    public class SignUpPage
    {
        public static string Title = "Sign up — Conduit";
        private readonly IWebDriver _driver;
        private readonly By _userNameInput = By.XPath("//input[@placeholder='Username']");
        private readonly By _userEmailInput = By.XPath("//input[@placeholder='Email']");
        private readonly By _userPassword = By.XPath("//input[@placeholder='Password']");
        private readonly By _signUpButton = By.XPath("//button[.='Sign up']");

        public SignUpPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public HomePage SignUpAsUser(User user)
        {
            _driver.FindElement(_userNameInput).SendKeys(user.UserName);
            _driver.FindElement(_userEmailInput).SendKeys(user.UserEmail);
            _driver.FindElement(_userPassword).SendKeys(user.UserPassword);
            _driver.FindElement(_signUpButton).Click();
            return new HomePage(_driver);
        }

        public bool IsTitleCorrect()
        {
            return string.Equals(Title, _driver.Title);
        }
    }
}

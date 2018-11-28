using OpenQA.Selenium;

namespace DemoSpecFlow.Tests.Pages
{
    public class LandingPage
    {
        private readonly By _signInLink = By.XPath("//a[@ui-sref='app.login']");
        private readonly By _signUpLink = By.XPath("//a[@ui-sref='app.register']");
        private readonly IWebDriver _driver;

        public LandingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public SignUpPage OpenSignUpPage()
        {
            _driver.FindElement(_signUpLink).Click();
            return new SignUpPage(_driver);
        }
    }
}

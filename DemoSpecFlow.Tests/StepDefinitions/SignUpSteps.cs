using DemoSpecFlow.Tests.Pages;
using DemoSpecFlow.Tests.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DemoSpecFlow.Tests.StepDefinitions
{
    [Binding]
    public class SignUpSteps
    {
        private readonly MyDriver _driver;
        private readonly User _user;

        public SignUpSteps(MyDriver driver, User user)
        {
            _driver = driver;
            _user = user;
        }

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            _driver.GoTo();
            var signUpPage = new LandingPage(_driver.GetDriver()).OpenSignUpPage();
            Assert.True(signUpPage.IsTitleCorrect(), "Incorrect page opened!");
        }
        
        [When(@"I complete the sign up form")]
        public void WhenICompleteTheSignUpForm()
        {
            Assert.True(new SignUpPage(_driver.GetDriver()).SignUpAsUser(_user).IsTitleCorrect(), "Sign Up Failed!");
        }
        
        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            var home = new HomePage(_driver.GetDriver());
            Assert.True(home.IsTitleCorrect(), "Incorrect page opened!");
        }
        
        [Then(@"my username is displayed")]
        public void ThenMyUsernameIsDisplayed()
        {
            var home = new HomePage(_driver.GetDriver());
            Assert.True(home.IsTitleCorrect(), "Incorrect page opened!");
            Assert.AreEqual(_user.UserName, home.GetUserName());
        }
    }
}

using System;
using BoDi;
using DemoSpecFlow.Tests.Support;
using TechTalk.SpecFlow;

namespace DemoSpecFlow.Tests.Hooks
{
    [Binding]
    public class WebDriverSupport : IDisposable
    {
        private readonly IObjectContainer _objectContainer;
        private MyDriver _myDriver;
        private User _user;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var uniqueName = Guid.NewGuid().ToString().Split("-", 2)[0];
            _myDriver = new MyDriver();
            _user = new User
            {
                UserName = uniqueName,
                UserEmail = $"{uniqueName}@email.com",
                UserPassword = "P@ssword2018"
            };
            _objectContainer.RegisterInstanceAs(_myDriver);
            _objectContainer.RegisterInstanceAs(_user);
        }

        [AfterScenario]
        public void TearDown()
        {
            _myDriver?.Close();
        }
        
        public void Dispose()
        {
        }
    }
}

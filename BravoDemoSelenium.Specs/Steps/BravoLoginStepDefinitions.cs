using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Steps
{
    [Binding]
    public sealed class BravoLoginStepDefinitions
    {
        //Page Object for BravoLogin
        private readonly BravoLoginPageObject _bravoLoginPageObject;

        public BravoLoginStepDefinitions(BrowserDriver browserDriver)
        {
            _bravoLoginPageObject = new BravoLoginPageObject(browserDriver.Current);
        }

        [Given("the user name is (.*)")]
        public void GivenTheUserNameIs(string text)
        {
            //delegate to Page Object
            _bravoLoginPageObject.EnterUserName(text);
            Thread.Sleep(1000);
        }

        [Given("the password is (.*)")]
        public void GivenThePasswordIs(string text)
        {
            //delegate to Page Object
            _bravoLoginPageObject.EnterPassword(text);
            Thread.Sleep(1000);
        }

        [When("the user name and password are added")]
        public void WhenTheNameAndPassAreAdded()
        {
            //delegate to Page Object
            _bravoLoginPageObject.ClickLogin();
            Thread.Sleep(1000);
        }

        [Then("the user name validation message should be (.*)")]
        public void ThenTheUserNameValidationMsgShouldBe(string expectedResult)
        {
            //delegate to Page Object
            var actualResult = _bravoLoginPageObject.WaitForUserNameValidattionResult();
            Thread.Sleep(5000);
            actualResult.Should().Be(expectedResult);
        }

        [Then("the Password validation message should be (.*)")]
        public void ThenTheValidationMsgShouldBe(string expectedResult)
        {
            //delegate to Page Object
            var actualResult = _bravoLoginPageObject.WaitForPasswordValidattionResult();
            Thread.Sleep(5000);
            actualResult.Should().Be(expectedResult);
        }

        [Then("the display company name should be (.*)")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            //delegate to Page Object
            var actualResult = _bravoLoginPageObject.WaitForDisplayCompanyResult();
            Thread.Sleep(5000);
            actualResult.Should().Be(expectedResult);
        }
    }
}

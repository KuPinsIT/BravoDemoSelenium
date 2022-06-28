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
    public sealed class BravoSearchStepDefinitions
    {
        //Page Object for BravoLogin
        private readonly CompanySearchPageObject _companySearchPageObject;

        public BravoSearchStepDefinitions(BrowserDriver browserDriver)
        {
            _companySearchPageObject = new CompanySearchPageObject(browserDriver.Current);
        }

        [Given("the keyword is (.*)")]
        public void GivenTheKeywordIs(string text)
        {
            //delegate to Page Object
            _companySearchPageObject.EnterKeyword(text);
        }

        [When("the keyword is added")]
        public void WhenTheKeywordIsAdded()
        {
            //delegate to Page Object
            _companySearchPageObject.ClickSearch();
        }

        [Then("the company search results name should contains (.*)")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            Thread.Sleep(5000);

            //delegate to Page Object
            var actualResult = _companySearchPageObject.WaitForDisplayCompanyResult();

            actualResult.Should().Be(expectedResult);
        }
    }
}

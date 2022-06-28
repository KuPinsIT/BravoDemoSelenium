using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Hooks
{
    /// <summary>
    /// Company search related hooks
    /// </summary>
    [Binding]
    public class CompanySearchHooks
    {
        ///<summary>
        ///  Reset the BravoLogin before each scenario tagged with "BravoLogin"
        /// </summary>
        [BeforeScenario("CompanySearch")]
        public static void BeforeScenario(BrowserDriver browserDriver)
        {
            var companySearchPageObject = new CompanySearchPageObject(browserDriver.Current);
            companySearchPageObject.EnsureLoginIsOpenAndReset();
        }

        [BeforeFeature("CompanySearch")]
        public static void BeforeFeature(BrowserDriver browserDriver)
        {
            var bravoLoginPageObject = new BravoLoginPageObject(browserDriver.Current);
            bravoLoginPageObject.EnsureLoginIsOpenAndReset();
            bravoLoginPageObject.EnterUserName("thuanpham");
            bravoLoginPageObject.EnterPassword("12345678");
            bravoLoginPageObject.ClickLogin();
            bravoLoginPageObject.CloseDialog();
        }
    }
}

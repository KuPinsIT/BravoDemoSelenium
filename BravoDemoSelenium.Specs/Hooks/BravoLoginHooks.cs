using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Hooks
{
    /// <summary>
    /// Bravo Login related hooks
    /// </summary>
    [Binding]
    public class BravoLoginHooks
    {
        ///<summary>
        ///  Reset the BravoLogin before each scenario tagged with "BravoLogin"
        /// </summary>
        [BeforeScenario("BravoLogin")]
        public static void BeforeScenario(BrowserDriver browserDriver)
        {
            var bravoLoginPageObject = new BravoLoginPageObject(browserDriver.Current);
            bravoLoginPageObject.EnsureLoginIsOpenAndReset();
        }
    }
}

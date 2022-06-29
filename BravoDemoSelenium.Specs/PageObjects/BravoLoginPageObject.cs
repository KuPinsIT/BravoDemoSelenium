using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
namespace CalculatorSelenium.Specs.PageObjects
{
    /// <summary>
    /// Login Page Object
    /// </summary>
    public class BravoLoginPageObject
    {
        //The URL of the login to be opened in the browser
        private const string LoginUrl = "https://uptime-staging.uptime365.no/Account/LogOn";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public BravoLoginPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //Finding elements by ID
        private IWebElement UserNameElement => _webDriver.FindElement(By.Id("UserName"));
        private IWebElement PassWordElement => _webDriver.FindElement(By.Id("Password"));
        private IWebElement LoginButtonElement => _webDriver.FindElement(By.Id("btnLogin"));
        private IWebElement DisplayCompanyElement => _webDriver.FindElement(By.XPath("//span[@title='Upheads AS']"));

        private IWebElement UserNameErrorDisplayElement => _webDriver.FindElement(By.XPath("//span[normalize-space()='The User name field is required.']"));
        private IWebElement KeywordElement => _webDriver.FindElement(By.Id("Keyword"));
        private IWebElement SearchButtonElement => _webDriver.FindElement(By.Id("btnSearch"));
        private IWebElement CompaniesTableElement => _webDriver.FindElement(By.Id("propsectGrid"));

        public void EnterUserName(string text)
        {
            //Clear text box
            UserNameElement.Clear();
            //Enter text
            UserNameElement.SendKeys(text);
        }

        public void EnterPassword(string text)
        {
            //Clear text box
            PassWordElement.Clear();
            //Enter text
            PassWordElement.SendKeys(text);
        }

        public void ClickLogin()
        {
            //Click the login button
            LoginButtonElement.Click();
        }

        public void CloseDialog()
        {
            var dialog = _webDriver.FindElement(By.Id("missingDataWarningDialog"));
            var closeBtn = dialog.FindElement(By.ClassName("btn"));
            closeBtn.Click();
        }

        public void EnsureLoginIsOpenAndReset()
        {
            //Open the login page in the browser if not opened yet
            if (_webDriver.Url != LoginUrl)
            {
                _webDriver.Url = LoginUrl;
            }
        }

        public string WaitForDisplayCompanyResult()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () => DisplayCompanyElement.GetAttribute("title"),
                result => !string.IsNullOrEmpty(result));
        }

        public string WaitForUserNameValidattionResult()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () => UserNameElement.GetAttribute("data-val-required"),
                result => !string.IsNullOrEmpty(result));
        }

        public string WaitForPasswordValidattionResult()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () => PassWordElement.GetAttribute("data-val-required"),
                result => !string.IsNullOrEmpty(result));
        }

        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });

        }
    }
}

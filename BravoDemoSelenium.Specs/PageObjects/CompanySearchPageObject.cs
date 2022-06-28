using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorSelenium.Specs.PageObjects
{
    public class CompanySearchPageObject
    {
        //The URL of the login to be opened in the browser
        private const string companySearchUrl = "https://uptime-staging.uptime365.no/Procus";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public CompanySearchPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //Finding elements by ID
        private IWebElement KeywordElement => _webDriver.FindElement(By.Id("Keyword"));
        private IWebElement SearchButtonElement => _webDriver.FindElement(By.Id("btnSearch"));
        private IWebElement CompaniesTableElement => _webDriver.FindElement(By.Id("propsectGrid"));

        public void EnterKeyword(string text)
        {
            //Clear text box
            KeywordElement.Clear();
            //Enter text
            KeywordElement.SendKeys(text);
        }

        public void ClickSearch()
        {
            //Click the login button
            SearchButtonElement.Click();
        }

        public void EnsureLoginIsOpenAndReset()
        {
            //Open the login page in the browser if not opened yet
            if (_webDriver.Url != companySearchUrl)
            {
                _webDriver.Url = companySearchUrl;
            }
        }

        public string WaitForDisplayCompanyResult()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () => {
                    IList<IWebElement> rows = CompaniesTableElement.FindElements(By.TagName("tr"));

                    foreach (IWebElement row in rows)
                    {
                        IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                        foreach (IWebElement cell in cells)
                        {
                            var name = cell.GetAttribute("aria-describedby");
                            if (name == "propsectGrid_Name")
                            {
                                return cell.GetAttribute("title");
                            }
                        }
                    }

                    return String.Empty;
                },
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

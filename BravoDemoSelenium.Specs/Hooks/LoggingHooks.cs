﻿using CalculatorSelenium.Specs.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace BravoDemoSelenium.Specs.Hooks
{
    [Binding]
    public class LoggingHooks
    {
        private readonly BrowserDriver _browserDriver;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public LoggingHooks(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _browserDriver = browserDriver;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [AfterStep()]
        public void TakeScreenshotAfterEachStep()
        {

            if (_browserDriver.Current is ITakesScreenshot screenshotTaker)
            {
                var filename = Path.ChangeExtension(Path.GetRandomFileName(), "png");

                screenshotTaker.GetScreenshot().SaveAsFile(filename);

                _specFlowOutputHelper.AddAttachment(filename);
            }
        }
    }
}

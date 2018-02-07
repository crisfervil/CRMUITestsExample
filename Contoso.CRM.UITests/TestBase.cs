﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace Contoso.CRM.UITests
{
    public class TestBase
    {
        private const string BASE_URL_ENVIRONMENT_VARIABLE = "MYUITESTS.BASE_URL";
        private const string BROWSER_TYPE_ENVIRONMENT_VARIABLE = "MYUITESTS.BROWSER_TYPE";

        internal IWebDriver GetDriver()
        {
            IWebDriver driver = GetBrowserDriver();
            return driver;
        }

        internal string GetBaseUrl()
        {
            // Try to get the base url from the environment variable, otherwise from the configuration file
            return Environment.GetEnvironmentVariable(BASE_URL_ENVIRONMENT_VARIABLE);
        }

        internal IWebDriver GetBrowserDriver()
        {
            IWebDriver driver = null;

            // Try to get the base url from the environment variable, otherwise from the configuration file
            var broserType = Environment.GetEnvironmentVariable(BROWSER_TYPE_ENVIRONMENT_VARIABLE);

            // capitalize
            broserType = string.IsNullOrEmpty(broserType) ? "" : broserType.ToLower();

            var broserMapping = new Dictionary<BrowserTypes, Type>() { { BrowserTypes.Explorer , typeof(InternetExplorerDriver) /* the first in the list will be the default one */ },
                                                                        { BrowserTypes.Chrome , typeof(ChromeDriver) }};

            if (string.IsNullOrEmpty(broserType))
            {
                // return the default browser type
                driver = (IWebDriver)((Type)broserMapping.FirstOrDefault().Value).GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
            else
            {
                var selectedBrowserType = (BrowserTypes)Enum.Parse(typeof(BrowserTypes), broserType, true);
                driver = (IWebDriver)(broserMapping[selectedBrowserType]).GetConstructor(new Type[] { }).Invoke(new object[] { });
            }

            return driver;
        }

        internal void Run(Action<IWebDriver> test)
        {
            IWebDriver browserDriver = null;

            try
            {
                test(browserDriver);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (browserDriver != null)
                {
                    // close the driver & exit
                    browserDriver.Close();
                    browserDriver.Quit();
                }
            }

        }


    }
}

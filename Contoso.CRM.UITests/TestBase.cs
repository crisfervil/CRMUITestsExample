using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace Contoso.CRM.UITests
{
    public class TestBase
    {
        private const string BASE_URL_ENVIRONMENT_VARIABLE = "MYUITESTS.BASE_URL";

        internal IWebDriver GetDriver()
        {
            IWebDriver driver =  new InternetExplorerDriver();
            return driver;
        }

        internal string GetBaseUrl()
        {
            // Try to get the base url from the environment variable, otherwise from the configuration file
            return Environment.GetEnvironmentVariable(BASE_URL_ENVIRONMENT_VARIABLE);
        }
    }
}

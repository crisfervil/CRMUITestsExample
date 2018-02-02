using System;
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
            IWebDriver driver =  new InternetExplorerDriver();
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
            var broserType = Environment.GetEnvironmentVariable(BASE_URL_ENVIRONMENT_VARIABLE);

            // capitalize
            broserType = string.IsNullOrEmpty(broserType) ? "" : broserType.ToLower();


            var broserMapping = new Dictionary<BrowserTypes, Type>() { { BrowserTypes.Explorer , typeof(InternetExplorerDriver) /* the first in the list will be the default one */ },
                                                                        { BrowserTypes.Chrome , typeof(ChromeDriver) }};

            if (string.IsNullOrEmpty(broserType))
            {
                // return the default browser type
                // driver = ((Type)broserMapping.FirstOrDefault().Value).GetConstructor(new Type [])
            }


            // { Enum.GetName(typeof(BrowserTypes), BrowserTypes.Explorer).ToLower()


            return driver;
        }


}
}

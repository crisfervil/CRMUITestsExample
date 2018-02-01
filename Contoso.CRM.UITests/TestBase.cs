using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace Contoso.CRM.UITests
{
    public class TestBase
    {
        internal IWebDriver GetDriver()
        {
            return new InternetExplorerDriver();
        }
    }
}

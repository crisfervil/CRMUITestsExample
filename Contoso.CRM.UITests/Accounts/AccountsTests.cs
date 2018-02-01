using Contoso.CRM.UITests.Forms.Account;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Xunit;

namespace Contoso.CRM.UITests.Accounts
{
    public class AccountsTests : TestBase
    {
        [Fact]
        public void TestMethod1()
        {

            string crmUrl = "http://google.com";
            //create a ieAutomation
            IWebDriver browserDriver = base.GetDriver();//BrowserDriver


            var accountForm = new DefaultAccountForm(browserDriver);

            accountForm.Create(new Data.Account() { name="Contoso", address1_name="Adress1" });


            // open url
            browserDriver.Navigate().GoToUrl(crmUrl);

            // find element by id and set text
            browserDriver.FindElement(By.Id("name")).SendKeys("set the text");

            // find element by id and make a click
            browserDriver.FindElement(By.Id("id")).Click();

            // close the driver & exit
            browserDriver.Close();
            browserDriver.Quit();

        }
    }
}

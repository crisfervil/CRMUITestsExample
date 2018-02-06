using Contoso.CRM.UITests.Forms.Account;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using Xunit;

namespace Contoso.CRM.UITests.Accounts
{
    public class AccountsTests : TestBase
    {
        [Fact]
        public void CreateAccount()
        {
            var baseUrl = base.GetBaseUrl();
            IWebDriver browserDriver = base.GetDriver();

            var accountForm = new DefaultAccountForm(browserDriver, baseUrl);
            var accountId = accountForm.Create(new Data.Account() { name="Contoso", emailaddress1="test@test.com", address1_name="Adress1" });

            System.Diagnostics.Debug.Write($"accountId:${accountId}");

            // close the driver & exit
            browserDriver.Close();
            browserDriver.Quit();

        }
    }
}

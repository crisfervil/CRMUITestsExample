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
            base.Run(browserDriver =>
            {
                browserDriver = base.GetDriver();
                var baseUrl = base.GetBaseUrl();

                var accountForm = new DefaultAccountForm(browserDriver, baseUrl);
                var accountId = accountForm.Create(new Data.Account() { name = "Contoso", telephone1 = "0888888888" });

                accountForm.Delete(accountId.Value);

                System.Diagnostics.Debug.Write($"accountId:${accountId}");
            });
        }
    }
}

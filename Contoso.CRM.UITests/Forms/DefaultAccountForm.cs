using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.CRM.UITests.Data;

namespace Contoso.CRM.UITests.Forms.Account
{
    [CrmFormName("Account")]
    class DefaultAccountForm
    {
        private IWebDriver _webDriver;
        public DefaultAccountForm(IWebDriver driver)
        {
            _webDriver = driver;
        }

        public void Create(Data.Account account)
        {
            GoToCreate();
        }

        private void GoToCreate()
        {
        }
    }
}

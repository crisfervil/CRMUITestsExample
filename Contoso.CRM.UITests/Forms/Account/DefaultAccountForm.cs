using OpenQA.Selenium;
using System.Linq;

namespace Contoso.CRM.UITests.Forms.Account
{
    [CrmForm(EntityName ="account", FormName = "default")]
    class DefaultAccountForm
    {
        private IWebDriver _webDriver;
        private string _baseUrl;

        public DefaultAccountForm(IWebDriver driver, string baseUrl)
        {
            _webDriver = driver;
            _baseUrl = baseUrl;
        }

        public void Create(Data.Account accountData)
        {
            GoToCreate();

            // find the page frame
            _webDriver.SwitchTo().Frame("contentIFrame0");

            // start adding field values
            if(accountData.name != null)
            {
                // name_d
                _webDriver.FindElement(By.Id("name_d")).Click();
                _webDriver.FindElement(By.Id("name_i")).SendKeys(accountData.name);
            }
        }

        private void GoToCreate()
        {
            var formInfo = (CrmFormAttribute)(typeof(DefaultAccountForm).GetCustomAttributes(typeof(CrmFormAttribute), false).FirstOrDefault());
            var createUrl = $"{_baseUrl}?etn={formInfo.EntityName}&pagetype=entityrecord";
            _webDriver.Navigate().GoToUrl(createUrl);

            // TODO: add code to pick a specific form
        }
    }
}

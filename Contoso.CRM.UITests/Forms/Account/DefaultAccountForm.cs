using OpenQA.Selenium;
using System;
using System.Linq;

namespace Contoso.CRM.UITests.Forms.Account
{
    [CrmForm(EntityName ="account", FormName = "default")]
    class DefaultAccountForm
    {
        private IWebDriver _webDriver;
        private string _baseUrl;

        class FormFields
        {
            public static string name = "name";
            public static string emailaddress1 = "emailaddress1";
            public static string telephone1 = "telephone1";
        }

        public DefaultAccountForm(IWebDriver driver, string baseUrl)
        {
            _webDriver = driver;
            _baseUrl = baseUrl;
        }

        public void Delete(Guid accountId)
        {
            GoToEdit(accountId);
        }

        public Guid? Create(Data.Account accountData, bool save=true)
        {
            Guid? retVal = null;
            GoToCreate();

            // find the page frame
            _webDriver.SwitchTo().Frame("contentIFrame0");

            // start adding field values
            if (accountData.name != null) SetText(FormFields.name, accountData.name);
            if (accountData.emailaddress1 != null) SetText(FormFields.emailaddress1, accountData.emailaddress1);
            if (accountData.telephone1 != null) SetText(FormFields.telephone1, accountData.telephone1);

            if (save)
            {
                _webDriver.FindElement(By.Id("savefooter_statuscontrol")).Click();

                // try to get the guid of the created record
                string strGuid = (string)ExecuteScript("return Xrm.Page.data.entity.getId();");
                System.Diagnostics.Debug.Write($"recordId:${strGuid}");

                if (string.IsNullOrEmpty(strGuid)) strGuid.Replace("{","").Replace("}","");
                retVal = Guid.Parse(strGuid);
            }
            return retVal;
        }

        private object ExecuteScript(string script)
        {
            object retVal = null;
            if (_webDriver is IJavaScriptExecutor) {
                retVal = ((IJavaScriptExecutor)_webDriver).ExecuteScript(script);
            } else {
                throw new Exception("This driver does not support JavaScript");
            }
            return retVal;
        }

        private void SetText(string attributeName, string value)
        {
            _webDriver.FindElement(By.Id($"{attributeName}_d")).Click();
            _webDriver.FindElement(By.Id($"{attributeName}_i")).SendKeys(value);
        }

        private bool ElementIsPresent(By by)
        {
            return _webDriver.FindElements(by).Count > 0;
        }

        private void CloseTourDialogIfPresent()
        {
            var tourDialogFrameId = "InlineDialog_Iframe";
            var tourDialogCloseButtonId = "navTourCloseButtonImage";

            if(ElementIsPresent(By.Id(tourDialogFrameId))) {

                _webDriver.SwitchTo().Frame(tourDialogFrameId);

                if (ElementIsPresent(By.Id(tourDialogCloseButtonId)))
                {
                    var navBarTourCloseButton = _webDriver.FindElement(By.Id(tourDialogCloseButtonId));
                    if (navBarTourCloseButton != null && navBarTourCloseButton.Displayed)
                    {
                        navBarTourCloseButton.Click();
                    }
                }
            }
        }

        private void GoToCreate()
        {

            var formInfo = (CrmFormAttribute)(typeof(DefaultAccountForm).GetCustomAttributes(typeof(CrmFormAttribute), false).FirstOrDefault());
            var createUrl = $"{_baseUrl}?etn={formInfo.EntityName}&pagetype=entityrecord";
            _webDriver.Navigate().GoToUrl(createUrl);

            CloseTourDialogIfPresent();

            // TODO: add code to pick a specific form
        }

        private void GoToEdit(Guid recordId)
        {

            var formInfo = (CrmFormAttribute)(typeof(DefaultAccountForm).GetCustomAttributes(typeof(CrmFormAttribute), false).FirstOrDefault());
            var editUrl = $"{_baseUrl}?etn={formInfo.EntityName}&pagetype=entityrecord&id={recordId}";
            _webDriver.Navigate().GoToUrl(editUrl);

            CloseTourDialogIfPresent();

            // TODO: add code to pick a specific form
        }

    }
}

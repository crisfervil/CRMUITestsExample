using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.CRM.UITests.Forms
{
    class AuthenticationForm
    {
        private IWebDriver _driver;

        public AuthenticationForm(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SignIn(string userName, string password)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(x => x.Url.Contains("login.microsoftonline.com"));

            _driver.FindElement(By.Name("loginfmt")).SendKeys(userName);
            _driver.FindElement(By.Id("idSIButton9")).Click();
            _driver.FindElement(By.Name("passwd")).SendKeys(password);
            _driver.FindElement(By.Name("passwd")).SendKeys(Keys.Tab);
            _driver.FindElement(By.Name("passwd")).SendKeys(Keys.Enter);
            //wait.Until(x => x.FindElement(By.Id("idSIButton9")).Displayed);
            //IJavaScriptExecutor ex = (IJavaScriptExecutor)_driver;
            //ex.ExecuteScript("arguments[0].parentElement.click();", _driver.FindElement(By.Id("idSIButton9")));
            //_driver.FindElement(By.Id("idSIButton9")).Click();
            _driver.FindElement(By.Id("idBtn_Back")).Click();

        }
    }
}


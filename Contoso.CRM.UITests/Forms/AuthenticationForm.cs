using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


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

            wait.Until(x=> x.FindElements(By.Id("loginHeader")).Count > 0);

            if(_driver.FindElement(By.Id("loginHeader")).Text == "Pick an account")
            {
                if(_driver.FindElements(By.CssSelector($"[data-test-id='{userName}']")).Count > 0)
                {
                    _driver.FindElement(By.CssSelector($"[data-test-id='{userName}']")).Click();
                }
                else
                {
                    _driver.FindElement(By.Id("otherTile")).Click();
                }
            }

            _driver.FindElement(By.Name("loginfmt")).SendKeys(userName); // type user name
            System.Threading.Thread.Sleep(1000); // wait for the button to be available
            _driver.FindElement(By.Id("idSIButton9")).Click(); // click on next button
            System.Threading.Thread.Sleep(1000); // wait for the button to be available
            _driver.FindElement(By.Name("passwd")).SendKeys(password); // type pwd
            System.Threading.Thread.Sleep(1000); // wait for the sign in button to be available
            wait.Until(x => _driver.FindElement(By.Id("idSIButton9")).Displayed);
            _driver.FindElement(By.Id("idSIButton9")).Click(); // click on sign in button
            System.Threading.Thread.Sleep(1000); // wait for the button to be available
            if (_driver.FindElements(By.Id("idBtn_Back")).Count > 0)
            {
                _driver.FindElement(By.Id("idBtn_Back")).Click(); // click on not stay signed in
            }
        }
    }
}


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
            _driver.FindElement(By.Name("loginfmt")).SendKeys(userName); // type user name
            _driver.FindElement(By.Id("idSIButton9")).Click(); // click on next button
            _driver.FindElement(By.Name("passwd")).SendKeys(password); // type pwd
            System.Threading.Thread.Sleep(1000); // wait for the sign in button to be available
            wait.Until(x => _driver.FindElement(By.Id("idSIButton9")).Displayed);
            _driver.FindElement(By.Id("idSIButton9")).Click(); // click on sign in button
            _driver.FindElement(By.Id("idBtn_Back")).Click(); // click on not stay signed in

        }
    }
}


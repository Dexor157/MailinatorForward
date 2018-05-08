using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;

namespace MailinatorForward.PageObjects
{

    

    public class LoginPage
    {
        IWebDriver driver;
        Actions action;
        WebDriverWait wait;

        public LoginPage(IWebDriver _driver, Actions _action, WebDriverWait _wait) {
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
        }
        public IWebElement GetEmailField() {
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("many_login_email")));
        }
        public IWebElement GetPasswordField()
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("many_login_password")));
        }
        public MailinatorHome Login(String username, String password) {
            GetEmailField().SendKeys(username);
            GetPasswordField().SendKeys(password);
            GetPasswordField().SendKeys(Keys.Enter);
            return new MailinatorHome(driver, action, wait);
        }
    }
}

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
    public class MailinatorHome
    {
         
        IWebDriver driver;
        Actions action;
        WebDriverWait wait;

        public MailinatorHome(IWebDriver _driver, Actions _action, WebDriverWait _wait) {

            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
            driver.Url = "https://www.mailinator.com/";
        }
        public IWebElement GetSignInButton() {
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[href='/manyauth/login.jsp']")));
            //return driver.FindElement(By.CssSelector("[href='/manyauth/login.jsp']"));
        }
        public IWebElement GetInboxField() {
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("inboxfield")));
        }
        public LoginPage ClickLogin() {
            GetSignInButton().Click();
            return new LoginPage(driver,  action, wait);
        }
        public InboxPage OpenInbox(String inboxname) {
            GetInboxField().SendKeys("inboxname");
            GetInboxField().SendKeys(Keys.Enter);
            return new InboxPage(driver, action, wait);
        }
        
    }
}



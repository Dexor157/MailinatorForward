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
    public class InboxPage
    {

        IWebDriver driver;
        Actions action;
        WebDriverWait wait;

        public InboxPage(IWebDriver _driver, Actions _action, WebDriverWait _wait)
        {
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
        }

        //driver.FindElements(By.CssSelector("//id[class='all_message-item all_message-item-parent cf ng-scope')"));
    }
}

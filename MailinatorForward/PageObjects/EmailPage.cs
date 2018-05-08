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
    public class EmailPage
    {
        IWebDriver driver;
        Actions action;
        WebDriverWait wait;

        public EmailPage(IWebDriver _driver, Actions _action, WebDriverWait _wait){
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
        }

        public String getJSON() {
            viewJSON();
            var text = driver.FindElement(By.XPath("/html/body/pre")).GetAttribute("innerHTML");
            Console.WriteLine(text);
            return text;
        }
        public void viewJSON() {
            var dropdown = driver.FindElement(By.Id("contenttypeselect"));
            dropdown.Click();
            dropdown.FindElement(By.CssSelector("option[value='json']")).Click();
        }
    }
}

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
using System.Threading;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft;

using Newtonsoft.Json.Linq;

namespace MailinatorForward.PageObjects
{
    public class EmailPage
    {
        IWebDriver driver;
        Actions action;
        WebDriverWait wait;

        public EmailPage(IWebDriver _driver, Actions _action, WebDriverWait _wait) {
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
        }
        
        public IWebElement GetInboxField() {
            Console.WriteLine("Trying to find inbox field");
            return wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='inbox_field']")));
        }
        public IWebElement GetDeleteButton() {
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@title='Delete Emails']")));
        }
        public InboxPage DeleteEmail(){
            GetDeleteButton().Click();
            return new InboxPage(driver, action, wait);
        }
        public InboxPage GotoInbox(String address) {
            GetInboxField().SendKeys(address);
            GetInboxField().SendKeys(Keys.Enter);
            return new InboxPage(driver, action, wait);
        }
        public JObject getJSON() {
            viewJSON();
            driver.SwitchTo().Frame("msg_body");
            var text = driver.FindElement(By.TagName("pre")).GetAttribute("innerHTML");
            Console.WriteLine(text);
            JObject email = JObject.Parse(text);
            return email;
        }
        public void PrintJsonData() {
            viewJSON();
            driver.SwitchTo().Frame("msg_body");
            var text = driver.FindElement(By.TagName("pre")).GetAttribute("innerHTML");
            Console.WriteLine(text);
        }
        public String ViewHtml() {

            driver.SwitchTo().Frame("msg_body");
            String text = driver.FindElement(By.XPath("//*")).GetAttribute("innerHTML");
            return text;
        }
        public String getSender() {
            return (String)getJSON().SelectToken("fromfull");
        }
        public void viewJSON() {
            var dropdown = driver.FindElement(By.Id("contenttypeselect"));
            dropdown.Click();
            dropdown.FindElement(By.CssSelector("option[value='json']")).Click();
        }
    }
}

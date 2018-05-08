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

        public EmailPage(IWebDriver _driver, Actions _action, WebDriverWait _wait){
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
        }
        public String getJSON() {
            viewJSON();
            driver.SwitchTo().Frame("msg_body");
            var text = driver.FindElement(By.TagName("pre")).GetAttribute("innerHTML");
            Console.WriteLine(text);
            JObject email = JObject.Parse(text);
            Console.WriteLine(email.SelectToken("fromfull"));
            return text;
        }
        public void viewJSON() {
            var dropdown = driver.FindElement(By.Id("contenttypeselect"));
            dropdown.Click();
            dropdown.FindElement(By.CssSelector("option[value='json']")).Click();
        }
    }
}

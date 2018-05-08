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
using MailinatorForward.PageObjects;
namespace MailinatorForward
{
    class Program
    {
        static void Main(string[] args)
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            


            MailinatorHome homepage = new MailinatorHome(driver, action, wait);
            LoginPage loginpage = homepage.ClickLogin();
            MailinatorHome loggedinhome = loginpage.Login("DaveTestSe@gmail.com","TestPass");
            InboxPage inbox = loggedinhome.OpenInbox("SeTest");
            inbox.ClickEmail(0);

        }
    }
}

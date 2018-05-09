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
using MailinatorForward.Util;
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
            SQLRetrieval sql = new SQLRetrieval();
            //user inputs ID
            //int selectionId = int.Parse(Console.ReadLine());
            String inboxaddress = sql.GetEmail(45);
            Console.WriteLine(inboxaddress);
            //navigate to mailbox
            MailinatorHome homepage = new MailinatorHome(driver, action, wait);
            LoginPage loginpage = homepage.ClickLogin();
            MailinatorHome loggedinhome = loginpage.Login("DaveTestSe@gmail.com", "TestPass");
            InboxPage inbox = loggedinhome.OpenInbox(inboxaddress);
            EmailPage email = inbox.ClickEmail(0);

            //send email to target
            EmailSender sender = new EmailSender();
            sender.sendMail("s.dunlop@socyinc.com","Sean Dunlop","TestPass","Forwarded Email", email.ViewHtml());
            driver.Close();




        }
    }
}

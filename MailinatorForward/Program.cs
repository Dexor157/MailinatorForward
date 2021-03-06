﻿using OpenQA.Selenium;
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
            SQLRetrieval sql = new SQLRetrieval();
            string connectionString = sql.GetConnectionString();
            //user inputs ID
            User user;
            Console.WriteLine("Enter an ID or 'no' to use first valid inbox");
            String selection = Console.ReadLine();
            if (selection == "no") {
                user = sql.GetUser(connectionString);
            }
            else {
                user = sql.GetUser(connectionString, int.Parse(selection));
            }
            Console.WriteLine("Enter a destination email");
            String destinationAddress = Console.ReadLine();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //either user can enter an Id or program will check first valid email from the database


            Console.WriteLine(user.GetAddress());
            //print the address being used

            
            MailinatorHome homepage = new MailinatorHome(driver, action, wait);
            //LoginPage loginpage = homepage.ClickLogin();
            //MailinatorHome loggedinhome = loginpage.Login("DaveTestSe@gmail.com", "TestPass");
            InboxPage inbox = homepage.OpenInbox(user.GetAddress());
            EmailPage email;
            EmailSender sender = new EmailSender();
            while (true) {

                if (inbox.CheckInboxNotEmpty()) {
                    email = inbox.ClickEmail(0);
                    //navigate to the mailbox and click most recent email
                    sender.sendMail(destinationAddress, "Mailinator", "TestPass", "Forwarded Email", user.MakeString() + email.ViewHtml());
                    Console.WriteLine("Sent email");
                    //send the most recent email to the given address with some extra info on the original recipient
                    inbox = email.DeleteEmail();
                    Console.WriteLine("Deleted an email");

                    driver.Manage().Cookies.DeleteAllCookies();
                    //gets rid of invisible deleted emails
                }
                
                driver.Navigate().Refresh();

            }
            //send email to target
            //driver.Close();
            //close driver

        }
    }
}
/*
 TODO:
Make the process poll an inbox to wait for new emails, respond when new emails arrive
     */
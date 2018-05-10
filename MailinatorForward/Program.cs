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

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
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
            //either user can enter an Id or program will check first valid email from the database

            
            Console.WriteLine(user.GetAddress());
            //print the address being used

            
            MailinatorHome homepage = new MailinatorHome(driver, action, wait);
            LoginPage loginpage = homepage.ClickLogin();
            MailinatorHome loggedinhome = loginpage.Login("DaveTestSe@gmail.com", "TestPass");
            InboxPage inbox = loggedinhome.OpenInbox(user.GetAddress());
            EmailPage email;
            EmailSender sender = new EmailSender();
            while (true) {

                
                email = inbox.ClickEmail(0);
                //navigate to the mailbox and click most recent email
                sender.sendMail("s.dunlop@socyinc.com", "Sean Dunlop", "TestPass", "Forwarded Email", user.MakeString() + email.ViewHtml());
                //send the most recent email to the given address with some extra info on the original recipient
                inbox = email.DeleteEmail();


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
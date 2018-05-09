using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
namespace MailinatorForward.Util

{ 
    class EmailSender
    {

        public void sendMail(String address, String name, String fromPassword, String subject, String body)
        {

            MailAddress fromAddress = new MailAddress("DaveTestSe@gmail.com", "Dave Test");
            MailAddress toAddress = new MailAddress(address, name);

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                IsBodyHtml = true,
                Body = body
            })

            { client.Send(message); }

        }

    }
}

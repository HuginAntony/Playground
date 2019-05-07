using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AsyncEmailer
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    SendEmail().Wait();
            //}
            Task<bool> send = SendEmail();
            Console.WriteLine("Doing other work.");
            Console.WriteLine("Display a message");

            send.Wait();
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        static async Task<bool> SendEmail()
        {
            using (var mail = new MailMessage())
            {

                mail.To.Add("hugin@localhost.com");

                mail.Subject = "Testing async " + new Random().Next();
                mail.Body = "This is message number " + new Random().Next();
                mail.IsBodyHtml = true;

                //var pdfAttachment = new Attachment(pdf, pdfName);
                //pdfAttachment.ContentType = new ContentType("application/pdf");
                //mail.Attachments.Add(pdfAttachment);

                using (var smtpClient = new SmtpClient())
                {
                    await smtpClient.SendMailAsync(mail);
                }
            }

            return true;
        }
    }
}


//static void SendAsync()
//{
////create the mail message
//MailMessage mail = new MailMessage();

////set the addresses
//mail.From = new MailAddress("me@mycompany.com");
//mail.To.Add("you@yourcompany.com");

////set the content
//mail.Subject = "This is an email";
//mail.Body = "this is the body content of the email.";

////send the message
//SmtpClient smtp = new SmtpClient("127.0.0.1"); //specify the mail server address
////the userstate can be any object. The object can be accessed in the callback method
////in this example, we will just use the MailMessage object.
//object userState = mail;

////wire up the event for when the Async send is completed
//smtp.SendCompleted += new SendCompletedEventHandler(SmtpClient_OnCompleted);

//smtp.SendAsync(mail, userState);
//}
//public static void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
//{
////Get the Original MailMessage object
//MailMessage mail = (MailMessage)e.UserState;

////write out the subject
//string subject = mail.Subject;

//    if (e.Cancelled)
//{
//    Console.WriteLine("Send canceled for mail with subject [{0}].", subject);
//}
//if (e.Error != null)
//{
//    Console.WriteLine("Error {1} occurred when sending mail [{0}] ", subject, e.Error.ToString());
//}
//else
//{
//    Console.WriteLine("Message [{0}] sent.", subject);
//}
//}
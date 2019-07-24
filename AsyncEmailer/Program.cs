using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AsyncEmailer
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<bool> send = SendEmail();
            Console.WriteLine("Doing other work.");
            Console.WriteLine("Display a message");

            send.Wait();
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        //Using hMailServer as the SMTP server

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
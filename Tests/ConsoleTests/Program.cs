using System;
using System.Net;
using System.Net.Mail;
// using System.Net.Http;

namespace ConsoleTests
{
    class Program
    {
        static void Main()
        {

            MailAddress from = new MailAddress("kpblc2000@yandex.ru", "NET Console");
            MailAddress to = new MailAddress("kpblc2000@gmail.com");
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = "Test NET Console send";
            msg.Body = $"Testing Console send mail {DateTime.Now}";
            msg.IsBodyHtml = false;

            var client = new SmtpClient("smpt.yandex.ru", 587);

            client.Credentials = new NetworkCredential
            {
                UserName = "kpblc2000",
                Password = "testPassword" // !!
            };

            client.Send(msg);

        }
    }
}

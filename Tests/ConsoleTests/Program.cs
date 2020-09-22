using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Http;

namespace ConsoleTests
{
    class Program
    {
        static void Main()
        {
            var mess = new MailMessage("kpblc2000@yandex.ru", "shmachilin@gmail.com");
            mess.Subject = $"Заголовок от {DateTime.Now}";
            mess.Body = $"Текст тестового письма от {DateTime.Now}";

            var client = new SmtpClient("smpt.yandex.ru", 587);

            client.Credentials = new NetworkCredential
            {
                UserName = "kpblc2000",
                Password = "pas";
            }

            client.Send(mess);

        }
    }
}

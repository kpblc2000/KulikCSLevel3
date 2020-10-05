using KulikCSLevel3.Models;
using System.Net;
using System.Net.Mail;

namespace KulikCSLevel3.Services
{
    class SmtpSender
    {
        private readonly string _Address;
        private readonly int _Port;
        private readonly bool _UseSsl;
        private readonly string _Login;
        private readonly string _Password;

        public SmtpSender(string Address, int Port, bool UseSsl, string Login, string Password)
        {
            _Address = Address;
            _Port = Port;
            _UseSsl = UseSsl;
            _Login = Login;
            _Password = Password;
        }

        public void Send(string From, string To, string subject, string body)
        {
            using (MailMessage msg = new MailMessage(From, To) { Subject = subject, Body = body })
            {
                using var client = new SmtpClient(_Address, _Port)
                {
                    EnableSsl = _UseSsl,
                    Credentials = new NetworkCredential(_Login, _Password)
                };
                client.Send(msg);
            }
        }
    }
}

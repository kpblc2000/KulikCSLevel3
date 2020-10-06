using KulikCSLevel3.Services;
using WpfMailSender.Interfaces;

namespace WpfMailSender.Services
{
    public class SmtpMailService : IMailService
    {
        public SmtpMailSender GetSender(string Address, int Port, bool UseSsl, string Login, string Password)
        {
            return new SmtpMailSender(Address, Port, UseSsl, Login, Password);
        }

        IMailSender IMailService.GetSender(string Address, int Port, bool UseSsl, string Login, string Password)
        {
            return new SmtpMailSender(Address, Port, UseSsl, Login, Password);
        }
    }
}

using KulikCSLevel3.Services;
using WpfMailSender.Interfaces;

namespace WpfMailSender.Services
{
    public class SmtpMailService : IMailService
    {
        public SmtpSender GetSender(string Address, int Port, bool UseSsl, string Login, string Password)
        {
            return new SmtpSender(Address, Port, UseSsl, Login, Password);
        }

        IMailSender IMailService.GetSender(string Address, int Port, bool UseSsl, string Login, string Password)
        {
            return new SmtpSender(Address, Port, UseSsl, Login, Password);
        }
    }
}

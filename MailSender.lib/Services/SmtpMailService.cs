using KulikCSLevel3.Services;
using WpfMailSender.Interfaces;

namespace WpfMailSender.Services
{
    public class SmtpMailService : IMailService
    {

        private IEncryptorService _EncryptorService;

        public SmtpMailService(IEncryptorService EncryptorService)
        {
            _EncryptorService = EncryptorService;
        }
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

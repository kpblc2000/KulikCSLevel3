using System;
using System.Collections.Generic;
using System.Text;

namespace WpfMailSender.Interfaces
{
    public interface IMailService
    {
        IMailSender GetSender(string Address, int Port, bool UseSsl, string Login, string Password);
    }
}

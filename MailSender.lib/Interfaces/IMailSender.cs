using System;
using System.Collections.Generic;
using System.Text;

namespace WpfMailSender.Interfaces
{
    public interface IMailSender
    {
        void Send(string From, string To, string Subject, string Body);
    }
}

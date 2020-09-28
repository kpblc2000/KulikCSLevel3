using System;
using System.Net.Mail;

namespace KulikCSLevel3.Models
{
    public class Recipient
    {
        private MailAddress _mail = null;

        public Recipient(string ReceiverMail)
        {
            if (ValidateMail.EMailCorrect(ReceiverMail))
            {
                try
                {
                    _mail = new MailAddress(ReceiverMail);
                }
                catch (Exception)
                {
                    _mail = null;
                }
            }
        }

        public MailAddress ReceiverMail { get { return _mail; } }

        public string Name { get; set; }

        public string EmailAdress { get; set; }
    }
}

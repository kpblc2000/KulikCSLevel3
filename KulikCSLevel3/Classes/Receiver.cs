using System;
using System.Net.Mail;

namespace KulikCSLevel3
{
    public class Receiver
    {
        private MailAddress _mail = null;

        public Receiver(string ReceiverMail)
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
    }
}

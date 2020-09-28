using System.Net.Mail;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C# Уровень 3 урок1.
/// </summary>
namespace KulikCSLevel3
{
    public class Mail
    {

        private MailMessage _msg = null;
        private Models.Sender _from = null;
        private Models.Recipient _to = null;

        /// <summary>
        /// Создание объекта письма, содержащего в себе все необходимые для отправки данные
        /// </summary>
        /// <param name="From">Объект отправителя</param>
        /// <param name="To">Объект получаетля</param>
        /// <param name="MailSubject">Тема письма</param>
        /// <param name="MailBody">Тело письма</param>
        public Mail(Models.Sender From, Models.Recipient To, string MailSubject, string MailBody)
        {
            _from = From;
            _to = To;
            if (From.SenderMail != null && To.ReceiverMail != null && MailBody.Trim(new char[] { ' ', '\t', '\n' }) != "")
            {
                try
                {
                    _msg = new MailMessage(From.SenderMail, To.ReceiverMail);
                    _msg.Subject = MailSubject;
                    _msg.Body = MailBody;
                    _msg.IsBodyHtml = false;

                }
                catch { _msg = null; }
            }
        }

        public MailMessage Message { get { return _msg; } }
        public Models.Sender MailAuthor { get { return _from; } }
        public Models.Recipient MailReceiver { get { return _to; } }
    }
}

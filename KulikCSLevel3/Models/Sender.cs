using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace KulikCSLevel3.Models
{
    /// <summary>
    /// Объект автора письма
    /// </summary>
    public  class Sender
    {
        private MailAddress _mail = null;
        private SecureString _pwd = null;

        /// <summary>
        /// Создание объекта автора исходящего письма
        /// </summary>
        /// <param name="SenderMail">e-mail автора письма</param>
        /// <param name="SenderPassword">Пароль к e-mail</param>
        public Sender(string SenderMail, SecureString SenderPassword)
        {
            if (ValidateMail.EMailCorrect(SenderMail))
            {
                try
                {
                    _mail = new MailAddress(SenderMail);
                    _pwd = SenderPassword;
                }
                catch (Exception)
                {
                    _mail = null;
                    _pwd = null;
                }
            }
        }

        /// <summary>
        /// Адрес автора письма. В случае некорректности исходного e-mail возвращает null
        /// </summary>
        public MailAddress SenderMail { get { return _mail; } }

        /// <summary>
        /// Пароль автора письма к его email. В случае некорректности исходного e-mail возвращает null
        /// </summary>
        public SecureString SenderPassword { get { return _pwd; } }

        public string Name { get; set; }

        public string EmailAdress { get; set; }
    }
}

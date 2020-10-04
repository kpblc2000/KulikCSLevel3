using System;
using System.Net.Mail;
using System.Security;

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

        public int Id { get; set; }

        /// <summary>
        /// Адрес автора письма. В случае некорректности исходного e-mail возвращает null
        /// </summary>
        public MailAddress SenderMail { get { return _mail; } }

        /// <summary>
        /// Пароль автора письма к его email. В случае некорректности исходного e-mail возвращает null
        /// </summary>
        public SecureString SenderPassword { get { return _pwd; } }

        public Sender(string Name, string Email)
        {
            this.Name = Name;
            this.EmailAdress = Email;
        }

        public string Name { get; set; }

        public string EmailAdress { get; set; }
    }
}

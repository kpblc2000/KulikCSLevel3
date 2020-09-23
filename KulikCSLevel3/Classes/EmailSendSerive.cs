using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KulikCSLevel3
{

    // TODO Заменить конструктор класса. Отдельный класс на отправителя (ошибки отправки), класс письма (пустой заголовок/текст), класс получателя (ловит ошибки неправильных адресов), класс отправителя (неправильный адрес, пустой пароль)

    public class EmailSendSerive
    {
        private MailAddress _senderMail;
        private MailAddress _toMail;
        private MailMessage _msg;
        private SecureString _secPwd;
        private int _sendRes;

        /// <summary>
        /// Создание объекта класса для рассылки писем по указанным адресам
        /// </summary>
        /// <param name="SenderMail">e-mail автора письма</param>
        /// <param name="Password">пароль автора письма</param>
        /// <param name="ToMail">e-mail получателя письма</param>
        /// <param name="LetterSubject">Тема письма</param>
        /// <param name="LetterBody">Тело письма</param>
        public EmailSendSerive(string SenderMail, SecureString Password, string ToMail, string LetterSubject, string LetterBody)
        {
            _senderMail = new MailAddress(SenderMail);
            _toMail = new MailAddress(ToMail);
            _secPwd = Password;
            _msg = new MailMessage(_senderMail, _toMail);
            _msg.Subject = LetterSubject;
            _msg.Body = LetterBody;
            _msg.IsBodyHtml = false;
            _sendRes = -1;
        }

        /// <summary>
        /// Отсылка письма через указанный SMTP-сервер и по указанному порту
        /// </summary>
        /// <param name="SmtpServerAdress">Адрес SMTP-сервера (наприме, "smtp.yandex.ru")</param>
        /// <param name="SmtpPort">Соответствующий порт (для yandex - 25)</param>
        /// <returns>Строку с сообщением об успехе или ошибке операции</returns>
        public string SendEmail(string SmtpServerAdress, int SmtpPort)
        {
            string res;

            using (SmtpClient client = new SmtpClient(SmtpServerAdress, SmtpPort))
            {
                client.EnableSsl = true;

                client.Credentials = new NetworkCredential()
                {
                    UserName = _senderMail.Address,
                    SecurePassword = _secPwd
                };

                try
                {
                    client.Send(_msg);
                    res = $"Письмо по адресу {_toMail.Address} отправлено";
                    _sendRes = 0;
                }
                catch (Exception ex)
                {
                    res = $"Письмо по адресу {_toMail.Address} не доставлено : {ex.Message}";
                    _sendRes = 1;
                }
            }
            return res;
        }

        /// <summary>
        /// Возвращает результат отсылки письма: -1 - отсылка не выполнялась, 0 - успех, 1 - ошибка
        /// </summary>
        public int SendSuccess { get { return _sendRes; } }
    }
}

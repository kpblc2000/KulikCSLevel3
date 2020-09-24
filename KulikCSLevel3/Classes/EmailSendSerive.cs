using System;
using System.Net;
using System.Net.Mail;
/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C# Уровень 3 урок1.
/// </summary>
namespace KulikCSLevel3
{

    public class EmailSendSerive
    {
        /// <summary>
        /// Перечисление ошибок
        /// </summary>
        public enum SendMailErrors
        {
            /// <summary>
            /// Отустсвуют какие бы то ни было ошибки
            /// </summary>
            NoError,
            /// <summary>
            /// Ошибка распознавания адреса отправителя
            /// </summary>
            SernderMailValidateError,
            /// <summary>
            /// Ошибка распознавания адреса получателя
            /// </summary>
            ReceiverMailValidateError,
            /// <summary>
            /// Ошибка формирования объекта письма
            /// </summary>
            MailBodyError,
            /// <summary>
            /// Ошибка отправки письма по неизвестным причинам
            /// </summary>
            SendMailError
        }

        /// <summary>
        /// Автоматическая отправка письма получателю
        /// </summary>
        /// <param name="SmtpServerAdress">Адрес SMTP-сервера</param>
        /// <param name="SmtpPort">Номер порта, по которому надо обращаться к <paramref name="SmtpServerAdress"/></param>
        /// <param name="MailMesage">Объект письма, содержащий в себе все необходимые данные</param>
        /// <param name="MessageResult">Строковое представление результата отправки письма</param>
        /// <param name="SendResult">Номер ошибки при выполнении отсылки. 0 - ошибок не было</param>
        public EmailSendSerive(string SmtpServerAdress, int SmtpPort, Mail MailMesage, out string MessageResult, out SendMailErrors SendResult)
        {
            string res = "";
            SendMailErrors err = SendMailErrors.NoError;
            if (MailMesage.MailAuthor.SenderMail == null)
            {
                res = "Ошибка проверки адреса отправителя. Письмо не отправлялось";
                err = SendMailErrors.SernderMailValidateError;
            }
            else if (MailMesage.MailReceiver.ReceiverMail == null)
            {
                res = "Ошибка проверки адреса получателя. Письмо не отправлялось";
                err = SendMailErrors.ReceiverMailValidateError;
            }
            else if (MailMesage.Message == null)
            {
                res = "Ошибка определения тела письма. Письмо не отправлялось";
                err = SendMailErrors.MailBodyError;
            }
            else
            {
                using (SmtpClient client = new SmtpClient(SmtpServerAdress, SmtpPort))
                {
                    client.EnableSsl = true;

                    client.Credentials = new NetworkCredential()
                    {
                        UserName = MailMesage.MailAuthor.SenderMail.User,
                        SecurePassword = MailMesage.MailAuthor.SenderPassword
                    };

                    try
                    {
                        client.Send(MailMesage.Message);
                        res = $"Письмо по адресу {MailMesage.MailReceiver.ReceiverMail} отправлено";
                    }
                    catch (Exception ex)
                    {
                        res = $"Письмо по адресу {MailMesage.MailReceiver.ReceiverMail} не доставлено : {ex.Message}";
                        err = SendMailErrors.MailBodyError;
                    }
                }
            }
            SendResult = err;
            MessageResult = res;
        }

    }
}

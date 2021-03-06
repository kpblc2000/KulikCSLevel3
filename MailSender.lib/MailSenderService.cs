﻿using WpfMailSender.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace WpfMailSender
{
    public class MailSenderService
    {
        public string ServerAdress { get; set; }

        public int ServerPort { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool UseSSL { get; set; }

        public void SendMessage(string SenderMailAdress, string RecipientMailAdress, string MessageSubject, string MessageBody)
        {
            using (var mess = new MailMessage(new MailAddress(SenderMailAdress), new MailAddress(RecipientMailAdress)))
            {
                mess.Subject = MessageSubject;
                mess.Body = MessageBody;
                using (SmtpClient client = new SmtpClient(ServerAdress, ServerPort))
                {
                    client.EnableSsl = UseSSL;

                    client.Credentials = new NetworkCredential()
                    {
                        UserName = Login,
                        Password = TextEncoder.Decode(Password)
                    };
                    try
                    {
                        client.Send(mess);
                    }
                    catch (SmtpException e)
                    {
                        Trace.TraceError(e.ToString());
                        throw;
                    }
                    
                }
            }
        }
    }
}

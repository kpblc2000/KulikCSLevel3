﻿using KulikCSLevel3.Models;
using MailSender.lib.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace KulikCSLevel3.Data
{
    [Serializable]
    public class TestData
    {
        private List<Sender> _Senders;

        public List<Sender> Senders
        {
            get
            {
                if (_Senders is null)
                {
                    _Senders = Enumerable.Range(1, 10).Select(i => new Sender { Name = $"Отправитель {i}", EmailAdress = $"sender{i}@server.ru" }).ToList();
                }
                return _Senders;
            }
            set { _Senders = value; }
        }

        private List<Recipient> _Recipients;

        public List<Recipient> Recipients
        {
            get
            {
                if (_Recipients is null)
                {
                    _Recipients = Enumerable.Range(1, 10).Select(i => new Recipient { Name = $"Получатель {i}", EmailAdress = $"client{i}@server.ru" }).ToList();
                }
                return _Recipients;
            }
            set { _Recipients = value; }
        }

        private List<Server> _Servers;

        public List<Server> Servers
        {
            get
            {
                if (_Servers is null)
                    _Servers = Enumerable.Range(1, 5).Select(i => new Server
                    {
                        Adress = $"smtp.server{i}.com",
                        Port = 25,
                        Login = $"login-{i}",
                        Passord = TextEncoder.Encoder($"pwd{i}", 1),
                        UseSSL = (i % 2 == 0)
                    }).ToList();
                return _Servers;
            }
            set { _Servers = value; }
        }

        private List<Message> _Messages;

        public List<Message> Messages
        {
            get
            {
                if (_Messages is null)
                {
                    _Messages = Enumerable.Range(1, 15)
            .Select(i => new Message { Subject = $"Subj{i}", Body = $"Body{i}" })
            .ToList();
                }
                return _Messages;
            }
            set { _Messages = value; }
        }

        public static TestData LoadFromXML(string FileName)
        {
            var serializer = new XmlSerializer(typeof(TestData));
            using (var file = File.OpenText(FileName))
            { return (TestData)serializer.Deserialize(file); }
        }

        public void SaveToXML(string FileName)
        {
            var serializer = new XmlSerializer(typeof(TestData));
            using (var file = File.Create(FileName))
            { serializer.Serialize(file, this); }
        }

    }
}

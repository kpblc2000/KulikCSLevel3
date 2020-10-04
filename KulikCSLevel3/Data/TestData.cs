using KulikCSLevel3.Models;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib;
using System.Xml.Serialization;
using System.IO;

namespace KulikCSLevel3.Data
{
    public class TestData
    {
        private List<Server> _servers;

        public List<Sender> Senders { get;  } = Enumerable.Range(1, 10)
            .Select(i => new Sender($"Отправитель {i}", $"sender{i}@server.ru")
            ).ToList();

        public List<Recipient> Recipients { get;  } = Enumerable.Range(1, 20)
            .Select(i => new Recipient($"Получатель {i}", $"client{i}@server.ru")
            ).ToList();

        public List<Server>Servers
        {
            get {
                if (_servers is null)
                {
                    _servers = Enumerable.Range(1, 5)
            .Select(i => new Server($"smtp.server{i}.com", 25, i % 2 == 0) { Login = $"login-{i}", Passord = TextEncoder.Encoder($"pwd{i}", 1) }
            ).ToList();
                }
                return _servers; }
            set { _servers = value; }
        }

        public List<Message> Messages { get; } = Enumerable.Range(1, 15)
            .Select(i => new Message { Subject = $"Subj{i}", Body = $"Body{i}" })
            .ToList();

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

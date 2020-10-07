using KulikCSLevel3.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace KulikCSLevel3.Data
{
    class TestData
    {
        public IList<Sender> Senders { get; set; } = Enumerable.Range(1, 5).Select(i => new Sender
        {
            Id = i,
            Name = $"Отправитель {i}",
            Address = $"sender{i}@server.ru"
        }).ToList();

        public IList<Recipient> Recipients { get; set; } = Enumerable.Range(1, 25).Select(i => new Recipient
        {
            Id = i,
            Name = $"Получатель {i}",
            Address = $"sender{i}@server.ru"
        }).ToList();

        public IList<Server> Servers { get; set; } = Enumerable.Range(1, 5).Select(i =>
           new Server
           {
               Id = i,
               Name = $"ServerName-{i}",
               Address = $"Server{i}@server.com",
               Port = 25,
               UseSSL = i % 2 == 0,
               Login = $"Login{i}",
               Password = $"Pwd{i}"
           }
        ).ToList();

        public IList<Message> Messages { get; set; } = Enumerable.Range(1, 10).Select(i =>
       new Message
       {
           Id = i,
           Subject = $"Sub{i}",
           Body = $"Body{i}"
       }
        ).ToList();

        public static TestData LoadFromXML(string FileName)
        {
            var serializer = new XmlSerializer(typeof(TestData));
            using var file = File.OpenText(FileName);
            return (TestData)serializer.Deserialize(file);
        }

        public void SaveToXML(string FileName)
        {
            var serializer = new XmlSerializer(typeof(TestData));
            using var file = File.Create(FileName);
            serializer.Serialize(file, this);
        }

    }
}

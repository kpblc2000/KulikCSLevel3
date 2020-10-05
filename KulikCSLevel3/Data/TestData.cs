using KulikCSLevel3.Models;
using System.Collections.Generic;
using System.Linq;

namespace KulikCSLevel3.Data
{
    static class TestData
    {
        public static IList<Sender> Senders { get; } = Enumerable.Range(1, 5).Select(i => new Sender
        {
            Id = i,
            Name = $"Отправитель {i}",
            Email = $"sender{i}@server.ru"
        }).ToList();

        public static IList<Recipient> Recipients { get; } = Enumerable.Range(1, 25).Select(i => new Recipient
        {
            Id = i,
            Name = $"Получатель {i}",
            Email = $"sender{i}@server.ru"
        }).ToList();

        public static IList<Server> Servers { get; } = Enumerable.Range(1, 5).Select(i =>
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

        public static IList<Message> Messages { get; } = Enumerable.Range(1, 10).Select(i =>
        new Message
        {
            Id=i,
            Subject=$"Sub{i}",
            Body=$"Body{i}"
        }
        ).ToList();

    }
}

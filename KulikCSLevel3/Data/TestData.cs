using KulikCSLevel3.Models;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib;

namespace KulikCSLevel3.Data
{
    public static class TestData
    {
        public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
            .Select(i => new Sender { Name = $"Отправитель {i}", EmailAdress = $"sender{i}@server.ru" }
            ).ToList();

        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 20)
            .Select(i => new Recipient { Name = $"Получатель {i}", EmailAdress = $"client{i}@server.ru" }
            ).ToList();

        public static List<Server> Servers { get; } = Enumerable.Range(1, 5)
            .Select(i => new Server { Adress = $"smtp.server{i}.com", Port = 25, UseSSL = (i % 2 == 0), Login = $"login-{i}", Passord = TextEncoder.Encoder($"pwd{i}", 1) }
            ).ToList();

        public static List<Message> Messages { get; } = Enumerable.Range(1, 15)
            .Select(i => new Message { Subject = $"Subj{i}", Body = $"Body{i}" })
            .ToList();
    }
}

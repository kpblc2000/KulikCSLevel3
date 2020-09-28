using KulikCSLevel3.Models;
using System.Collections.Generic;
using System.Linq;

namespace KulikCSLevel3.Data
{
    static class TestData
    {
        public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
            .Select(i => new Sender($"Отправитель {i}", $"sender{i}@server.ru")
            ).ToList();

        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 20)
            .Select(i => new Recipient($"Получатель {i}", $"client{i}@server.ru")
            ).ToList();

        public static List<Server> Servers { get; } = Enumerable.Range(1, 5)
            .Select(i => new Server($"smtp.server{i}.com", 25, i % 2 == 0) { Login = $"login-{i}", Passord = $"pwd{i}" }
            ).ToList();

        public static List<Message> Messages { get; } = Enumerable.Range(1, 15)
            .Select(i => new Message { Subject = $"Subj{i}", Body = $"Body{i}" })
            .ToList();
    }
}

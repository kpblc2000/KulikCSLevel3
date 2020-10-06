using KulikCSLevel3.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WpfMailSender.Interfaces;

namespace WpfMailSender.Services
{
    public class DataStorageInMemory : IServersStorage, ISendersStorage, IRecipientsStorage, IMessagesStorage
    {
        public ICollection<Server> Servers { get; set; }
        public ICollection<Sender> Senders { get; set; }
        public ICollection<Recipient> Recipients { get; set; }
        public ICollection<Message> Messages { get; set; }

        ICollection<Server> IStorage<Server>.Items => Servers;
        ICollection<Sender> IStorage<Sender>.Items => Senders;
        ICollection<Recipient> IStorage<Recipient>.Items => Recipients;
        ICollection<Message> IStorage<Message>.Items => Messages;

        public void Load()
        {
            Debug.WriteLine("Load data proc started");
            if (Servers is null || Servers.Count == 0)
            {
                Servers = Enumerable.Range(1, 5).Select(i =>
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
            }

            if (Senders is null || Senders.Count == 0)
            {
                Senders = Enumerable.Range(1, 5).Select(i => new Sender
                {
                    Id = i,
                    Name = $"Отправитель {i}",
                    Email = $"sender{i}@server.ru"
                }).ToList();
            }

            if (Recipients is null || Recipients.Count == 0)
            {
                Recipients = Enumerable.Range(1, 25).Select(i => new Recipient
                {
                    Id = i,
                    Name = $"Получатель {i}",
                    Email = $"sender{i}@server.ru"
                }).ToList();
            }

            if (Messages is null || Messages.Count == 0)
            {
                Messages = Enumerable.Range(1, 10).Select(i =>
         new Message
         {
             Id = i,
             Subject = $"Sub{i}",
             Body = $"Body{i}"
         }
        ).ToList();
            }
        }

        public void SaveChanges()
        {
            Debug.WriteLine("Save data proc started");
        }

    }
}

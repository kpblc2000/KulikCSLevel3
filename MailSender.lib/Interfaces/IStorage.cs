using KulikCSLevel3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfMailSender.Interfaces
{
public interface IStorage<T>
    {
        ICollection<T> Items { get; }
        void Load();
        void SaveChanges();
    }

    public interface IServersStorage : IStorage<Server> { }
    public interface ISendersStorage : IStorage<Sender> { }
    public interface IRecipientsStorage : IStorage<Recipient> { }
    public interface IMessagesStorage : IStorage<Message> { }
}

using KulikCSLevel3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using WpfMailSender.Interfaces;

namespace WpfMailSender.Services
{
    public class DataStorageInXML : IServersStorage, ISendersStorage, IRecipientsStorage, IMessagesStorage
    {
        public class DataStructure
        {
            public List<Server> Servers { get; set; } = new List<Server>();
            public List<Sender> Senders { get; set; } = new List<Sender>();
            public List<Recipient> Recipients { get; set; } = new List<Recipient>();
            public List<Message> Messages { get; set; } = new List<Message>();
        }

        private readonly string _FileName;

        public DataStorageInXML(string FileName) => _FileName = FileName;

        private DataStructure Data { get; set; } = new DataStructure();

        ICollection<Server> IStorage<Server>.Items => Data.Servers;
        ICollection<Sender> IStorage<Sender>.Items => Data.Senders;
        ICollection<Recipient> IStorage<Recipient>.Items => Data.Recipients;
        ICollection<Message> IStorage<Message>.Items => Data.Messages;

        public void Load()
        {
            if (!File.Exists(_FileName))
            {
                Data = new DataStructure();
                return;
            }

            using (var _file = File.OpenText(_FileName))
            {
                if (_file.BaseStream.Length == 0)
                {
                    Data = new DataStructure();
                    return;
                }
                var serializer = new XmlSerializer(typeof(DataStructure));
                Data = (DataStructure)serializer.Deserialize(_file);
            }
        }

        public void SaveChanges()
        {
            using var file = File.CreateText(_FileName);
            var serializer = new XmlSerializer(typeof(DataStructure));
            serializer.Serialize(file, Data);
        }

    }
}

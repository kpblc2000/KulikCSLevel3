using KulikCSLevel3.Data;
using KulikCSLevel3.Infrastructure.Commands;
using KulikCSLevel3.Infrastructure.Commands.Base;
using KulikCSLevel3.Models;
using KulikCSLevel3.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KulikCSLevel3.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private static string __DataFileName = "data.xml";

        private TestData _savedDatas;

        private string _Title = "Кулик : Рассылка почты";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #region Данные и свойства
        // Вывод данных из представления
        private ObservableCollection<Sender> _senders;
        private ObservableCollection<Server> _servers;
        private ObservableCollection<Recipient> _recipients;
        private ObservableCollection<Message> _messages;

        public ObservableCollection<Server> Servers
        {
            get => _servers;
            set => Set(ref _servers, value);
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _recipients;
            set => Set(ref _recipients, value);
        }

        public ObservableCollection<Sender> Senders
        {
            get => _senders;
            set => Set(ref _senders, value);
        }

        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set => Set(ref _messages, value);
        }

        private Server _selServer;
        public Server SelectedServer
        {
            get => _selServer;
            set => Set(ref _selServer, value);
        }

        private Sender _selSender;
        public Sender SelectedSender
        {
            get => _selSender;
            set => Set(ref _selSender, value);
        }

        private Recipient _selRecipient;
        public Recipient SelectedRecipient
        {
            get => _selRecipient;
            set => Set(ref _selRecipient, value);
        }

        private Message _selMessage;
        public Message SelectedMessage
        {
            get => _selMessage;
            set => Set(ref _selMessage, value);
        }
        #endregion

        #region Команды сериализации

        private Command _LoadDataCommand;
        public Command LoadDataCommand
        {
            get
            {
                if (_LoadDataCommand is null)
                {
                    _LoadDataCommand = new RelayCommand(OnLoadDataCommandExecuted);
                }
                return _LoadDataCommand;
            }
        }

        private void OnLoadDataCommandExecuted(object obj)
        {
            _savedDatas = File.Exists(__DataFileName) ? TestData.LoadFromXML(__DataFileName) : new TestData();

            Servers = new ObservableCollection<Server>(_savedDatas.Servers);
            Senders = new ObservableCollection<Sender>(_savedDatas.Senders);
            Recipients = new ObservableCollection<Recipient>(_savedDatas.Recipients);
            Messages = new ObservableCollection<Message>(_savedDatas.Messages);
        }

        private Command _SaveDataCommand;
        public Command SaveDataCommand
        {
            get
            {
                if (_SaveDataCommand is null)
                {
                    _SaveDataCommand = new RelayCommand(OnSaveDataCommandExecuted);
                }
                return _SaveDataCommand;
            }
        }

        private void OnSaveDataCommandExecuted(object o)
        {

            List<Server> servers = new List<Server>(Servers);
            List<Sender> senders = new List<Sender>(Senders);
            List<Recipient> recs = new List<Recipient>(Recipients);
            List<Message> msgs = new List<Message>(Messages);
            var data = new TestData
            {
                Servers = servers,
                Senders = senders,
                Recipients = recs,
                Messages = msgs
            };
            data.SaveToXML(__DataFileName);

        }

        #endregion


    }
}

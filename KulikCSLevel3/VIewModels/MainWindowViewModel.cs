using KulikCSLevel3.Data;
using KulikCSLevel3.Infrastructure.Commands;
using KulikCSLevel3.Models;
using KulikCSLevel3.VIewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KulikCSLevel3.VIewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _title = "test window";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        // Попытка работы с командами
        /*
        private ICommand _ShowDlgCmd;

        public ICommand ShowDialogCommand
        {
            get
            {
                if (_ShowDlgCmd is null)
                {
                    _ShowDlgCmd = new RelayCommand(OnShowDialogCommandExecute);
                }
                return _ShowDlgCmd;
            }
        }

        private void OnShowDialogCommandExecute(object obj)
        {
            MessageBox.Show("Hi");
        }
        */

        /*
        private ICommand _TabScheduleActivate;

        public ICommand TabSceduleActivateCommand
        {
            get
            {
                if (_TabScheduleActivate is null)
                {
                    _TabScheduleActivate = new RelayCommand(OnTabSceduleActivateCommandExecute);
                }
                return _TabScheduleActivate;
            }
        }

        private void OnTabSceduleActivateCommandExecute(object o)
        {
            
        }
        */

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

        public MainWindowViewModel()
        {
            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);
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
    }
}

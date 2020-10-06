using KulikCSLevel3.Data;
using KulikCSLevel3.Infrastructure.Commands;
using KulikCSLevel3.Models;
using KulikCSLevel3.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace KulikCSLevel3.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string __DataFileName = "data.xml";

        private string _title = "Кулик : Рассылка";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
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

        #region Команды сериализации в XML

        private ICommand _LoadDataCommand;

        public ICommand LoadDataCommand => _LoadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted);

        private void OnLoadDataCommandExecuted(object obj)
        {
            var data = File.Exists(__DataFileName) ? TestData.LoadFromXML(__DataFileName) : new TestData();
            Servers = new ObservableCollection<Server>(data.Servers);
            Senders = new ObservableCollection<Sender>(data.Senders);
            Recipients = new ObservableCollection<Recipient>(data.Recipients);
            Messages = new ObservableCollection<Message>(data.Messages);
        }

        private ICommand _SaveDataCommand;

        public ICommand SaveDataCommand => _SaveDataCommand ??= new RelayCommand(OnSaveDataCommandExecuted);

        private void OnSaveDataCommandExecuted(object obj)
        {
            var data = new TestData
            {
                Servers = Servers,
                Senders = Senders,
                Recipients = Recipients,
                Messages = Messages
            };
            data.SaveToXML(__DataFileName);
        }

        #endregion

        #region Команды сервера

        private ICommand _CreateServerCommand;
        public ICommand CreateServerCommand => _CreateServerCommand ??= new RelayCommand(OnCreateServerCommandExecuted);

        private void OnCreateServerCommandExecuted(object obj)
        {
            if (!ServerEditDialog.Create(out var name, out var address, out var port, out var usessl, out var descr, out var login, out var pass)) return;
            var server = new Server
            {
                Id = Servers.DefaultIfEmpty().Max(srv => srv?.Id ?? 0) + 1,
                Name = name,
                Address = address,
                Port = port,
                UseSSL = usessl,
                Login = login,
                Password = pass,
                Description = descr
            };
            Servers.Add(server);
        }

        private ICommand _EditServerCommand;
        public ICommand EditServerCommand => _EditServerCommand ??= new RelayCommand(OnEditServerCommandExecuted);

        private bool CanEditServerCommandExecute(object p) => p is Server;

        private void OnEditServerCommandExecuted(object p)
        {
            if (!(p is Server server)) return;

            var name = server.Name;
            var address = server.Address;
            var port = server.Port;
            var ssl = server.UseSSL;
            var description = server.Description;
            var login = server.Login;
            var password = server.Password;

            if (!ServerEditDialog.ShowDialog("Редактирование сервера", ref name, ref address, ref port, ref ssl, ref description, ref login, ref password)) return;

            server.Name = name;
            server.Address = address;
            server.Port = port;
            server.UseSSL = ssl;
            server.Description = description;
            server.Login = login;
            server.Password = password;
        }

        private ICommand _EraseServerCommand;
        public ICommand EraseServerCommand => _EraseServerCommand ??= new RelayCommand(OnEraseServerCommandExecuted);
        
        private bool CanEraseServerCommandExecute(object p) => p is Server;

        private void OnEraseServerCommandExecuted(object obj)
        {
            if (!(obj is Server srv)) return;
            Servers.Remove(srv);
        }


        #endregion
    }
}

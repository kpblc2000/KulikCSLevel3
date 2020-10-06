using KulikCSLevel3.Data;
using KulikCSLevel3.Infrastructure.Commands;
using KulikCSLevel3.Models;
using KulikCSLevel3.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using WpfMailSender.Interfaces;

namespace KulikCSLevel3.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string __DataFileName = "data.xml";

        #region сервис почты
        private readonly IMailService _MailService;
        private readonly IServersStorage _ServerStorage;
        private readonly ISendersStorage _SenderStorage;
        private readonly IRecipientsStorage _RecipientStorage;
        private readonly IMessagesStorage _MessageStorage;
        public MainWindowViewModel(IMailService MailService, IServersStorage ServerStorage, ISendersStorage SenderStorage, IRecipientsStorage RecipientStorage, IMessagesStorage MessageStorage)
        {
            _MailService = MailService;
            _ServerStorage = ServerStorage;
            _SenderStorage = SenderStorage;
            _RecipientStorage = RecipientStorage;
            _MessageStorage = MessageStorage;
        }
        #endregion  

        private string _title = "Кулик : Рассылка";

        public StatisticViewModel Statistic { get; } = new StatisticViewModel();

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
            set { Set(ref _servers, value); }
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

        #region Selected
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
        #endregion

        #region Команды сериализации в XML

        private ICommand _LoadDataCommand;

        public ICommand LoadDataCommand => _LoadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted);

        private void OnLoadDataCommandExecuted(object obj)
        {
            _ServerStorage.Load();
            _RecipientStorage.Load();
            _SenderStorage.Load();
            _MessageStorage.Load();

            Servers = new ObservableCollection<Server>(_ServerStorage.Items);
            Senders = new ObservableCollection<Sender>(_SenderStorage.Items) ;
            Recipients = new ObservableCollection<Recipient>(_RecipientStorage.Items);
            Messages = new ObservableCollection<Message>(_MessageStorage.Items);
        }

        private ICommand _SaveDataCommand;

        public ICommand SaveDataCommand => _SaveDataCommand ??= new RelayCommand(OnSaveDataCommandExecuted);

        private void OnSaveDataCommandExecuted(object obj)
        {
            //var data = new TestData
            //{
            //    Servers = Servers,
            //    Senders = Senders,
            //    Recipients = Recipients,
            //    Messages = Messages
            //};
            //data.SaveToXML(__DataFileName);
            _ServerStorage.SaveChanges();
            _SenderStorage.SaveChanges();
            _RecipientStorage.SaveChanges();
            _MessageStorage.SaveChanges();
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
            _ServerStorage.Items.Add(server);
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
            _ServerStorage.Items.Remove(srv);
            Servers.Remove(srv);
        }


        #endregion

        #region Команда отправки почты

        private ICommand _SendMailMessageCommand;

        public ICommand SendMailMessageCommand => _SendMailMessageCommand ??= new RelayCommand(OnSendMailMessageCommandExecuted, CanSendMailMessageCommandExecute);

        private bool CanSendMailMessageCommandExecute(object p)
        {
            return SelectedServer != null && SelectedSender != null && SelectedRecipient != null && SelectedMessage != null;
        }

        private void OnSendMailMessageCommandExecuted(object p)
        {
            var server = SelectedServer;
            var client = _MailService.GetSender(server.Address, server.Port, server.UseSSL, server.Login, server.Password);
            var sender = SelectedSender;
            var recipient = SelectedRecipient;
            var message = SelectedMessage;
            client.Send(sender.Email, recipient.Email, message.Subject, message.Body);
            Statistic.MessageSended();
        }

        #endregion
    }
}

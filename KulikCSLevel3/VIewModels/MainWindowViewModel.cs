using KulikCSLevel3.Data;
using KulikCSLevel3.Infrastructure.Commands;
using KulikCSLevel3.Models;
using KulikCSLevel3.VIewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        #region Команды

        //#region OkButton
        //private ICommand _OkButtonClick;

        //public ICommand OkButtonClick
        //{
        //    get
        //    {
        //        if (_OkButtonClick is null)
        //        {
        //            _OkButtonClick = new RelayCommand(OnOkButtonClickExecuted, CanOkButtonClickExecute);
        //        }
        //        return _OkButtonClick;
        //    }
        //}

        //private bool CanOkButtonClickExecute(object o) => true;
        //private bool OnOkButtonClickExecuted(object o) => true;

        //#endregion

        #region Server
        #region  CreateNewServerCommand
        private ICommand _CreateNewServerCommand;

        public ICommand CreateNewServerCommand
        {
            get
            {
                if (_CreateNewServerCommand is null)
                {
                    _CreateNewServerCommand = new RelayCommand(OnCreateNewServerCommandExecuted, CanCreateNewServerCommandExecute);
                }
                return _CreateNewServerCommand;
            }
        }

        private bool CanCreateNewServerCommandExecute(object o) => true;
        private void OnCreateNewServerCommandExecuted(object o)
        {
            AddEditServer win = new AddEditServer();
            win.Title = "Ввод нового сервера";
            win.ServerName.Text = "";
            win.ServerPort.Text = "";
            win.UseSsl.IsChecked = false;
            win.ShowDialog();

            if (win.DialogResult == true)
            {
                int port;
                int.TryParse(win.ServerPort.Text, out port);
                Servers.Add(new Server(win.ServerName.Text, port, win.UseSsl.IsChecked ?? false));
            }
        }
        #endregion

        #region  EditServerCommand
        private ICommand _EditServerCommand;

        public ICommand EditServerCommand
        {
            get
            {
                if (_EditServerCommand is null)
                {
                    _EditServerCommand = new RelayCommand(OnEditServerCommandExecuted, CanEditServerCommandExecute);
                }
                return _EditServerCommand;
            }
        }

        private bool CanEditServerCommandExecute(object o) => o is Server || SelectedServer != null;
        private void OnEditServerCommandExecuted(object o)
        {
            Server server = o as Server ?? SelectedServer;
            if (server is null) return;
            // MessageBox.Show($"Edit server {server.Adress}");

            AddEditServer win = new AddEditServer();
            win.Title = "Редактирование сервера";
            win.ServerName.Text = server.Adress;
            win.ServerPort.Text = server.Port.ToString() ;
            win.UseSsl.IsChecked = server.UseSSL;
            win.ShowDialog();
            if (win.DialogResult == true)
            {
                server.Adress = win.ServerName.Text;
                int port;
                int.TryParse(win.ServerPort.Text, out port);
                server.Port = port;
                server.UseSSL = win.UseSsl.IsChecked ?? false;
            }
        }
        #endregion

        #region  DeleteServerCommand
        private ICommand _DeleteServerCommand;

        public ICommand DeleteServerCommand
        {
            get
            {
                if (_DeleteServerCommand is null)
                {
                    _DeleteServerCommand = new RelayCommand(OnDeleteServerCommandExecuted, CanDeleteServerCommandExecute);
                }
                return _DeleteServerCommand;
            }
        }

        private bool CanDeleteServerCommandExecute(object o) => o is Server || SelectedServer != null;
        private void OnDeleteServerCommandExecuted(object o)
        {
            Server server = o as Server ?? SelectedServer;
            if (server is null) return;
            Servers.Remove(server);
            SelectedServer = Servers.FirstOrDefault();
            MessageBox.Show($"Erase server {server.Adress}"); 
        }
        #endregion
        #endregion

        //#region Sender
        //#region  CreateNewSenderCommand
        //private ICommand _CreateNewSenderCommand;

        //public ICommand CreateNewSenderCommand
        //{
        //    get
        //    {
        //        if (_CreateNewSenderCommand is null)
        //        {
        //            _CreateNewSenderCommand = new RelayCommand(OnCreateNewSenderCommandExecuted, CanCreateNewSenderCommandExecute);
        //        }
        //        return _CreateNewSenderCommand;
        //    }
        //}

        //private bool CanCreateNewSenderCommandExecute(object o) => true;
        //private void OnCreateNewSenderCommandExecuted(object o)
        //{
        //    MessageBox.Show("Add new sender");
        //}
        //#endregion

        //#region  EditSenderCommand
        //private ICommand _EditSenderCommand;

        //public ICommand EditSenderCommand
        //{
        //    get
        //    {
        //        if (_EditSenderCommand is null)
        //        {
        //            _EditSenderCommand = new RelayCommand(OnEditSenderCommandExecuted, CanEditSenderCommandExecute);
        //        }
        //        return _EditSenderCommand;
        //    }
        //}

        //private bool CanEditSenderCommandExecute(object o) => true;
        //private void OnEditSenderCommandExecuted(object o)
        //{
        //    MessageBox.Show("Edit sender");
        //}
        //#endregion

        //#region  DeleteSenderCommand
        //private ICommand _DeleteSenderCommand;

        //public ICommand DeleteSenderCommand
        //{
        //    get
        //    {
        //        if (_DeleteSenderCommand is null)
        //        {
        //            _DeleteSenderCommand = new RelayCommand(OnDeleteSenderCommandExecuted, CanDeleteSenderCommandExecute);
        //        }
        //        return _DeleteSenderCommand;
        //    }
        //}

        //private bool CanDeleteSenderCommandExecute(object o) => true;
        //private void OnDeleteSenderCommandExecuted(object o)
        //{
        //    MessageBox.Show("Erase sender");
        //}
        //#endregion
        //#endregion

        //#region Message
        //#region  CreateNewMessageCommand
        //private ICommand _CreateNewMessageCommand;

        //public ICommand CreateNewMessageCommand
        //{
        //    get
        //    {
        //        if (_CreateNewMessageCommand is null)
        //        {
        //            _CreateNewMessageCommand = new RelayCommand(OnCreateNewMessageCommandExecuted, CanCreateNewMessageCommandExecute);
        //        }
        //        return _CreateNewMessageCommand;
        //    }
        //}

        //private bool CanCreateNewMessageCommandExecute(object o) => true;
        //private void OnCreateNewMessageCommandExecuted(object o)
        //{
        //    MessageBox.Show("Add new msg");
        //}
        //#endregion

        //#region  EditMessageCommand
        //private ICommand _EditMessageCommand;

        //public ICommand EditMessageCommand
        //{
        //    get
        //    {
        //        if (_EditMessageCommand is null)
        //        {
        //            _EditMessageCommand = new RelayCommand(OnEditMessageCommandExecuted, CanEditMessageCommandExecute);
        //        }
        //        return _EditMessageCommand;
        //    }
        //}

        //private bool CanEditMessageCommandExecute(object o) => true;
        //private void OnEditMessageCommandExecuted(object o)
        //{
        //    MessageBox.Show("Edit msg");
        //}
        //#endregion

        //#region  DeleteMessageCommand
        //private ICommand _DeleteMessageCommand;

        //public ICommand DeleteMessageCommand
        //{
        //    get
        //    {
        //        if (_DeleteMessageCommand is null)
        //        {
        //            _DeleteMessageCommand = new RelayCommand(OnDeleteMessageCommandExecuted, CanDeleteMessageCommandExecute);
        //        }
        //        return _DeleteMessageCommand;
        //    }
        //}

        //private bool CanDeleteMessageCommandExecute(object o) => true;
        //private void OnDeleteMessageCommandExecuted(object o)
        //{
        //    MessageBox.Show("Erase msg");
        //}
        //#endregion
        //#endregion

        //#region Recipient
        //#region  DeleteRecipientCommand
        //private ICommand _DeleteRecipientCommand;

        //public ICommand DeleteRecipientCommand
        //{
        //    get
        //    {
        //        if (_DeleteRecipientCommand is null)
        //        {
        //            _DeleteRecipientCommand = new RelayCommand(OnDeleteRecipientCommandExecuted, CanDeleteRecipientCommandExecute);
        //        }
        //        return _DeleteRecipientCommand;
        //    }
        //}

        //private bool CanDeleteRecipientCommandExecute(object o) => true;
        //private void OnDeleteRecipientCommandExecuted(object o)
        //{
        //    MessageBox.Show("Erase recip");
        //}
        //#endregion

        //#region  CreateNewRecipientCommand
        //private ICommand _CreateNewRecipientCommand;

        //public ICommand CreateNewRecipientCommand
        //{
        //    get
        //    {
        //        if (_CreateNewRecipientCommand is null)
        //        {
        //            _CreateNewRecipientCommand = new RelayCommand(OnCreateNewRecipientCommandExecuted, CanCreateNewRecipientCommandExecute);
        //        }
        //        return _CreateNewRecipientCommand;
        //    }
        //}

        //private bool CanCreateNewRecipientCommandExecute(object o) => true;
        //private void OnCreateNewRecipientCommandExecuted(object o)
        //{
        //    MessageBox.Show("Add new recip");
        //}
        //#endregion

        //#region  EditRecipientCommand
        //private ICommand _EditRecipientCommand;

        //public ICommand EditRecipientCommand
        //{
        //    get
        //    {
        //        if (_EditRecipientCommand is null)
        //        {
        //            _EditRecipientCommand = new RelayCommand(OnEditRecipientCommandExecuted, CanEditRecipientCommandExecute);
        //        }
        //        return _EditRecipientCommand;
        //    }
        //}

        //private bool CanEditRecipientCommandExecute(object o) => true;
        //private void OnEditRecipientCommandExecuted(object o)
        //{
        //    MessageBox.Show("Edit recip");
        //}
        //#endregion
        //#endregion

        #endregion

        public MainWindowViewModel()
        {
            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);
        }


    }
}

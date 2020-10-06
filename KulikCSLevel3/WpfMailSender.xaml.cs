using KulikCSLevel3.Models;
using KulikCSLevel3.Services;
using System.Diagnostics;
using System.Net.Mail;
using System.Windows;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C# Уровень 3 урок 3.
/// </summary>
namespace KulikCSLevel3
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendNowButtonClick(object Sender, RoutedEventArgs E)
        {
            if (!(SendersList.SelectedItem is Sender sender)) return;
            if (!(RecipientsList.SelectedItem is Recipient recipient)) return;
            if (!(ServersList.SelectedItem is Server server)) return;
            if (!(MessagesList.SelectedItem is Message message)) return;
            var mail_sender = new SmtpSender(
                server.Address,
                server.Port,
                server.UseSSL,
                server.Login,
                server.Password);
            try
            {
                var timer = Stopwatch.StartNew();
                mail_sender.Send(
                    sender.Email,
                    recipient.Email,
                    message.Subject,
                    message.Body);
                timer.Stop();
                MessageBox.Show($"Почта успешно отправлена за {timer.Elapsed.TotalSeconds:0.##}c", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SmtpException)
            {
                MessageBox.Show("Ошибка при отправке почты", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #region Hide
        private void btnSend_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Mail mail = new Mail(
            //    new Sender(MailFrom.Text, PasswordText.SecurePassword),
            //     new Receiver(MailTo.Text),
            //     Subject.Text,
            //     Body.Text
            //    );

            //EmailSendSerive.SendMailErrors errSend;
            //string sendRes;
            //EmailSendSerive srv1 = new EmailSendSerive(
            //    ClientDatas.ServerAdress,
            //    ClientDatas.ServerPort,
            //    mail, out sendRes, out errSend);
            //StatusBarMessage.Foreground = errSend == EmailSendSerive.SendMailErrors.NoError ? Brushes.Black : Brushes.Red;
            //StatusBarMessage.Text = sendRes;
        }

        //private void BtnSend_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    //var sendSender = SenderList.SelectedItem as Sender;
        //    //if (sendSender is null)
        //    //{
        //    //    return;
        //    //}
        //    if (!(SenderList.SelectedItem is Sender sendSender)) return;
        //    if (!(RecipientList.SelectedItem is Recipient sendRecip)) return;
        //    if (!(Serverlist.SelectedItem is Server sendServer)) return;
        //    if (!(MessagesList.SelectedItem is Message msg)) return;

        //    var sendService = new MailSenderService
        //    {
        //        ServerAdress = sendServer.Adress,
        //        ServerPort = sendServer.Port,
        //        UseSSL = sendServer.UseSSL,
        //        Password = sendServer.Passord,
        //        Login = sendServer.Login
        //    };

        //    try
        //    {
        //        sendService.SendMail(sendSender.EmailAdress, sendRecip.EmailAdress, msg.Subject, msg.Body);
        //    }
        //    catch(SmtpException ex)
        //    {
        //        MessageBox.Show("Ошибка SMTP при отправке почты" + ex.Message,"Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show("Ошибка при отправке почты" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        //private void OnSendButtonClick(object sender, RoutedEventArgs e)
        //{
        //    if (!(SenderList.SelectedItem is Sender sendSender)) return;
        //    if (!(RecipientList.SelectedItem is Recipient sendRecip)) return;
        //    if (!(ServerList.SelectedItem is Server sendServer)) return;
        //    if (!(MessagesList.SelectedItem is Message msg)) return;

        //    var sendService = new MailSenderService
        //    {
        //        ServerAdress = sendServer.Adress,
        //        ServerPort = sendServer.Port,
        //        UseSSL = sendServer.UseSSL,
        //        Password = sendServer.Passord,
        //        Login = sendServer.Login
        //    };

        //    try
        //    {
        //        sendService.SendMessage(sendSender.EmailAdress, sendRecip.EmailAdress, msg.Subject, msg.Body);
        //    }
        //    catch (SmtpException ex)
        //    {
        //        MessageBox.Show("Ошибка SMTP при отправке почты: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show("Ошибка при отправке почты: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //}
        #endregion
    }
}

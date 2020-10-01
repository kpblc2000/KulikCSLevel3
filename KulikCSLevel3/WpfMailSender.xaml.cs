using KulikCSLevel3.Models;
using System.Windows.Media;
using MailSender.lib;
using System.Net.Mail;
using System.Windows;
/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C# Уровень 3 урок1.
/// </summary>
namespace KulikCSLevel3
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void btnExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

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

        private void BtnSend_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //var sendSender = SenderList.SelectedItem as Sender;
            //if (sendSender is null)
            //{
            //    return;
            //}
            if (!(SenderList.SelectedItem is Sender sendSender)) return;
            if (!(RecipientList.SelectedItem is Recipient sendRecip)) return;
            if (!(Serverlist.SelectedItem is Server sendServer)) return;
            if (!(MessagesList.SelectedItem is Message msg)) return;

            var sendService = new MailSenderService
            {
                ServerAdress = sendServer.Adress,
                ServerPort = sendServer.Port,
                UseSSL = sendServer.UseSSL,
                Password = sendServer.Passord,
                Login = sendServer.Login
            };

            try
            {
                sendService.SendMail(sendSender.EmailAdress, sendRecip.EmailAdress, msg.Subject, msg.Body);
            }
            catch(SmtpException ex)
            {
                MessageBox.Show("Ошибка SMTP при отправке почты" + ex.Message,"Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка при отправке почты" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonTabScheduler_Click(object sender, RoutedEventArgs e)
        {
            TabItemScheduler.IsSelected = true;
        }
    }
}

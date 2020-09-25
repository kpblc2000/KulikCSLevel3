using System.Windows.Media;
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
    }
}

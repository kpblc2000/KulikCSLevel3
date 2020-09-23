
using System.Windows.Media;
/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C# Уровень 3 урок1.
/// </summary>
namespace KulikCSLevel3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void btnExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EmailSendSerive srv = new EmailSendSerive(MailFrom.Text, PasswordText.SecurePassword, MailTo.Text, Subject.Text, Body.Text);
            string res = srv.SendEmail(ClientDatas.ServerAdress, ClientDatas.ServerPort);
            StatusBarMessage.Text = res;
            if (srv.SendSuccess == 0)
            {
                StatusBarMessage.Foreground = Brushes.Black;
            }
            else
            {
                StatusBarMessage.Foreground = Brushes.Red;
                ErrorMessage win = new ErrorMessage();
                win.MessageText.Text = res;
                win.ShowDialog();
            }
        }
    }
}

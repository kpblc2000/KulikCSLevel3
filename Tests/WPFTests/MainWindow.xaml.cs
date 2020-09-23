using System.Net;
using System.Net.Mail;
using System.Windows;


/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C# уровень 3, урок 1
/// </summary>

namespace WPFTests
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var mess = new MailMessage(txtUser.Text, txtDest.Text);
            mess.Subject = txtHeader.Text;
            mess.Body = txtBody.Text;

            SmtpClient client = null;

            if (txtUser.Text.ToUpper().Contains("YANDEX.RU"))
            {
                client = new SmtpClient("smtp.yandex.ru", 25);
            }
            else if (txtUser.Text.ToUpper().Contains("GMAIL.COM"))
            {
                client = new SmtpClient("smtp.gmail.com", 587);
            }

            if (client!=null)
            {
                client.EnableSsl = true;

                client.Credentials = new NetworkCredential()
                {
                    UserName = txtUser.Text,
                    SecurePassword = pwdPass.SecurePassword
                };
                
                client.Send(mess);
            }
            else
            {
                MessageBox.Show("Не удалось определить порт и связь");
            }
        }
    }
}

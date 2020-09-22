using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTests
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var mess = new MailMessage("kpblc2000@yandex.ru", "shmachilin@gmail.com");
            mess.Subject = $"Заголовок от {DateTime.Now}";
            mess.Body = $"Текст тестового письма от {DateTime.Now}";

            var client = new SmtpClient("smpt.yandex.ru", 587);

            client.Credentials = new NetworkCredential
            {
                UserName = txtUser.Text,
                SecurePassword = pwdPass.SecurePassword
            };

            client.Send(mess);
        }
    }
}

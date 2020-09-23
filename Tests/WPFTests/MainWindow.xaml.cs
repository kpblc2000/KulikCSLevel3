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
    
            Console.ReadKey();
        }
    }
}

using System.Windows;

namespace KulikCSLevel3
{
    /// <summary>
    /// Логика взаимодействия для AddEditServer.xaml
    /// </summary>
    public partial class AddEditServer : Window
    {
        public AddEditServer() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

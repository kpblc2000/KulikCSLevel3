using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace KulikCSLevel3

{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App
    {
        private static IServiceProvider _Services;

        public static IServiceProvider Services
        {
            get
            {
                if (_Services is null)
                {
                    _Services = GetServices().BuildServiceProvider(); ;
                }
                return _Services;
            }
        }

        private static IServiceCollection GetServices()
        {
            ServiceCollection ser = new ServiceCollection();
            InitializeServices(ser);
            return ser;
        }

        private static void InitializeServices(IServiceCollection services)
        {
            services.AddTransient<IDialogMessageService, WinDialogMessage>();
            services.AddSingleton<KulikCSLevel3.ViewModels.MainWindowViewModel>();
        }

    }

    interface IDialogMessageService
    {
        void ShowDialog(string Message);
    }

    public class WinDialogMessage : IDialogMessageService
    {
        public void ShowDialog(string Message)
        {
            MessageBox.Show(Message);
        }
    }
}
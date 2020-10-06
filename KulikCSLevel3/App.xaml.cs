using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KulikCSLevel3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider _Services;

        public static IServiceProvider Services => _Services ??= GetServices().BuildServiceProvider();

        private static IServiceCollection GetServices()
        {
            ServiceCollection services = new ServiceCollection();
            InitServices(services);
            return services;
        }

        private static void InitServices(ServiceCollection services)
        {
            services.AddTransient<IDialogMsgBoxService, MsgBoxDialog>();
        }
    }

    interface IDialogMsgBoxService
    {
        void ShowMsgBox(string Message);
    }

    class MsgBoxDialog : IDialogMsgBoxService
    {
        public void ShowMsgBox(string Message)
        {
            MessageBox.Show(Message);
        }
    }
}

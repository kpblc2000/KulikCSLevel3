using KulikCSLevel3.Infrastructure.Commands;
using KulikCSLevel3.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private static IHost __Hosting;

        public static IHost Hosting
        {
            get
            {
                if (__Hosting != null) return __Hosting;
                var hostBuilder = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs());
                hostBuilder.ConfigureServices(ConfigureServices);
                return __Hosting = hostBuilder.Build();
            }
        }

        public static IServiceProvider Services => Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<IDialogMsgBoxService, MsgBoxDialog>();
        }


        /*
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
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<IDialogMsgBoxService, MsgBoxDialog>();
        }
        */
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

using KulikCSLevel3.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KulikCSLevel3
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App
    {
        // Контейнер сервисов
        //private static IHost _hosting;

        //public static IHost Hosting
        //{
        //    get
        //    {
        //        if (_hosting is null)
        //        {
        //            _hosting = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
        //                .ConfigureServices(ConfigService)
        //                .Build();
        //        }
        //        return _hosting;
        //    }
        //}

        //public static IServiceProvider Services => Hosting.Services;

        //private static void ConfigService(HostBuilderContext host, IServiceCollection services)
        //{
        //    services.AddSingleton<MainWindowViewModel>();
        //}

        private static IServiceProvider _services;

        private static IServiceCollection GetServices()
        {
            ServiceCollection ser = new ServiceCollection();
            InitializeServices(ser);
            return ser;
        }

        private static void InitializeServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
        }

        public static IServiceProvider Services
        {
            get
            {
                if (_services is null)
                {
                    _services = GetServices().BuildServiceProvider();
                }
                return _services;
            }
        }

    }
}

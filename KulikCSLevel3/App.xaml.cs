using KulikCSLevel3.VIewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace KulikCSLevel3
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App
    {
        // Контейнер сервисов
        private static IHost _hosting;

        public static IHost Hosting
        {
            get
            {
                if (_hosting is null)
                {
                    _hosting = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
                        .ConfigureServices(ConfigService)
                        .Build();
                }
                return _hosting;
            }
        }

        public static IServiceProvider Services => Hosting.Services;

        private static void ConfigService(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
        }
    }
}

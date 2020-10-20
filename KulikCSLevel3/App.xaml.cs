﻿using KulikCSLevel3.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;
using WpfMailSender.Data;
using WpfMailSender.Interfaces;
using WpfMailSender.Services;

namespace KulikCSLevel3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost __Hosting;

        public static readonly string ConnectionStringSql = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MailSender.DB; Integrated Security=True;";

        public static IHost Hosting
        {
            get
            {
                if (__Hosting != null) return __Hosting;
                var hostBuilder = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs());
                hostBuilder.ConfigureServices(ConfigureServices);
                hostBuilder.ConfigureAppConfiguration(c => c.AddJsonFile("AppSettings.json", true, true));
                hostBuilder.ConfigureLogging(log => log.AddConsole().AddDebug());
                return __Hosting = hostBuilder.Build();
            }
        }

        public static IServiceProvider Services => Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<IEncryptorService, Rfc2898Encryptor>();
#if DEBUG
            services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();
#endif
            services.AddTransient<IDialogMsgBoxService, MsgBoxDialog>();

            DataStorageInMemory memory_store = new DataStorageInMemory();
            services.AddSingleton<IServersStorage>(memory_store);
            services.AddSingleton<ISendersStorage>(memory_store);
            services.AddSingleton<IRecipientsStorage>(memory_store);
            services.AddSingleton<IMessagesStorage>(memory_store);

//            services.AddDbContext<MailSenderDB>(opt => opt.UseSqlServer(ConnectionStringSql));
            
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

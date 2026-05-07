using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using StockRoom11net.Data;
using StockRoom11net.BlazorWebAssembly.Data;
using StockRoom11net.Controls.DependencyInjection;

namespace StockRoom11net
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var _appHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // *** MODERN EF CORE SERVICES ***
                    services.AddDataServices(); // Add EF Core repositories and services

                    // Legacy Services (can be removed gradually)
                    services.AddSingleton<IMyService, MyService>();
                    services.AddSingleton<AppService, AppService>();

                    // Forms
                    services.AddTransient<Solutions_TempleClass>();
                    services.AddTransient<TimeLineEditor>();
                    services.AddTransient<StockRoom_Inventory>();
                })
                .Build();

            ApplicationConfiguration.Initialize();
                        
            //Application.Run(new Solutions_TempleClass());
            // Start WinForms using DI
            Application.Run(_appHost.Services.GetRequiredService<Solutions_TempleClass>());
        }
    }
}
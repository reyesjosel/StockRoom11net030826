using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using MyStuff11net.DependencyInjection;


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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // run early in Main or before the failing line
            var asm = typeof(StockRoom11net.Properties.Resources).Assembly;
            foreach (var n in asm.GetManifestResourceNames())
                Debug.WriteLine(n);


            ApplicationConfiguration.Initialize();
                        
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Services
                    services.AddSingleton<IMyService, MyService>();

                    // Forms
                    services.AddTransient<Solutions_TempleClass>();
                })
                .Build();

            // Start WinForms using DI
            Application.Run(host.Services.GetRequiredService<Solutions_TempleClass>());
            //Application.Run(new Solutions_TempleClass());
        }
    }
}
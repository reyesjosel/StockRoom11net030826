using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockRoom11net.Controls.DependencyInjection;
using StockRoom11net.Controls.VisTimeLine;
using StockRoom11net.Data;
using StockRoom11net.Data.Services;
using System.Diagnostics;

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
                    services.AddSingleton<IAppService, AppService>();
                    services.AddSingleton<ITimeLineService, TimeLineService>();

                    // Forms
                    services.AddTransient<Solutions_TempleClass>();
                    services.AddTransient<TimeLineEditor>();
                    services.AddTransient<StockRoom_Inventory>();
                    services.AddTransient<SolutionsProperties> ();
                    services.AddTransient<Employees_Management>();
                })
                .Build();

            using (var scope = _appHost.Services.CreateScope())
            {
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("Program");

                var db = scope.ServiceProvider.GetRequiredService<ProductionInventoryContext>();

                var conn = db.Database.GetDbConnection();
                logger.LogInformation("EF connection string: {Conn}", conn.ConnectionString);

                var sqliteBuilder = new SqliteConnectionStringBuilder(conn.ConnectionString);
                logger.LogInformation("SQLite DataSource (raw): {Ds}", sqliteBuilder.DataSource);
                logger.LogInformation("SQLite DataSource (full path): {FullPath}", Path.GetFullPath(sqliteBuilder.DataSource));

                logger.LogInformation("Environment.CurrentDirectory: {Cwd}", Environment.CurrentDirectory);
            }

            ApplicationConfiguration.Initialize();

            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new Solutions_TempleClass());
            // Start WinForms using DI
            Application.Run(_appHost.Services.GetRequiredService<Solutions_TempleClass>());                        
        }
    }
}
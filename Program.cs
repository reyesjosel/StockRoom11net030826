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
        // Application Insights connection string
        //InstrumentationKey=a2f8bfc5-5b9c-422e-9fd0-56488d07c17c;IngestionEndpoint=https://eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/;ApplicationId=67b98137-640e-4cac-a45b-31b64d5bbe8b
        private const string AppInsightsConnectionString = "InstrumentationKey=a2f8bfc5-5b9c-422e-9fd0-56488d07c17c;IngestionEndpoint=https://eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/;ApplicationId=67b98137-640e-4cac-a45b-31b64d5bbe8b";

        public static TelemetryClient Telemetry { get; private set; } = null!;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize Application Insights telemetry
            var telemetryConfig = TelemetryConfiguration.CreateDefault();
            telemetryConfig.ConnectionString = AppInsightsConnectionString;
            Telemetry = new TelemetryClient(telemetryConfig);
            Telemetry.TrackEvent("AppStarted");

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

            if(Debugger.IsAttached)
            {
                Telemetry.TrackEvent("AppStoppedDebug");
            }
            else
            {
                Telemetry.TrackEvent("AppStopped");
                Telemetry.Flush();
                Task.Delay(1000).Wait(); // Give telemetry time to send
            }
        }
    }
}
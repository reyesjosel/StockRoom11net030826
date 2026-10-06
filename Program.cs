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
using System.IO.Compression;
using static StockRoom11net.Controls.FileSystemEnumerator.UsingKernel32;

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
            ApplicationConfiguration.Initialize();

            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ensure the SQLite database directory exists (or ask the user to
            // choose a location) BEFORE the DbContext/connection string is
            // registered, otherwise SQLite Error 14 ("unable to open database
            // file") is thrown when the connection is first opened.
            EnsureDatabaseLocation();

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
                    services.AddTransient<SolutionsProperties>();
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

                var dbFullPath = Path.GetFullPath(sqliteBuilder.DataSource);
                logger.LogInformation("SQLite DataSource (full path): {FullPath}", dbFullPath);

                logger.LogInformation("Environment.CurrentDirectory: {Cwd}", Environment.CurrentDirectory);
            }

            //Application.Run(new Solutions_TempleClass());
            // Start WinForms using DI
            Application.Run(_appHost.Services.GetRequiredService<Solutions_TempleClass>());
        }

        private static readonly string[] RequiredSubFolders = { "LogFile", "Pictures", "Projects", "DataSheets", "Resources" };

        /// <summary>
        /// Verifies that the application's folder structure exists: the root folder
        /// (e.g. "ProductionManagement") that contains the SQLite database file, and
        /// its required subfolders ("LogFile", "Pictures", "Projects", "DataSheets", "Resources").
        /// If anything is missing, prompts the user (via FolderBrowserDialog) to choose
        /// a location to create the structure, then persists the resulting connection
        /// string to user settings so the choice is remembered on subsequent launches.
        /// </summary>
        private static void EnsureDatabaseLocation()
        {
            // Such as: "data source=D:\ProductionManagement\ProductionInventory.sqlite"
            var connectionString = Properties.Settings.Default.DataBaseConnectionStringSQLite;
            var builder = new SqliteConnectionStringBuilder(connectionString);

            // The database file name is authoritative from the DataBaseName setting.
            // Fall back to the connection string's file name if DataBaseName is not set.
            // TODO: Consider validating that the file name ends with ".sqlite" and prompting the user if it doesn't.
            var fileName = Properties.Settings.Default.DataBaseName; //NoSetYet.sqlite / "ProductionInventory.sqlite";
            if (string.IsNullOrWhiteSpace(fileName) || fileName == "NoSetYet.sqlite")
            {
                fileName = "ProductionInventory.sqlite";
                Properties.Settings.Default.DataBaseName = fileName;
            }

            // The root application folder is authoritative from the DataBaseAddress setting.
            // Fall back to the connection string's directory if DataBaseAddress is not set.
            // TODO: Consider validating that the folder name is a valid path and prompting the user if it isn't.
            var rootDirectory = Properties.Settings.Default.DataBaseAddress; //C:\\NoSetYet / "D:\\ProductionManagement";
            if (string.IsNullOrWhiteSpace(rootDirectory) || rootDirectory == "C:\\NoSetYet")
            {
                rootDirectory = "C:\\ProductionManagement";
                Properties.Settings.Default.DataBaseAddress = rootDirectory ?? string.Empty;
            }

            if (string.IsNullOrEmpty(rootDirectory))
                return;

            var databaseFileExists = File.Exists(Path.Combine(rootDirectory, fileName));
            var folderStructureComplete = IsFolderStructureComplete(rootDirectory);

            if (folderStructureComplete && databaseFileExists)
            {
                Properties.Settings.Default.Save();
                return;
            }

            if (!folderStructureComplete)
            {
                // The root folder and/or one or more required subfolders are missing.
                // Ask the user for a location (a folder, not a specific file) where the
                // application's folder structure should be created.
                var rootFolderName = Path.GetFileName(rootDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

                using var folderDialog = new FolderBrowserDialog
                {
                    Description = $"The application folder structure (\"{rootFolderName}\" and its subfolders) " +
                                  "was not found or is incomplete.\n" +
                                  "Please choose a location where it should be created.",
                    UseDescriptionForTitle = true,
                    ShowNewFolderButton = true
                };

                if (folderDialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    MessageBox.Show("The application folder structure could not be created. " +
                                     "The application will not be able to run correctly.",
                                     "Application Folder Not Found",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Environment.Exit(1);
                    return;
                }

                // The chosen folder becomes the new root directory (e.g. "ProductionManagement").
                rootDirectory = Path.Combine(folderDialog.SelectedPath, rootFolderName);
                CreateFolderStructure(rootDirectory);

                Properties.Settings.Default.DataBaseAddress = rootDirectory;
                Properties.Settings.Default.Save();
            }

            var databasePath = Path.Combine(rootDirectory, fileName);
            if (!File.Exists(databasePath))
            {
                CreateDataBaseFile(rootDirectory);

                Properties.Settings.Default.DataBaseConnectionStringSQLite = new SqliteConnectionStringBuilder
                                                                            {
                                                                                DataSource = databasePath
                                                                            }.ConnectionString;

                Properties.Settings.Default.DataBaseAddress = rootDirectory;
                Properties.Settings.Default.DataBaseName = fileName;
                Properties.Settings.Default.Save();
            }

            builder.DataSource = databasePath;

            Properties.Settings.Default.DataBaseConnectionStringSQLite = builder.ConnectionString;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Returns true if the root folder and all required subfolders already exist.
        /// </summary>
        private static bool IsFolderStructureComplete(string rootDirectory)
        {
            if (!Directory.Exists(rootDirectory))
                return false;

            foreach (var subFolder in RequiredSubFolders)
            {
                if (!Directory.Exists(Path.Combine(rootDirectory, subFolder)))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Creates the root folder and any missing required subfolders under it.
        /// If a subfolder is missing and a matching "&lt;subfolder&gt;.zip" archive is found
        /// (next to the application executable), its contents are extracted to create the
        /// folder and populate it. Otherwise, an empty folder is created.
        /// </summary>
        private static void CreateFolderStructure(string rootDirectory)
        {
            if (!Directory.Exists(rootDirectory))
                Directory.CreateDirectory(rootDirectory);

            foreach (var subFolder in RequiredSubFolders)
            {
                var subFolderPath = Path.Combine(rootDirectory, subFolder);
                if (!Directory.Exists(subFolderPath))
                {
                    var zipPath = Path.Combine(AppContext.BaseDirectory, subFolder + ".zip");

                    if (File.Exists(zipPath))
                    {
                        // ExtractToDirectory creates subFolderPath automatically.
                        ZipFile.ExtractToDirectory(zipPath, subFolderPath, overwriteFiles: true);
                    }
                    else
                    {
                        Directory.CreateDirectory(subFolderPath);
                    }
                }
            }
        }

        private static void CreateDataBaseFile(string rootDirectory)
        {
            var dataBasePath = Path.Combine(rootDirectory, Properties.Settings.Default.DataBaseName);
            if (!File.Exists(dataBasePath))
            {
                var zipFilePath = Path.Combine(AppContext.BaseDirectory, "ProductionInventory.zip");
                var sqliteFilePath = Path.Combine(rootDirectory, "ProductionInventory.sqlite");

                if(File.Exists(sqliteFilePath))
                {
                    MessageBox.Show($"The database file already exists at {sqliteFilePath}. " + Environment.NewLine +
                                    $"It will be overwritten with the contents of {zipFilePath}." + Environment.NewLine +
                                    $"Save or rename your database; this installation will be aborted.",
                                    "Database File Exists",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Environment.Exit(1);
                }

                if (File.Exists(zipFilePath))
                {
                    using var archive = ZipFile.OpenRead(zipFilePath);
                    var entry = archive.GetEntry("ProductionInventory.sqlite");
                    if (entry != null)
                    {
                        entry.ExtractToFile(dataBasePath, overwrite: true);
                    }
                }
            }
        }

    }
}
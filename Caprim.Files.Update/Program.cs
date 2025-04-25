using Caprim.Files.Update.Core.Ports.Input;
using Caprim.Files.Update.Core.Ports.Output;
using Caprim.Files.Update.Core.Strategy;
using Caprim.Files.Update.Core.UseCases;
using Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;
using Caprim.Files.Update.Infrastructure.Adapters.Persistence;
using Caprim.Files.Update.Presentation.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using System.Windows.Forms;

namespace Caprim.Files.Update
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: true, reloadOnChange: true)
                .Build();

            // Asegurar que el directorio de logs exista
            var logsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
            if (!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
            }

            // Configurar Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Iniciando aplicación Caprim.Files.Update");

                var services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(configuration);
                ConfigureServices(services, configuration);

                using var serviceProvider = services.BuildServiceProvider();
                var form = serviceProvider.GetRequiredService<PrincipalForm>();

                Application.Run(form);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "La aplicación falló al iniciar");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de Logging
            services.AddLogging(configure =>
            {
                configure.ClearProviders();
                configure.AddSerilog(dispose: true);
            });

            // Database
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MariaDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Forms
            services.AddTransient<PrincipalForm>();
            services.AddTransient<ExternalPayForm>();
            services.AddTransient<ProcesarArchivosForm>();
            services.AddTransient<ClienteForm>();

            // Use Cases
            services.AddScoped<IFileImportUseCase, FileImportUseCase>();

            // Adapters
            services.AddScoped<CsvAdapter>();
            services.AddScoped<ExcelAdapter>();

            // Processors (Strategy Pattern)
            services.AddScoped<BinanceP2PCsvProcessor>();
            services.AddScoped<BinanceSpotExcelProcessor>();
            services.AddScoped<IFileProcessorFactory, FileProcessorFactory>();

            // Repositories
            services.AddScoped(typeof(ITradeRepository<>), typeof(TradeRepository<>));
        }
    }
}
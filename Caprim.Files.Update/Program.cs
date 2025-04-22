using Caprim.Files.Update.Core.Ports.Input;
using Caprim.Files.Update.Core.Ports.Output;
using Caprim.Files.Update.Core.UseCases;
using Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;
using Caprim.Files.Update.Infrastructure.Adapters.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            ConfigureServices(services, configuration);

            using var serviceProvider = services.BuildServiceProvider();
            var form = serviceProvider.GetRequiredService<Form1>();

            Application.Run(form);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Logging
            services.AddLogging(configure => configure.AddConsole());

            // Database
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MariaDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Form
            services.AddTransient<Form1>();

            // Use Cases
            services.AddScoped<IFileImportUseCase, FileImportUseCase>();

            // Adapters
            services.AddScoped<CsvAdapter>();
            services.AddScoped<ExcelAdapter>();

            // Repositories
            services.AddScoped(typeof(ITradeRepository<>), typeof(TradeRepository<>));
        }
    }
}
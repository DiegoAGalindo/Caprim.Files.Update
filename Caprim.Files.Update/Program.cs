using Caprim.Files.Update.Core.Ports.Input;
using Caprim.Files.Update.Core.Ports.Output;
using Caprim.Files.Update.Core.UseCases;
using Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;
using Caprim.Files.Update.Infrastructure.Adapters.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update
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
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            using var serviceProvider = services.BuildServiceProvider();
            var form = serviceProvider.GetRequiredService<Form1>();
            
            Application.Run(form);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Logging
            services.AddLogging(configure => configure.AddConsole());

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
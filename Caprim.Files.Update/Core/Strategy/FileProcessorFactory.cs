using Caprim.Files.Update.Domain.Models;
using Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update.Core.Strategy;

public class FileProcessorFactory : IFileProcessorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<FileProcessorFactory> _logger;

    public FileProcessorFactory(IServiceProvider serviceProvider, ILogger<FileProcessorFactory> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public IFileProcessor<T> GetProcessor<T>(string fileType) where T : class
    {
        _logger.LogInformation("Solicitando procesador para tipo: {FileType} y modelo: {ModelType}", fileType, typeof(T).Name);
        
        if (typeof(T) == typeof(BinanceP2P) && fileType.ToLower() == "binancep2p")
        {
            return (IFileProcessor<T>)_serviceProvider.GetService(typeof(BinanceP2PCsvProcessor));
        }
        else if (typeof(T) == typeof(BinanceSpotHistory) && fileType.ToLower() == "binanceorderspot")
        {
            return (IFileProcessor<T>)_serviceProvider.GetService(typeof(BinanceSpotExcelProcessor));
        }
        
        throw new InvalidOperationException($"No se encontró procesador para tipo: {fileType} y modelo: {typeof(T).Name}");
    }
} 
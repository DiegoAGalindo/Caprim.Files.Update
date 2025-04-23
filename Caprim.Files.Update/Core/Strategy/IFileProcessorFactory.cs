namespace Caprim.Files.Update.Core.Strategy;

public interface IFileProcessorFactory
{
    /// <summary>
    /// Obtiene el procesador de archivos adecuado según el tipo de archivo
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que se procesará</typeparam>
    /// <param name="fileType">Tipo de archivo a procesar</param>
    /// <returns>Procesador de archivos apropiado</returns>
    IFileProcessor<T> GetProcessor<T>(string fileType) where T : class;
} 
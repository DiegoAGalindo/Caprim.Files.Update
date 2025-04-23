namespace Caprim.Files.Update.Core.Strategy;

public interface IFileProcessor<T> where T : class
{
    /// <summary>
    /// Procesa un archivo y devuelve una colección de entidades del tipo especificado
    /// </summary>
    /// <param name="filePath">Ruta del archivo a procesar</param>
    /// <returns>Colección de entidades extraídas del archivo</returns>
    Task<IEnumerable<T>> ProcessAsync(string filePath);
} 
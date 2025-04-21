namespace Caprim.Files.Update.Core.Ports.Input;

public interface IFileImportUseCase
{
    Task<(bool Success, string Message)> ImportFileAsync(string filePath, string fileType);

    Task<(bool Success, string Message)> ProcessDirectoryAsync(string directoryPath, string fileType);
}
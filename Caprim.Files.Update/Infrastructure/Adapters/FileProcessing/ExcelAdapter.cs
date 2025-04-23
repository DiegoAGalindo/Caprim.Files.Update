using ClosedXML.Excel;
using Caprim.Files.Update.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;

public class ExcelAdapter
{
    private readonly ILogger<ExcelAdapter> _logger;

    public ExcelAdapter(ILogger<ExcelAdapter> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<BinanceSpotHistory>> ReadBinanceSpotHistoryAsync(string filePath)
    {
        _logger.LogInformation("Iniciando lectura del archivo Spot: {FilePath}", filePath);
        var trades = new List<BinanceSpotHistory>();

        await Task.Run(() => {
            try
            {
                _logger.LogDebug("Abriendo archivo Excel: {FileName}", Path.GetFileName(filePath));
                using var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheet(1);
                
                // Determinar el rango de datos reales para evitar procesamiento innecesario
                var usedRange = worksheet.RangeUsed();
                if (usedRange == null)
                {
                    _logger.LogWarning("El archivo {FileName} parece estar vacío, no se encontró ningún rango de datos", 
                        Path.GetFileName(filePath));
                    return;
                }
                
                _logger.LogDebug("Rango de datos encontrado: {RowCount} filas en archivo {FileName}", 
                    usedRange.RowCount(), Path.GetFileName(filePath));
                
                var rows = worksheet.RowsUsed().Skip(1); // Omitir encabezado
                var processedRows = 0;
                var errorRows = 0;

                foreach (var row in rows)
                {
                    try
                    {
                        var rowNumber = row.RowNumber();
                        
                        var trade = new BinanceSpotHistory
                        {
                            DateUtc = DateTime.Parse(row.Cell(1).GetString()),
                            OrderNo = row.Cell(2).GetString(),
                            Pair = row.Cell(3).GetString(),
                            BaseAsset = row.Cell(4).GetString(),
                            QuoteAsset = row.Cell(5).GetString(),
                            Type = row.Cell(6).GetString(),
                            OrderPrice = decimal.TryParse(row.Cell(7).GetString(), out var orderPrice) ? orderPrice : 0,
                            OrderAmount = decimal.TryParse(row.Cell(8).GetString(), out var orderAmount) ? orderAmount : 0,
                            AvgTradingPrice = decimal.TryParse(row.Cell(9).GetString(), out var avgPrice) ? avgPrice : 0,
                            Filled = decimal.TryParse(row.Cell(10).GetString(), out var filled) ? filled : 0,
                            Total = decimal.TryParse(row.Cell(11).GetString(), out var total) ? total : 0,
                            Status = row.Cell(13).GetString()
                        };

                        trades.Add(trade);
                        processedRows++;
                        
                        if (processedRows % 1000 == 0)
                        {
                            _logger.LogDebug("Procesadas {RowCount} filas del archivo {FileName}", 
                                processedRows, Path.GetFileName(filePath));
                        }
                    }
                    catch (Exception ex)
                    {
                        errorRows++;
                        _logger.LogError(ex, "Error procesando fila #{RowNumber} en archivo {FilePath}: {ErrorMessage}", 
                            row.RowNumber(), Path.GetFileName(filePath), ex.Message);
                    }
                }

                _logger.LogInformation("Lectura completada de archivo {FileName}. {RowCount} filas procesadas, {ErrorCount} errores", 
                    Path.GetFileName(filePath), processedRows, errorRows);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error crítico al leer el archivo Excel {FilePath}: {ErrorMessage}", 
                    Path.GetFileName(filePath), ex.Message);
                throw;
            }
        });

        return trades;
    }
}
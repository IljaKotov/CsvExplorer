namespace CsvExplorer.Interfaces;

public interface IFileDataService
{
	IAsyncEnumerable<string> GetAllFileRowsAsync(string filePath);
}
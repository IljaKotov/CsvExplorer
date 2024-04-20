namespace CsvExplorer.Interfaces;

public interface IFileDataService
{
	IAsyncEnumerable<string> EnumerateAllFileRowsAsync(string filePath);
}
namespace CSVExplorer.Interfaces;

public interface IFileDataService
{
	public IAsyncEnumerable<string> GetAllFileRows(string filePath);
}
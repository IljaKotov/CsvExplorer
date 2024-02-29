namespace CSVExplorer.Interfaces;

public interface IAsyncIOHandler
{
	Task<string[]> ReadFileAsync(string path);
}
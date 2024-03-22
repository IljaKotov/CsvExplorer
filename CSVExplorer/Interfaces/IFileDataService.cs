namespace CSVExplorer.Interfaces;

public interface IFileDataService
{
	public Task<List<string>> GetAllFileRows(string filePath);
}
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class FileDataService : IFileDataService
{
	public async Task<List<string>> GetAllFileRows(string filePath)
	{
		Exceptions.FileNotFoundException.ThrowIfFileNotFound(filePath);

		try
		{
			return new List<string>(await File.ReadAllLinesAsync(filePath));
		}
		catch (Exception ex)
		{
			Exceptions.FileReadException.ThrowIfFileReadError(ex);

			return new List<string>();
		}
	}
}
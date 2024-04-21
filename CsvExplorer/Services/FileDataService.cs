using CsvExplorer.Interfaces;

namespace CsvExplorer.Services;

internal class FileDataService : IFileDataService
{
	public async IAsyncEnumerable<string> EnumerateAllFileRowsAsync(string filePath)
	{
		if (File.Exists(filePath) is false)
		{
			throw new FileNotFoundException();
		}

		await foreach (var line in File.ReadLinesAsync(filePath))
			yield return line;
	}
}
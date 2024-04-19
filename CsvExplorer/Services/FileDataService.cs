using CsvExplorer.Interfaces;

namespace CsvExplorer.Services;

internal class FileDataService : IFileDataService
{
	public async IAsyncEnumerable<string> GetAllFileRowsAsync(string filePath)
	{
		if (File.Exists(filePath) is false)
		{
			throw new FileNotFoundException();
		}

		using var reader = new StreamReader(filePath);

		while (reader.EndOfStream is false)
		{
			var line = await reader.ReadLineAsync();

			yield return line ?? throw new InvalidOperationException();
		}
	}
}
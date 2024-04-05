using CSVExplorer.Exceptions;
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class FileDataService : IFileDataService
{
	public async IAsyncEnumerable<string> GetAllFileRows(string filePath)
	{
		ValidateFilePath(filePath);

		using var reader = new StreamReader(filePath);

		while (!reader.EndOfStream)
		{
			string? line;

			try
			{
				if ((line = await reader.ReadLineAsync()) is null)
					break;
			}
			catch (Exception ex)
			{
				FileReadException.ThrowIfFileReadError(ex);

				yield break;
			}

			yield return line;
		}
	}
	
	private static void ValidateFilePath(string filePath)
	{
		 if (File.Exists(filePath) is false)
			throw new FileNotFoundException();
	}
}
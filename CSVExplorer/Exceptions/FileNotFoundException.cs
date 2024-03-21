namespace CSVExplorer.Exceptions;

public class FileNotFoundException(string message) : Exception(message)
{
	public static void ThrowIfFileNotFound(string filePath)
	{
		if (File.Exists(filePath) is false)
		{
			throw new FileNotFoundException($"File {filePath} not found.");
		}
	}
}
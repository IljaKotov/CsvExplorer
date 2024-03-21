namespace CSVExplorer.Exceptions;

public class EmptyFileException(string message) : Exception(message)
{
	public static void ThrowIfFileIsEmpty(List<string> lines)
	{
		if (lines.Count == 0)
		{
			throw new EmptyFileException("File is empty.");
		}
	}
}
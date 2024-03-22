namespace CSVExplorer.Exceptions;

public class EmptyFileException(string message) : Exception(message)
{
	private const string ExceptionMessage = "File is empty.";

	public static void ThrowIfFileIsEmpty(List<string> lines)
	{
		if (lines.Count == 0)
		{
			throw new EmptyFileException(ExceptionMessage);
		}
	}
}
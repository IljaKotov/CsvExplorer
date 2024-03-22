namespace CSVExplorer.Exceptions;

public class FileReadException(string message, Exception innerException) : Exception(message, innerException)
{
	private const string ExceptionMessage = "Error reading file: ";

	public static void ThrowIfFileReadError(Exception ex)
	{
		throw new FileReadException($"{ExceptionMessage}{ex.Message}", ex);
	}
}
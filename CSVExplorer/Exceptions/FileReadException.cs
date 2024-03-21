namespace CSVExplorer.Exceptions;

public class FileReadException(string message, Exception innerException) : Exception(message, innerException)
{
	public static void ThrowIfFileReadError(Exception ex)
	{
		throw new FileReadException($"Error reading file: {ex.Message}", ex);
	}
}
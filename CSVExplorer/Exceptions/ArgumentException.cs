namespace CSVExplorer.Exceptions;

public class ArgumentException(string message) : Exception(message)
{
	public static void ThrowIfNullOrWhiteSpace(string value, string paramName)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new ArgumentException($"Parameter {paramName} cannot be null or whitespace.");
		}
	}
}
namespace CSVExplorer.Exceptions;

public class ArgumentException(string message) : Exception(message)
{
	public static void ThrowIfNullOrWhiteSpace(string[]? value, string paramName)
	{
		if (value is null || value.Length == 0)
		{
			throw new ArgumentException($"Parameter {paramName} cannot be null or empty.");
		}
	}
}
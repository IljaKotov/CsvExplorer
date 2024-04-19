namespace CsvExplorer.Exceptions;

public class EmptyFileException : Exception
{
	private const string ExceptionMessage = "File is empty.";

	public EmptyFileException() : base(ExceptionMessage)
	{
	}
}
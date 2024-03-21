using CSVExplorer.Exceptions;
using CSVExplorer.Interfaces;
using ArgumentException = CSVExplorer.Exceptions.ArgumentException;
using FileNotFoundException = CSVExplorer.Exceptions.FileNotFoundException;

namespace CSVExplorer.Models;

public class CommandLineFileReader(string[] args) : IFileReader
{
	public string GetFilePathFromUser()
	{
		const string whitespace = " ";
		const string exMsg = "File path not provided in command line arguments.";

		if (args.Length > 0)
		{
			return args[0];
		}

		ArgumentException.ThrowIfNullOrWhiteSpace(whitespace, exMsg);

		return string.Empty;
	}

	public List<string> ReadFile(string filePath)
	{
		FileNotFoundException.ThrowIfFileNotFound(filePath);

		try
		{
			var lines = new List<string>(File.ReadAllLines(filePath));

			return lines;
		}
		catch (Exception ex)
		{
			FileReadException.ThrowIfFileReadError(ex);

			return new List<string>();
		}
	}
}
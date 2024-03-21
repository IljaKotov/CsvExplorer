using CSVExplorer.Exceptions;
using CSVExplorer.Interfaces;
using ArgumentException = CSVExplorer.Exceptions.ArgumentException;
using FileNotFoundException = CSVExplorer.Exceptions.FileNotFoundException;

namespace CSVExplorer.Models;

public class ConsoleFileReader : IFileReader
{
	public string GetFilePathFromUser()
	{
		const string exMsg = "File path not provided in Console.";

		Console.WriteLine("Please enter the path to the CSV file:");

		var filePath = Console.ReadLine();

		ArgumentNullException.ThrowIfNull(filePath);
		ArgumentException.ThrowIfNullOrWhiteSpace(filePath, exMsg);

		return filePath;
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
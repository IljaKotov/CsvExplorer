using CSVExplorer.Interfaces;

namespace CSVExplorer.Providers;

internal class ConsoleFilePathProvider : IFilePathProvider
{
	public string GetFilePath()
	{
		const string inviteToEnterPath = "Please enter the full path to the CSV file:";

		Console.WriteLine(inviteToEnterPath);

		var filePath = Console.ReadLine();

		ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

		return filePath;
	}
}
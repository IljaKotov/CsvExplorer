using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class CombinedFilePathProvider : IFilePathProvider
{
	private readonly CommandLineFilePathProvider _commandLineFilePathProvider;
	private readonly ConsoleFilePathProvider _consoleFilePathProvider;

	public CombinedFilePathProvider(CommandLineFilePathProvider commandLineFilePathProvider,
		ConsoleFilePathProvider consoleFilePathProvider)
	{
		_commandLineFilePathProvider = commandLineFilePathProvider;
		_consoleFilePathProvider = consoleFilePathProvider;
	}

	public string GetFilePath()
	{
		var filePath = _commandLineFilePathProvider.GetFilePath();

		if (string.IsNullOrWhiteSpace(filePath))
			filePath = _consoleFilePathProvider.GetFilePath();
		
		return filePath;
	}
}
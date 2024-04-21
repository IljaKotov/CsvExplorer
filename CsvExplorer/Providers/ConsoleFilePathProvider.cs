using CsvExplorer.Interfaces;
using CsvExplorer.Models;
using Microsoft.Extensions.Options;

namespace CsvExplorer.Providers;

internal class ConsoleFilePathProvider : IFilePathProvider
{
	private readonly MessageOptions _messages;

	public ConsoleFilePathProvider(IOptions<MessageOptions> messageOptions)
	{
		_messages = messageOptions.Value;
	}

	public string GetFilePath()
	{
		string? filePath;

		do
		{
			Console.WriteLine(_messages.InviteToEnterPath);
			filePath = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(filePath) is false && File.Exists(filePath))
			{
				break;
			}

			Console.WriteLine(_messages.InvalidPathMessage);
		} while (true);

		return filePath;
	}
}
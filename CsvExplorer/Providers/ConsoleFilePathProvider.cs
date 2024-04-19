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
		Console.WriteLine(_messages.InviteToEnterPath);
		var filePath = Console.ReadLine();

		ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

		return filePath;
	}
}
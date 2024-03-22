using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class CommandLineFilePathProvider(string[] args) : IFilePathProvider
{
	public string GetFilePath()
	{
		const string exMsg = "'file path'";

		if (args.Length > 0)
			return args[0];

		Exceptions.ArgumentException.ThrowIfNullOrWhiteSpace(args, exMsg);

		return string.Empty;
	}
}
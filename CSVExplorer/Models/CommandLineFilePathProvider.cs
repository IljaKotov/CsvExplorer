using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class CommandLineFilePathProvider : IFilePathProvider
{
	private readonly string[] _args;

	public CommandLineFilePathProvider(string[] args)
	{
		_args = args;
	}

	public string GetFilePath()
	{
		if (_args.Length > 1 && File.Exists(_args[1]) &&
			Path.GetExtension(_args[1]).Equals(".csv", StringComparison.OrdinalIgnoreCase))
		{
			return _args[1];
		}

		return string.Empty;
	}
}
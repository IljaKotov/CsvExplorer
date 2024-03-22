using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class CsvAnalyzerRunner(IFileDataAnalyzer fileDataAnalyzer, IConsolePrintResult printResult)
{
	public void RunWithConsole()
	{
		Run(new ConsoleFilePathProvider());
	}

	public void RunWithCommandLine(string[] args)
	{
		Run(new CommandLineFilePathProvider(args));
	}

	private void Run(IFilePathProvider filePathProvider)
	{
		IFileDataService fileDataService = new FileDataService();
		var lines = fileDataService.GetAllFileRows(filePathProvider.GetFilePath());

		var result = fileDataAnalyzer.Analyze(lines.Result);
		printResult.PrintAllResults(result);
	}
}
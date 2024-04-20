using CsvExplorer.Interfaces;

namespace CsvExplorer.Utilities;

public class AnalyzerRunner : IAnalyzerRunner
{
	private readonly IFileDataAnalyzer _fileDataAnalyzer;
	private readonly IConsolePrintResult _printResult;
	private readonly IFileDataService _fileDataService;

	public AnalyzerRunner(IFileDataAnalyzer fileDataAnalyzer,
		IConsolePrintResult printResult,
		IFileDataService fileDataService)
	{
		_fileDataAnalyzer = fileDataAnalyzer;
		_printResult = printResult;
		_fileDataService = fileDataService;
	}

	public async Task RunAsync(string filePath)
	{
		var lines = _fileDataService.EnumerateAllFileRowsAsync(filePath);

		var result = await _fileDataAnalyzer.AnalyzeAsync(lines);

		_printResult.PrintAllResults(result);
	}
}
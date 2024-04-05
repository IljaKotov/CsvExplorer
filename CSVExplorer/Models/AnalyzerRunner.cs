using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class AnalyzerRunner : IAnalyzerRunner
{
	private readonly IFileDataAnalyzer _fileDataAnalyzer;
	private readonly IConsolePrintResult _printResult;
	private readonly IFilePathProvider _filePathProvider;
	private readonly IFileDataService _fileDataService;

	public AnalyzerRunner(IFileDataAnalyzer fileDataAnalyzer,
		IConsolePrintResult printResult,
		IFilePathProvider filePathProvider,
		IFileDataService fileDataService)
	{
		_fileDataAnalyzer = fileDataAnalyzer;
		_printResult = printResult;
		_filePathProvider = filePathProvider;
		_fileDataService = fileDataService;
	}

	public async Task RunAsync()
	{
		var filePath = _filePathProvider.GetFilePath();
		
		var lines = _fileDataService.GetAllFileRows(filePath);

		var result = await _fileDataAnalyzer.Analyze(lines);

		_printResult.PrintAllResults(result);
	}

	public async Task RunAsync(string filePath)
	{
		var lines = _fileDataService.GetAllFileRows(filePath);

		var result = await _fileDataAnalyzer.Analyze(lines);

		_printResult.PrintAllResults(result);
	}
}
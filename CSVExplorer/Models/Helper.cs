using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class Helper
{
	private readonly ICsvFileAnalyzer _csvFileAnalyzer = new CsvFileAnalyzer();
	private readonly IConsolePrintResult _consolePrintResult = new ConsolePrintResult();

	public void Run()
	{
		IFileReader fileReader = new ConsoleFileReader();
		var lines = fileReader.ReadFile(fileReader.GetFilePathFromUser());

		var result = _csvFileAnalyzer.ProcessCsvFile(lines);
		_consolePrintResult.PrintAllResults(result);
	}
}
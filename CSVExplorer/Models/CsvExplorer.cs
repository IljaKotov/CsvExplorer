using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class CsvExplorer : ICsvExplorer
{

	private readonly ICsvParser _csvParser;
	private readonly IDataAnalyzer _dataAnalyzer;
	private readonly IFileReader _fileReader;
	private readonly IResultPrinter _resultPrinter;
	private readonly IFileValidator _fileValidator;

	public CsvExplorer(ICsvParser csvParser,
		IDataAnalyzer dataAnalyzer,
		IFileReader fileReader,
		IResultPrinter resultPrinter,
		IFileValidator fileValidator)
	{
		_csvParser = csvParser;
		_dataAnalyzer = dataAnalyzer;
		_fileReader = fileReader;
		_resultPrinter = resultPrinter;
		_fileValidator = fileValidator;
	}

	public void ExploreCsv(string path)
	{
		// Реалізація
	}
}
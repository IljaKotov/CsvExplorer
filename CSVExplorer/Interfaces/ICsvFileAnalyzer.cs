using CSVExplorer.Models;

namespace CSVExplorer.Interfaces;

public interface ICsvFileAnalyzer
{
	public AnalyzingResult ProcessCsvFile(List<string> rows);
}
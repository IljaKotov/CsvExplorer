using CSVExplorer.Models;

namespace CSVExplorer.Interfaces;

public interface IConsolePrintResult
{
	void PrintMaxSum(int rowNumber, double sum);
	void PrintMinSum(int rowNumber, double sum);
	void PrintNonNumericRows(List<int> rowNumbers);
	void PrintAllResults(AnalyzingResult result);
}
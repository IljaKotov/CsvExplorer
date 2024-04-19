using CsvExplorer.Models;

namespace CsvExplorer.Interfaces;

public interface IConsolePrintResult
{
	void PrintAllResults(AnalysisResult result);
}
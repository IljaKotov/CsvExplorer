using CsvExplorer.Models;

namespace CsvExplorer.Interfaces;

public interface IRowAnalyzer
{
	AnalysisRowResult TryGetRowSum(string row);
}
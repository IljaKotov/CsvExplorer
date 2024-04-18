using CSVExplorer.Models;

namespace CSVExplorer.Interfaces;

public interface IRowAnalyzer
{
	public AnalysisRowResult TryGetRowSum(string row);
}
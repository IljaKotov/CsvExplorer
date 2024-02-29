using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class DataAnalyzer : IDataAnalyzer
{
	public (int maxSumRowNumber, List<int> nonNumericRows) AnalyzeData(List<List<string>> data)
	{
		throw new NotImplementedException();
	}
}
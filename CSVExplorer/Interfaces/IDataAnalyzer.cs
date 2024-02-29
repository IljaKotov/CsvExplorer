namespace CSVExplorer.Interfaces;

public interface IDataAnalyzer
{
	(int maxSumRowNumber, List<int> nonNumericRows) AnalyzeData(List<List<string>> data);
}
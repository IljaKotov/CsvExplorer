namespace CSVExplorer.Interfaces;

public interface IResultPrinter
{
	void PrintResult(int maxSumRowNumber, int minSumRowNumber, List<int> nonNumericRows);
}
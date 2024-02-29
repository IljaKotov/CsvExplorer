namespace CSVExplorer.Interfaces;

public interface IOutputGenerator
{
	void GenerateOutput(int maxSumRowNumber, int minSumRowNumber, List<int> nonNumericRows);
}
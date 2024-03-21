namespace CSVExplorer.Interfaces;

public interface ICsvRowAnalyzer
{
	public (double, bool) CalculateRowSumAndValidity(string row);
}
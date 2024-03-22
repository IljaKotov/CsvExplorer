namespace CSVExplorer.Interfaces;

public interface IRowAnalyzer
{
	public (double, bool) TryGetRowSum(string row);
}
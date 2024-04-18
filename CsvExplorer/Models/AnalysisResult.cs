namespace CSVExplorer.Models;

public record AnalysisResult
{
	public List<int>? InvalidRowsIndexes { get; init; }
	public int MinIndex { get; init; }
	public double MinRowSum { get; init; }
	public int MaxIndex { get; init; }
	public double MaxRowSum { get; init; }
}
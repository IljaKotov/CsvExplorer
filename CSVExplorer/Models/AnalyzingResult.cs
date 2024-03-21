namespace CSVExplorer.Models;

public record AnalyzingResult
{
	public List<int>? InvalidRows { get; init; }
	public int MinRowIndex { get; init; }
	public double MinRowSum { get; init; }
	public int MaxRowIndex { get; init; }
	public double MaxRowSum { get; init; }
}
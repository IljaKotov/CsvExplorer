namespace CsvExplorer.Tests.TestCases;

public class TestCase
{
	public string[] InputRows { get; init; } =
		Array.Empty<string>();

	public double MinSum { get; init; }
	public double MaxSum { get; init; }
	public int MinRowIndex { get; init; }
	public int MaxRowIndex { get; init; }

	public int[] InvalidRows { get; init; } =
		Array.Empty<int>();
}
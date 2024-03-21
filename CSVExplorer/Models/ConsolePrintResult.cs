using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class ConsolePrintResult : IConsolePrintResult
{
	public void PrintMaxSum(int rowNumber, double sum)
	{
		Console.WriteLine(rowNumber != -1
			? $"Row {rowNumber} has the maximum sum of {sum}"
			: "There are no valid rows in the file");
	}

	public void PrintMinSum(int rowNumber, double sum)
	{
		Console.WriteLine(rowNumber != -1
			? $"Row {rowNumber} has the minimum sum of {sum}"
			: "There are no valid rows in the file");
	}

	public void PrintNonNumericRows(List<int> rowNumbers)
	{
		Console.WriteLine("The following rows contain non-numeric elements:");

		foreach (var rowNumber in rowNumbers)
			Console.WriteLine($"\t row {rowNumber}");
	}

	public void PrintAllResults(AnalyzingResult result)
	{
		if (result.InvalidRows is not null)
		{
			PrintNonNumericRows(result.InvalidRows);
		}

		PrintMinSum(result.MinRowIndex, result.MinRowSum);
		PrintMaxSum(result.MaxRowIndex, result.MaxRowSum);
	}
}
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class ConsolePrintResult : IConsolePrintResult
{
	public void PrintAllResults(AnalysisResult result)
	{
		PrintMinSum(result.MinIndex, result.MinRowSum);
		PrintMaxSum(result.MaxIndex, result.MaxRowSum);

		if (result.InvalidRowsIndexes is not null)
			PrintNonNumericRows(result.InvalidRowsIndexes);
	}
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
}
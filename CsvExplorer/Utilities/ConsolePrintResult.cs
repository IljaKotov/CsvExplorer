using CSVExplorer.Interfaces;
using CSVExplorer.Models;

namespace CSVExplorer.Utilities;

internal class ConsolePrintResult : IConsolePrintResult
{
	public void PrintAllResults(AnalysisResult result)
	{
		PrintMinSum(result.MinIndex, result.MinRowSum);
		PrintMaxSum(result.MaxIndex, result.MaxRowSum);

		if (result.InvalidRowsIndexes is not null)
			PrintNonNumericRows(result.InvalidRowsIndexes);
	}

	private static void PrintMaxSum(int rowNumber, double sum)
	{
		Console.WriteLine(rowNumber != -1
			? $"\t Row {rowNumber} has the maximum sum of {sum}"
			: "\t There are no valid rows in the file");
	}

	private static void PrintMinSum(int rowNumber, double sum)
	{
		Console.WriteLine(rowNumber != -1
			? $"\t Row {rowNumber} has the minimum sum of {sum}"
			: "\t There are no valid rows in the file");
	}

	private static void PrintNonNumericRows(List<int> rowNumbers)
	{
		Console.WriteLine("\t The following rows contain non-numeric elements:");

		foreach (var rowNumber in rowNumbers)
			Console.WriteLine($"\t \t row {rowNumber}");
	}
}
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class CsvRowAnalyzer : ICsvRowAnalyzer
{
	private const char Separator = ',';

	public (double, bool) CalculateRowSumAndValidity(string row)
	{
		var elements = row.Split(Separator).ToList();
		double sumRowItems = 0;
		var isRowValid = true;

		foreach (var element in elements)
		{
			if (double.TryParse(element, out var number))
			{
				sumRowItems += number;
			}
			else
			{
				isRowValid = false;

				break;
			}
		}

		return (sumRowItems, isRowValid);
	}
}
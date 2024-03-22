using System.Globalization;
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class RowAnalyzer : IRowAnalyzer
{
	private const char Separator = ',';

	public (double, bool) TryGetRowSum(string row)
	{
		var elements = row.Split(Separator).ToList();
		double sumRowItems = 0;
		var isRowValid = true;

		foreach (var element in elements)
		{
			if (double.TryParse(element, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
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
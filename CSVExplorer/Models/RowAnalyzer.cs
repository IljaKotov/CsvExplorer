using System.Globalization;
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class RowAnalyzer : IRowAnalyzer
{
	private const char Separator = ',';

	public AnalysisRowResult TryGetRowSum(string row)
	{
		var elements = row.Split(Separator).ToList();

		var result = new AnalysisRowResult
		{
			RowSum = 0,
			IsRowValid = true
		};

		foreach (var element in elements)
		{
			if (double.TryParse(element, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
			{
				result.RowSum += number;
			}
			else
			{
				result.IsRowValid = false;

				break;
			}
		}

		return result;
	}
}
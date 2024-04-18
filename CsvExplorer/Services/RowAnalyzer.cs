using System.Globalization;
using CSVExplorer.Interfaces;
using CSVExplorer.Models;

namespace CSVExplorer.Services;

internal class RowAnalyzer : IRowAnalyzer
{
	public AnalysisRowResult TryGetRowSum(string row)
	{
		var separators = new[]
		{
			',', ';'
		};

		var elements = row.Split(separators);

		var result = new AnalysisRowResult();

		foreach (var element in elements)
		{
			if (double.TryParse(element, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
			{
				result.UpdateRowSum(number);
			}
			else
			{
				result.InvalidateRow();

				break;
			}
		}

		return result;
	}
}
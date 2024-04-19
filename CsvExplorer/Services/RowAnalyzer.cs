using System.Globalization;
using CsvExplorer.Interfaces;
using CsvExplorer.Models;

namespace CsvExplorer.Services;

internal class RowAnalyzer : IRowAnalyzer
{
	private static readonly char[] _separators =
	{
		',', ';'
	};

	public AnalysisRowResult TryGetRowSum(string row)
	{
		var elements = row.Split(_separators);

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
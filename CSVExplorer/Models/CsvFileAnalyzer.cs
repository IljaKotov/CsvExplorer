using CSVExplorer.Exceptions;
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class CsvFileAnalyzer : ICsvFileAnalyzer
{
	private readonly ICsvRowAnalyzer _csvRowAnalyzer = new CsvRowAnalyzer();
	private double _minSum = double.MaxValue;
	private double _maxSum = double.MinValue;
	private int _minRowIndex = -1;
	private int _maxRowIndex = -1;

	public AnalyzingResult ProcessCsvFile(List<string> rows)
	{
		EmptyFileException.ThrowIfFileIsEmpty(rows);

		var invalidRows = new List<int>();

		for (var i = 0; i < rows.Count; i++)
		{
			var (sumRowItems, isValidRow) = _csvRowAnalyzer.CalculateRowSumAndValidity(rows[i]);

			if (isValidRow is false)
			{
				invalidRows.Add(i + 1);
			}
			else
			{
				UpdateExtremumValues(sumRowItems, i + 1);
			}
		}

		return CreateCsvProcessingResult(invalidRows);
	}

	private void UpdateExtremumValues(double sum, int rowIndex)
	{
		if (sum < _minSum)
		{
			_minSum = sum;
			_minRowIndex = rowIndex;
		}

		if ((sum > _maxSum) is false)
		{
			return;
		}

		_maxSum = sum;
		_maxRowIndex = rowIndex;
	}

	private AnalyzingResult CreateCsvProcessingResult(List<int> invalidRows)
	{
		return new AnalyzingResult
		{
			InvalidRows = invalidRows,
			MinRowIndex = _minRowIndex,
			MinRowSum = _minSum,
			MaxRowIndex = _maxRowIndex,
			MaxRowSum = _maxSum
		};
	}
}
using CSVExplorer.Exceptions;
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

internal class FileDataAnalyzer(IRowAnalyzer rowAnalyzer) : IFileDataAnalyzer
{
	private readonly List<int> _invalidRows = new();
	private double _minSum = double.MaxValue;
	private double _maxSum = double.MinValue;
	private int _minRowIndex = -1;
	private int _maxRowIndex = -1;

	public AnalysisResult Analyze(List<string> csvRows)
	{
		EmptyFileException.ThrowIfFileIsEmpty(csvRows);

		AnalyzeRows(csvRows);

		return CreateResultRecord();
	}

	private void AnalyzeRows(List<string> csvRows)
	{
		for (var i = 0; i < csvRows.Count; i++)
		{
			var (sumItems, isValid) = rowAnalyzer.TryGetRowSum(csvRows[i]);

			if (isValid is false)
				_invalidRows.Add(i + 1);
			else
				CheckMinMaxValues(sumItems, i + 1);
		}
	}

	private void CheckMinMaxValues(double sum, int rowIndex)
	{
		if (sum < _minSum)
		{
			_minSum = sum;
			_minRowIndex = rowIndex;
		}

		if ((sum > _maxSum) is false)
			return;

		_maxSum = sum;
		_maxRowIndex = rowIndex;
	}

	private AnalysisResult CreateResultRecord()
	{
		return new AnalysisResult
		{
			InvalidRowsIndexes = _invalidRows,
			MinIndex = _minRowIndex,
			MinRowSum = _minSum,
			MaxIndex = _maxRowIndex,
			MaxRowSum = _maxSum
		};
	}
}
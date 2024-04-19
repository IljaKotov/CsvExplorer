using CsvExplorer.Exceptions;
using CsvExplorer.Interfaces;
using CsvExplorer.Models;

namespace CsvExplorer.Services;

internal class FileDataAnalyzer : IFileDataAnalyzer
{
	private readonly List<int> _invalidRows = new();
	private readonly IRowAnalyzer _rowAnalyzer;
	private double _minSum = double.MaxValue;
	private double _maxSum = double.MinValue;
	private int _minRowIndex = -1;
	private int _maxRowIndex = -1;

	public FileDataAnalyzer(IRowAnalyzer rowAnalyzer)
	{
		_rowAnalyzer = rowAnalyzer;
	}

	public async Task<AnalysisResult> AnalyzeAsync(IAsyncEnumerable<string> csvRows)
	{
		var rowIndex = 0;
		var hasRows = false;

		await foreach (var row in csvRows)
		{
			hasRows = true;
			rowIndex++;
			var rowResult = _rowAnalyzer.TryGetRowSum(row);

			if (rowResult.IsRowValid is false)
				_invalidRows.Add(rowIndex);
			else
				CheckMinMaxValues(rowResult.RowSum, rowIndex);
		}

		if (hasRows is false)
			throw new EmptyFileException();

		return CreateResultRecord();
	}

	private void CheckMinMaxValues(double sum, int rowIndex)
	{
		if (sum < _minSum)
		{
			_minSum = sum;
			_minRowIndex = rowIndex;
		}

		if (sum <= _maxSum)
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
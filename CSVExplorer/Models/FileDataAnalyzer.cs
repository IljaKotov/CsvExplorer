using CSVExplorer.Exceptions;
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

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

	public async Task<AnalysisResult> Analyze(IAsyncEnumerable<string> csvRows)
	{
		var enumerator = csvRows.GetAsyncEnumerator();

		await ValidateIsNotEmptyAsync(enumerator);

		var rowIndex = 0;

		do
		{
			rowIndex++;
			var row = enumerator.Current;
			var rowResult = _rowAnalyzer.TryGetRowSum(row);

			if (rowResult.IsRowValid is false)
			{
				_invalidRows.Add(rowIndex);
			}
			else
			{
				CheckMinMaxValues(rowResult.RowSum, rowIndex);
			}
		} while (await enumerator.MoveNextAsync());

		return CreateResultRecord();
	}

	private async Task ValidateIsNotEmptyAsync(IAsyncEnumerator<string> enumerator)
	{
		if (await enumerator.MoveNextAsync() is false)
		{
			throw new EmptyFileException();
		}
	}

	private void CheckMinMaxValues(double sum, int rowIndex)
	{
		if (sum < _minSum)
		{
			_minSum = sum;
			_minRowIndex = rowIndex;
		}

		if (sum <= _maxSum)
		{
			return;
		}

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
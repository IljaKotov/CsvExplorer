namespace CsvExplorer.Models;

public class AnalysisRowResult
{
	private double _rowSum;
	private bool _isRowValid = true;

	public double RowSum => _rowSum;

	public bool IsRowValid => _isRowValid;

	public void UpdateRowSum(double value)
	{
		_rowSum += value;
	}

	public void InvalidateRow()
	{
		_isRowValid = false;
	}
}
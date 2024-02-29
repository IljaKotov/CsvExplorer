using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class CsvRow:ICsvRow
{
	private readonly string _row;

	public CsvRow(string row)
	{
		_row = row;
	}
	public List<string> ParseRow()
	{
		throw new NotImplementedException();
	}

	public bool HasNumericValues()
	{
		throw new NotImplementedException();
	}
}
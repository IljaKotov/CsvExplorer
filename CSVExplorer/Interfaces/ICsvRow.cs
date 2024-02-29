namespace CSVExplorer.Interfaces;

public interface ICsvRow
{
	List<string> ParseRow();
	bool HasNumericValues();
}
namespace CSVExplorer.Interfaces;

public interface ICsvParser
{
	List<List<string>> ParseCsv(string[] csv);
}
namespace CSVExplorer.Interfaces;

public interface IFileReader
{
	string GetFilePathFromUser();
	List<string> ReadFile(string filePath);
}
namespace CsvExplorer.Interfaces;

public interface IAnalyzerRunner
{
	Task RunAsync(string filePath);
}
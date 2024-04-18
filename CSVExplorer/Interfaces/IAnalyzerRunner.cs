namespace CSVExplorer.Interfaces;

public interface IAnalyzerRunner
{
	public Task RunAsync(string filePath);
}
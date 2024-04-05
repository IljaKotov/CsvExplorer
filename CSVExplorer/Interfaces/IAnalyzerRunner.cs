namespace CSVExplorer.Interfaces;

public interface IAnalyzerRunner
{
	public Task RunAsync();
	public Task RunAsync(string filePath);
}
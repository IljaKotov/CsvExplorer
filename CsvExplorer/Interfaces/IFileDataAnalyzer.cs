using CSVExplorer.Models;

namespace CSVExplorer.Interfaces;

public interface IFileDataAnalyzer
{
	public Task<AnalysisResult> Analyze(IAsyncEnumerable<string> csvRows);
}
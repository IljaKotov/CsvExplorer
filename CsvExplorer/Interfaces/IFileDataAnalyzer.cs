using CsvExplorer.Models;

namespace CsvExplorer.Interfaces;

public interface IFileDataAnalyzer
{
	Task<AnalysisResult> AnalyzeAsync(IAsyncEnumerable<string> csvRows);
}
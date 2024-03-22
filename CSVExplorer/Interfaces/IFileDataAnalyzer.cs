using CSVExplorer.Models;

namespace CSVExplorer.Interfaces;

public interface IFileDataAnalyzer
{
	public AnalysisResult Analyze(List<string> csvRows);
}
using CSVExplorer.Interfaces;
using CSVExplorer.Models;

IRowAnalyzer rowAnalyzer = new RowAnalyzer();
IFileDataAnalyzer fileDataAnalyzer = new FileDataAnalyzer(rowAnalyzer);
IConsolePrintResult printResult = new ConsolePrintResult();

var runner = new CsvAnalyzerRunner(fileDataAnalyzer, printResult);

runner.RunWithConsole();
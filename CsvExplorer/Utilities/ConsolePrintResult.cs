using CsvExplorer.Interfaces;
using CsvExplorer.Models;
using Microsoft.Extensions.Options;

namespace CsvExplorer.Utilities;

internal class ConsolePrintResult : IConsolePrintResult
{
	private readonly MessageOptions _messages;

	public ConsolePrintResult(IOptions<MessageOptions> messageOptions)
	{
		_messages = messageOptions.Value;
	}

	public void PrintAllResults(AnalysisResult result)
	{
		PrintMinSum(result.MinIndex, result.MinRowSum);
		PrintMaxSum(result.MaxIndex, result.MaxRowSum);

		if (result.InvalidRowsIndexes is not null)
		{
			PrintNonNumericRows(result.InvalidRowsIndexes);
		}
	}

	private void PrintMaxSum(int rowNumber, double sum)
	{
		Console.WriteLine(rowNumber != -1
			? string.Format(_messages.MaxSumMessage, rowNumber, sum)
			: _messages.NoValidRowsMessage);
	}

	private void PrintMinSum(int rowNumber, double sum)
	{
		Console.WriteLine(rowNumber != -1
			? string.Format(_messages.MinSumMessage, rowNumber, sum)
			: _messages.NoValidRowsMessage);
	}

	private void PrintNonNumericRows(List<int> rowNumbers)
	{
		Console.WriteLine(_messages.NonNumericRowsMessage);

		foreach (var rowNumber in rowNumbers)
			Console.WriteLine(_messages.NonNumericRowMessage, rowNumber);
	}
}
namespace CsvExplorer.Models;

public class MessageOptions
{
	public required string InviteToEnterPath { get; init; }
	public required string MaxSumMessage { get; init; }
	public required string MinSumMessage { get; init; }
	public required string NoValidRowsMessage { get; init; }
	public required string NonNumericRowsMessage { get; init; }
	public required string NonNumericRowMessage { get; init; }
}
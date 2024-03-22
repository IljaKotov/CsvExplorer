using System.ComponentModel;
using CSVExplorer.Models;
using FluentAssertions;

namespace CSVExplorer.Tests;

public static class ExceptionsTests
{
	[Fact]
	[DisplayName("GetFilePath FromConsole throws Exception When NoArgs")]
	public static void GetFilePathFromCommandLine_WhenNoArgs_ThrowsException()
	{
		const string expectedMessage = "Parameter 'file path' cannot be null or empty.";
		
		var args = Array.Empty<string>();
		var provider = new CommandLineFilePathProvider(args);

		Action act = () => provider.GetFilePath();

		act.Should().Throw<Exceptions.ArgumentException>()
			.WithMessage(expectedMessage);
	}

	[Fact]
	[DisplayName("GetAllFileRows throws Exception When file is unfounded")]
	public static void GetAllFileRows_NonExistingFile_ThrowsException()
	{
		const string filePath = "non-existing-file.csv";
		
		var provider = new FileDataService();

		Assert.ThrowsAsync<Exceptions.FileNotFoundException>
			(() => provider.GetAllFileRows(filePath));
	}
}
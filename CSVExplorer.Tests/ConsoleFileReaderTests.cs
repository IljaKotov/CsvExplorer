using System.ComponentModel;
using CSVExplorer.Models;
using FluentAssertions;
using FileNotFoundException = CSVExplorer.Exceptions.FileNotFoundException;

namespace CSVExplorer.Tests;

public class ConsoleFileReaderTests
{
	private const string NonExistentFile = "NonExistentFile.csv";
	private const string TestFilesDirectory = "TestFiles";
	private const string TestFileEmpty = "TestFile_Empty.csv";
	private const string TestFileSingleValidateRow = "TestFile_SingleNumericRow.csv";
	private const string TestFileSingleNotValidateRow = "TestFile_SingleNotNumericRow.csv";
	private const string TestFileMultiRow = "TestFile_MultiRow.csv";

	private readonly ConsoleFileReader _consoleFileReader;
	private readonly string _baseDirectory;

	public ConsoleFileReaderTests()
	{
		_consoleFileReader = new ConsoleFileReader();

		_baseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName ??
			throw new InvalidOperationException();

		ArgumentNullException.ThrowIfNull(_baseDirectory);
	}

	[Fact]
	[DisplayName("Read non-existing file. Should throw exception")]
	public void ReadFile_FileNotFound_ThrowsFileNotFoundException()
	{
		Assert.Throws<FileNotFoundException>(() => _consoleFileReader.ReadFile(NonExistentFile));
	}

	[Theory]
	[DisplayName("Read some files. Should return correct data from file")]
	[InlineData(TestFileEmpty, new[]
	{
		""
	})]
	[InlineData(TestFileSingleNotValidateRow, new[]
	{
		"1,2,3,d,f"
	})]
	[InlineData(TestFileSingleValidateRow, new[]
	{
		"1,2,3,4,5,6,7,8,9,10"
	})]
	public void ReadFile_SomeFiles_ReturnsCorrectResult(string fileName, string[] expectedFileContent)
	{
		// Arrange
		var expected = new List<string>(expectedFileContent);
		var filePath = Path.Combine(_baseDirectory, TestFilesDirectory, fileName);

		_consoleFileReader.ReadFile(filePath).Should().BeEquivalentTo(expected);
	}

	[Fact]
	[DisplayName("Read file with 50 rows. Should return correct count row")]
	public void ReadFile_50Rows_CorrectCountRows()
	{
		var expectedCountRow = 50;
		var filePath = Path.Combine(_baseDirectory, TestFilesDirectory, TestFileMultiRow);

		_consoleFileReader.ReadFile(filePath).Count.Should().Be(expectedCountRow);
	}
}
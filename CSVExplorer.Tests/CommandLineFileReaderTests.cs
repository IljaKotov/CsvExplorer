using System.ComponentModel;
using CSVExplorer.Models;
using FluentAssertions;
using ArgumentException = CSVExplorer.Exceptions.ArgumentException;
using FileNotFoundException = CSVExplorer.Exceptions.FileNotFoundException;

namespace CSVExplorer.Tests;

public class CommandLineFileReaderTests
{
	private const string NonExistentFile = "NonExistentFile.csv";
	private const string TestFilesDirectory = "TestFiles";
	private const string TestFileEmpty = "TestFile_Empty.csv";
	private const string TestFileSingleValidateRow = "TestFile_SingleNumericRow.csv";
	private const string TestFileSingleNotValidateRow = "TestFile_SingleNotNumericRow.csv";
	private const string TestFileMultiRow = "TestFile_MultiRow.csv";

	private readonly CommandLineFileReader _commandLineFileReader;
	private readonly string _baseDirectory;

	public CommandLineFileReaderTests()
	{
		_commandLineFileReader = new CommandLineFileReader(new string[]
		{
		});

		_baseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName ??
			throw new InvalidOperationException();

		ArgumentNullException.ThrowIfNull(_baseDirectory);
	}

	[Fact]
	[DisplayName("Constructor with no args. Should throw ArgumentException")]
	public void Constructor_NoArgs_ThrowsArgumentException()
	{
		// Arrange
		var args = new string[]
		{
		};

		var instance = new CommandLineFileReader(args);

		Assert.Throws<ArgumentException>(() => instance.GetFilePathFromUser());
	}

	[Theory]
	[DisplayName("Constructor with valid args. Should create instance")]
	[InlineData(new object[]
	{
		new[]
		{
			"testFilePath"
		}
	})]
	[InlineData(new object[]
	{
		new[]
		{
			"testFilePath", "testArg"
		}
	})]
	public void Constructor_ValidArgs_CreatesInstance(string[] args)
	{
		var instance = new CommandLineFileReader(args);

		instance.GetFilePathFromUser().Should().Be(args[0]);
	}

	[Fact]
	[DisplayName("Read non-existing file. Should throw exception")]
	public void ReadFile_FileNotFound_ThrowsFileNotFoundException()
	{
		Assert.Throws<FileNotFoundException>(() => _commandLineFileReader.ReadFile(NonExistentFile));
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

		_commandLineFileReader.ReadFile(filePath).Should().BeEquivalentTo(expected);
	}

	[Fact]
	[DisplayName("Read file with 50 rows. Should return correct count row")]
	public void ReadFile_50Rows_CorrectCountRows()
	{
		var expectedCountRow = 50;
		var filePath = Path.Combine(_baseDirectory, TestFilesDirectory, TestFileMultiRow);

		_commandLineFileReader.ReadFile(filePath).Count.Should().Be(expectedCountRow);
	}
}
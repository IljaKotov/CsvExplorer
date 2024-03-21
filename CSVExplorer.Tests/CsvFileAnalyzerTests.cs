using System.ComponentModel;
using CSVExplorer.Exceptions;
using CSVExplorer.Models;
using CSVExplorer.Tests.TestCases;
using FluentAssertions;

namespace CSVExplorer.Tests;

public class CsvFileAnalyzerTests
{
	private const string TestFilesDirectory = "TestFiles";

	private readonly CsvFileAnalyzer _csvFileAnalyzer = new();
	private readonly ConsoleFileReader _consoleFileReader;
	private readonly string _baseDirectory;

	public CsvFileAnalyzerTests()
	{
		_consoleFileReader = new ConsoleFileReader();

		_baseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName ??
			throw new InvalidOperationException();

		ArgumentNullException.ThrowIfNull(_baseDirectory);
	}

	[Fact]
	[DisplayName("ProcessCsvFile with empty data. Should throw exception")]
	public void ProcessCsvFile_EmptyData_ThrowsException()
	{
		var rows = new List<string>();
		Assert.Throws<EmptyFileException>(() => _csvFileAnalyzer.ProcessCsvFile(rows));
	}

	[Theory]
	[DisplayName("ProcessCsvFile with depending data. Should return correct result")]
	[MemberData(nameof(TestCaseGenerator.GetTestData), MemberType = typeof(TestCaseGenerator))]
	public void ProcessCsvFile_SomeData_ReturnsCorrectResult(TestCase testCase)
	{
		var rows = new List<string>(testCase.InputRows);
		var result = _csvFileAnalyzer.ProcessCsvFile(rows);

		result.MinRowSum.Should().Be(testCase.MinSum);
		result.MaxRowSum.Should().Be(testCase.MaxSum);
		result.MinRowIndex.Should().Be(testCase.MinRowIndex);
		result.MaxRowIndex.Should().Be(testCase.MaxRowIndex);
		result.InvalidRows.Should().BeEquivalentTo(testCase.InvalidRows);
	}

	[Theory]
	[DisplayName("ProcessCsvFile with test files. Should return correct results")]
	[MemberData(nameof(ResultCaseFromTestFiles.GetTestData), MemberType = typeof(ResultCaseFromTestFiles))]
	public void ProcessCsvFile_TestFiles_CorrectResults(TestCase testCase)
	{
		var filePath = Path.Combine(_baseDirectory, TestFilesDirectory, testCase.InputRows[0]);
		var rows = _consoleFileReader.ReadFile(filePath);

		var result = _csvFileAnalyzer.ProcessCsvFile(rows);

		result.MinRowSum.Should().Be(testCase.MinSum);
		result.MaxRowSum.Should().Be(testCase.MaxSum);
		result.MinRowIndex.Should().Be(testCase.MinRowIndex);
		result.MaxRowIndex.Should().Be(testCase.MaxRowIndex);
		result.InvalidRows.Should().BeEquivalentTo(testCase.InvalidRows);
	}
}
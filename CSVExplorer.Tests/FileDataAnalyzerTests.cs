using System.ComponentModel;
using CSVExplorer.Exceptions;
using CSVExplorer.Interfaces;
using CSVExplorer.Models;
using CSVExplorer.Tests.TestCases;
using FluentAssertions;

namespace CSVExplorer.Tests;

public class FileDataAnalyzerTests
{
	private static readonly IRowAnalyzer _rowAnalyzer = new RowAnalyzer();
	private readonly IFileDataAnalyzer _fileDataAnalyzer = new FileDataAnalyzer(_rowAnalyzer);

	[Fact]
	[DisplayName("ProcessCsvFile with empty data. Should throw exception")]
	public void ProcessCsvFile_EmptyData_ThrowsException()
	{
		var rows = new List<string>();
		Assert.Throws<EmptyFileException>(() => _fileDataAnalyzer.Analyze(rows));
	}

	[Theory]
	[DisplayName("Analyze test cases with depending data. Should return correct result")]
	[MemberData(nameof(TestCaseGenerator.GetTestData), 
		MemberType = typeof(TestCaseGenerator))]
	public void Analyze_SomeDataCases_ReturnsCorrectResult(TestCase testCase)
	{
		var result = _fileDataAnalyzer.Analyze(testCase.InputRows.ToList());
	
		result.MinRowSum.Should().Be(testCase.MinSum);
		result.MaxRowSum.Should().Be(testCase.MaxSum);
		result.MinIndex.Should().Be(testCase.MinRowIndex);
		result.MaxIndex.Should().Be(testCase.MaxRowIndex);
		result.InvalidRowsIndexes.Should().BeEquivalentTo(testCase.InvalidRows);
	}
}

﻿using System.ComponentModel;
using CsvExplorer.Exceptions;
using CsvExplorer.Interfaces;
using CsvExplorer.Services;
using CsvExplorer.Tests.TestCases;
using FluentAssertions;

namespace CsvExplorer.Tests;

public class FileDataAnalyzerTests
{
	private static readonly IRowAnalyzer _rowAnalyzer = new RowAnalyzer();
	private readonly IFileDataAnalyzer _fileDataAnalyzer = new FileDataAnalyzer(_rowAnalyzer);

	[Fact]
	[DisplayName("ProcessCsvFile with empty data. Should throw exception")]
	public async Task Analyze_EmptyData_ThrowsException()
	{
		var rows = new List<string>().ToAsyncEnumerable();
		await Assert.ThrowsAsync<EmptyFileException>(() => _fileDataAnalyzer.AnalyzeAsync(rows));
	}

	[Fact]
	[DisplayName("GetAllFileRows throws Exception When file is unfounded")]
	public async Task GetAllFileRows_NonExistingFile_ThrowsException()
	{
		const string filePath = "non-existing-file.csv";

		var provider = new FileDataService();

		await Assert.ThrowsAsync<FileNotFoundException>(() =>
			Task.Run(async () => await provider.EnumerateAllFileRowsAsync(filePath).ToListAsync()));
	}

	[Theory]
	[DisplayName("Analyze test cases with depending data. Should return correct result")]
	[MemberData(nameof(TestCaseGenerator.GetTestData),
		MemberType = typeof(TestCaseGenerator))]
	public async Task Analyze_SomeDataCases_ReturnsCorrectResult(TestCase testCase)
	{
		var result = await _fileDataAnalyzer.AnalyzeAsync(testCase.InputRows.ToAsyncEnumerable());

		result.MinRowSum.Should().Be(testCase.MinSum);
		result.MaxRowSum.Should().Be(testCase.MaxSum);
		result.MinIndex.Should().Be(testCase.MinRowIndex);
		result.MaxIndex.Should().Be(testCase.MaxRowIndex);
		result.InvalidRowsIndexes.Should().BeEquivalentTo(testCase.InvalidRows);
	}
}
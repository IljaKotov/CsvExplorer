using Cocona;
using CSVExplorer.Interfaces;
using CSVExplorer.Providers;
using CSVExplorer.Services;
using CSVExplorer.Utilities;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddTransient<IConsolePrintResult, ConsolePrintResult>();
builder.Services.AddTransient<IFilePathProvider, ConsoleFilePathProvider>();
builder.Services.AddTransient<IFileDataService, FileDataService>();
builder.Services.AddTransient<IRowAnalyzer, RowAnalyzer>();
builder.Services.AddTransient<IFileDataAnalyzer, FileDataAnalyzer>();
builder.Services.AddTransient<IAnalyzerRunner, AnalyzerRunner>();

var app = builder.Build();

app.AddCommand(async (IAnalyzerRunner runner) =>
{
	var provider =
		ServiceProviderServiceExtensions.GetRequiredService<IFilePathProvider>(builder.Services.BuildServiceProvider());

	var filePath = provider.GetFilePath();
	await runner.RunAsync(filePath);
});

app.AddCommand("analyze", async (IAnalyzerRunner runner, [Option("file")] string? filePath) =>
{
	if (string.IsNullOrWhiteSpace(filePath) || File.Exists(filePath) is false)

	{
		var provider =
			ServiceProviderServiceExtensions.GetRequiredService<IFilePathProvider>(
				builder.Services.BuildServiceProvider());

		filePath = provider.GetFilePath();
	}

	await runner.RunAsync(filePath);
}).WithDescription("Run the analyzer");

await app.RunAsync();

//D:\ПРОЕКТИ\Education\CsvExplorer\CsvExplorer
//D:\ПРОЕКТИ\Education\TestFile1.csv
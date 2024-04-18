using Cocona;
using CSVExplorer.Interfaces;
using CSVExplorer.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddTransient<IConsolePrintResult, ConsolePrintResult>();
builder.Services.AddTransient<IFilePathProvider, CombinedFilePathProvider>();
builder.Services.AddTransient<IFileDataService, FileDataService>();
builder.Services.AddTransient<IRowAnalyzer, RowAnalyzer>();
builder.Services.AddTransient<IFileDataAnalyzer, FileDataAnalyzer>();
builder.Services.AddTransient<IAnalyzerRunner, AnalyzerRunner>();
builder.Services.AddTransient(_ => new CommandLineFilePathProvider(args));
builder.Services.AddTransient<ConsoleFilePathProvider>();

var app = builder.Build();

app.AddCommand("run", async (IAnalyzerRunner runner, [Option("file")] string? filePath) =>
{
	if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))

	{
		var provider = ServiceProviderServiceExtensions.GetRequiredService<IFilePathProvider>(builder.Services.BuildServiceProvider());
		filePath = provider.GetFilePath();
	}
	await runner.RunAsync(filePath);
}).WithDescription("Run the analyzer");

app.Run();


//D:\ПРОЕКТИ\Education\CSVExplorer\CSVExplorer
//D:\ПРОЕКТИ\Education\TestFile1.csv


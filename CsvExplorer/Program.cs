using Cocona;
using CsvExplorer.Interfaces;
using CsvExplorer.Models;
using CsvExplorer.Providers;
using CsvExplorer.Services;
using CsvExplorer.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();

var configuration = new ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", true, true)
	.Build();

builder.Services.Configure<MessageOptions>(configuration.GetSection("Messages"));
builder.Services.AddTransient<IConsolePrintResult, ConsolePrintResult>();
builder.Services.AddTransient<IFilePathProvider, ConsoleFilePathProvider>();
builder.Services.AddTransient<IFileDataService, FileDataService>();
builder.Services.AddTransient<IRowAnalyzer, RowAnalyzer>();
builder.Services.AddTransient<IFileDataAnalyzer, FileDataAnalyzer>();
builder.Services.AddTransient<IAnalyzerRunner, AnalyzerRunner>();

var app = builder.Build();

app.AddCommand(async (IAnalyzerRunner runner, IFilePathProvider provider) =>
{
	var filePath = provider.GetFilePath();
	await runner.RunAsync(filePath);
});

app.AddCommand("analyze", async (IAnalyzerRunner runner,
	IFilePathProvider provider,
	[Option("path")] string? filePath) =>
{
	if (string.IsNullOrWhiteSpace(filePath) || File.Exists(filePath) is false)
	{
		filePath = provider.GetFilePath();
	}

	await runner.RunAsync(filePath);
}).WithDescription("Run the analyzer");

await app.RunAsync();
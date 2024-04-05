using Cocona;
using Cocona.Builder;
using Cocona.Hosting;
using CSVExplorer.Interfaces;
using CSVExplorer.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/*var serviceCollection = new ServiceCollection();

ConfigureServices(serviceCollection);

var serviceProvider = serviceCollection.BuildServiceProvider();

var runner = ServiceProviderServiceExtensions.GetRequiredService<IAnalyzerRunner>(serviceProvider);
runner.Run();*/

var builder = CoconaApp.CreateBuilder();
ConfigureServices(builder.Services);

var app = builder.Build();

app.AddCommand("run", async (IAnalyzerRunner runner) => await runner.RunAsync()).WithDescription("Run the analyzer");

app.Run();

	

	void ConfigureServices(IServiceCollection services)
	{
		string[] args = Environment.GetCommandLineArgs();

		services.AddTransient<IConsolePrintResult, ConsolePrintResult>();
		services.AddTransient<IFilePathProvider, CombinedFilePathProvider>();
		services.AddTransient<IFileDataService, FileDataService>();
		services.AddTransient<IRowAnalyzer, RowAnalyzer>();
		services.AddTransient<IFileDataAnalyzer, FileDataAnalyzer>();
		services.AddTransient<IAnalyzerRunner, AnalyzerRunner>();
		services.AddTransient(_ => new CommandLineFilePathProvider(args));
		services.AddTransient<ConsoleFilePathProvider>();
	}
//D:\ПРОЕКТИ\Education\CSVExplorer\CSVExplorer
//D:\ПРОЕКТИ\Education\TestFile1.csv


using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class AsyncIOHandler: IAsyncIOHandler
{
	public async Task<string[]> ReadFileAsync(string path)
	{
		throw new NotImplementedException();
	}
}
using CSVExplorer.Interfaces;

namespace CSVExplorer.Models;

public class ExceptionHandler: IExceptionHandler
{
	public void HandleException(Exception ex)
	{
		throw new NotImplementedException();
	}
}
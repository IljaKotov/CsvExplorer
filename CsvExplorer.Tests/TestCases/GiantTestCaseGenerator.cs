using System.Text;
using Bogus;

namespace CSVExplorer.Tests.TestCases;

public static class GiantTestCaseGenerator
{
	private const char Separator = ',';
	private const int RowCount = 25000;
	private const int RowValuesCount = 3;

	private static double _minSum = double.MaxValue;
	private static double _maxSum = double.MinValue;
	private static int _minRowIndex = -1;
	private static int _maxRowIndex = -1;
	private static readonly Dictionary<int, string> _lines = new();
	private static readonly Faker _faker = new();

	public static TestCase GenerateGiantTestCase(string filePath)
	{
		for (var i = 0; i < RowCount; i++)
		{
			var rowValues = GetFakerValues();
			var rowSum = rowValues.Sum();
			var csvRow = GenerateCsvRow(rowValues);

			_lines.Add(i, csvRow);

			UpdateMinMaxValues(rowSum, i);
		}

		return GenerateResult();
	}

	private static int[] GetFakerValues()
	{
		var rowValues = new int[RowValuesCount];

		for (var i = 0; i < RowValuesCount; i++)
			rowValues[i] = _faker.Random.Int(1, 100);

		return rowValues;
	}

	private static string GenerateCsvRow(int[] rowValues)
	{
		return new StringBuilder()
			.Append(rowValues[0]).Append(Separator)
			.Append(rowValues[1]).Append(Separator)
			.Append(rowValues[2])
			.ToString();
	}

	private static void UpdateMinMaxValues(double sum, int rowIndex)
	{
		if (sum < _minSum)
		{
			_minSum = sum;
			_minRowIndex = rowIndex + 1;
		}

		if ((sum > _maxSum) is false)
		{
			return;
		}

		_maxSum = sum;
		_maxRowIndex = rowIndex + 1;
	}

	private static TestCase GenerateResult()
	{
		return new TestCase
		{
			InputRows = _lines
				.OrderBy(x => x.Key)
				.Select(x => x.Value)
				.ToArray(),
			MinSum = _minSum,
			MaxSum = _maxSum,
			MinRowIndex = _minRowIndex,
			MaxRowIndex = _maxRowIndex,
			InvalidRows = Array.Empty<int>()
		};
	}
}
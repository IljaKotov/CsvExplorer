namespace CSVExplorer.Tests.TestCases;

public static class ResultCaseFromTestFiles
{
	public static IEnumerable<object[]> GetTestData()
	{
		yield return new object[]
		{
			MultiRowFileTestCase()
		};

		yield return new object[]
		{
			SingleNotNumericRowFileTestCase()
		};

		yield return new object[]
		{
			SingleNumericRowFileTestCase()
		};
	}

	private static TestCase MultiRowFileTestCase()
	{
		return new TestCase
		{
			InputRows = new[]
			{
				"TestFile_MultiRow.csv"
			},
			MinSum = 1341,
			MaxSum = 3555,
			MinRowIndex = 46,
			MaxRowIndex = 2,
			InvalidRows = new[]
			{
				1, 3, 6, 9, 10, 11, 13, 14, 15, 17, 19, 20, 21, 22, 23, 24, 25, 26, 28, 29, 30, 34, 36, 39, 40, 45, 47,
				48, 49
			}
		};
	}

	private static TestCase SingleNotNumericRowFileTestCase()
	{
		return new TestCase
		{
			InputRows = new[]
			{
				"TestFile_SingleNotNumericRow.csv"
			},
			MinSum = double.MaxValue,
			MaxSum = double.MinValue,
			MinRowIndex = -1,
			MaxRowIndex = -1,
			InvalidRows = new[]
			{
				1
			}
		};
	}

	private static TestCase SingleNumericRowFileTestCase()
	{
		return new TestCase
		{
			InputRows = new[]
			{
				"TestFile_SingleNumericRow.csv"
			},
			MinSum = 55,
			MaxSum = 55,
			MinRowIndex = 1,
			MaxRowIndex = 1,
			InvalidRows = Array.Empty<int>()
		};
	}
}
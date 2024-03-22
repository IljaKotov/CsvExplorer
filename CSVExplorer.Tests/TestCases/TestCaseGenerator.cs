namespace CSVExplorer.Tests.TestCases;

public static class TestCaseGenerator
{
	public static IEnumerable<object[]> GetTestData()
	{
		yield return new object[] {GenerateThreeValidRowTestCase()};

		yield return new object[] {GenerateOneValidRowTestCase()};

		yield return new object[] {GenerateOneInvalidRowTestCase()};

		yield return new object[] {GenerateMultiRowTestCase()};
		
		yield return new object[] {GetGiantTestCase()};
	}

	private static TestCase GenerateThreeValidRowTestCase()
	{
		return new TestCase
		{
			InputRows = new[]
			{
				"1,2,3", 
				"4,5,6", 
				"7,8,9"
			},
			
			MinSum = 6,
			MaxSum = 24,
			MinRowIndex = 1,
			MaxRowIndex = 3,
			InvalidRows = Array.Empty<int>()
		};
	}

	private static TestCase GenerateOneValidRowTestCase()
	{
		return new TestCase
		{
			InputRows = new[]
			{
				"1,2,3"
			},
			
			MinSum = 6,
			MaxSum = 6,
			MinRowIndex = 1,
			MaxRowIndex = 1,
			InvalidRows = Array.Empty<int>()
		};
	}

	private static TestCase GenerateOneInvalidRowTestCase()
	{
		return new TestCase
		{
			InputRows = new[]
			{
				"1,a"
			},
			
			MinSum = double.MaxValue,
			MaxSum = double.MinValue,
			MinRowIndex = -1,
			MaxRowIndex = -1,
			InvalidRows = new[] {1}
		};
	}

	private static TestCase GenerateMultiRowTestCase()
	{
		return new TestCase
		{
			InputRows = new[]
			{
				"1,7,9,3", 
				"Test", 
				"4,5,6", 
				"7,8,9", 
				"1,2,3,4,5,6,7,8,9,10", 
				"Test,test"
			},
			
			MinSum = 15,
			MaxSum = 55,
			MinRowIndex = 3,
			MaxRowIndex = 5,
			InvalidRows = new[] {2, 6}
		};
	}
	
	private static TestCase GetGiantTestCase()
	{
		return GiantTestCaseGenerator.GenerateGiantTestCase("GiantTestFile.csv");
	}
}
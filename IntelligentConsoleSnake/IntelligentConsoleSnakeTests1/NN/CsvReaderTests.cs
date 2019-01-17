using IntelligentConsoleSnake.NN;
using Xunit;

namespace IntelligentConsoleSnakeTests.NN
{
	public class CsvReaderTests
	{
		[Fact()]
		public void ReadWeightsAndSplitToArrayCheckIfResultIsArrayHas42Weights()
		{
			var weightsFromFile = CsvReader.ReadWeightsAndSplitToArray();

			Assert.True(weightsFromFile.Length == 42, $"Length of array: {weightsFromFile.Length}");
		}
	}
}
using IntelligentConsoleSnake.NN;
using Xunit;

namespace IntelligentConsoleSnakeTests1.NN
{
	public class NeuralNetworkTests
	{
		private NeuralNetwork _neuralNetwork;

		public NeuralNetworkTests()
		{
			_neuralNetwork = new NeuralNetwork(5,5,2);
		}

		[Fact()]
		public void NeuralNetworkConstructorCheckIfBadWeightsInArrayInSetWeightsIsNotThrown()
		{
			int numberOfInputs = 5;
			int numberOfNeuronsInFirstHiddenLayer = 5;
			int numberOfOutputNeurons = 2;

			var neuralNetwork = new NeuralNetwork(numberOfInputs, numberOfNeuronsInFirstHiddenLayer, numberOfOutputNeurons);
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsOnlyOnRight()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 0.0, 1.0, 0.0, 0.0 };
			possibleMoves[1] = new[] { 2.0, 0.0, 1.0, 0.0, 0.0 };
			possibleMoves[2] = new[] { 3.0, 0.0, 1.0, 0.0, 0.0 };
			possibleMoves[3] = new[] { 4.0, 0.0, 1.0, 0.0, 0.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result!=1,"Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsOnlyUp()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 1.0, 0.0, 0.0, 0.0 };
			possibleMoves[1] = new[] { 2.0, 1.0, 0.0, 0.0, 0.0 };
			possibleMoves[2] = new[] { 3.0, 1.0, 0.0, 0.0, 0.0 };
			possibleMoves[3] = new[] { 4.0, 1.0, 0.0, 0.0, 0.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 2, "Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsOnlyOnLeft()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 0.0, 0.0, 0.0, 1.0 };
			possibleMoves[1] = new[] { 2.0, 0.0, 0.0, 0.0, 1.0 };
			possibleMoves[2] = new[] { 3.0, 0.0, 0.0, 0.0, 1.0 };
			possibleMoves[3] = new[] { 4.0, 0.0, 0.0, 0.0, 1.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 3, "Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsOnlyDown()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 0.0, 0.0, 1.0, 0.0 };
			possibleMoves[1] = new[] { 2.0, 0.0, 0.0, 1.0, 0.0 };
			possibleMoves[2] = new[] { 3.0, 0.0, 0.0, 1.0, 0.0 };
			possibleMoves[3] = new[] { 4.0, 0.0, 0.0, 1.0, 0.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 4, "Snake crashed a border!");
		}
	}
}
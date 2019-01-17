using IntelligentConsoleSnake.NN;
using Xunit;

namespace IntelligentConsoleSnakeTests1.NN
{
	//TODO Sprawdź czy nazwy testów zgadzają się na pewno z tym co jest przekazywane do metody (czy jak pisze, że przeszkoda jest u góry to serio idzie tablica tylko z jedynką na pozycji przeszkody u góry
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
		public void NeuralNetworkResponseWhenObstacleIsOnRightAndUp()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 1.0, 1.0, 0.0, 0.0 };
			possibleMoves[1] = new[] { 2.0, 1.0, 1.0, 0.0, 0.0 };
			possibleMoves[2] = new[] { 3.0, 1.0, 1.0, 0.0, 0.0 };
			possibleMoves[3] = new[] { 4.0, 1.0, 1.0, 0.0, 0.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 1 && result != 2, "Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsOnRightAndUpAndLeft()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 1.0, 1.0, 0.0, 1.0 };
			possibleMoves[1] = new[] { 2.0, 1.0, 1.0, 0.0, 1.0 };
			possibleMoves[2] = new[] { 3.0, 1.0, 1.0, 0.0, 1.0 };
			possibleMoves[3] = new[] { 4.0, 1.0, 1.0, 0.0, 1.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 1 && result != 2 && result != 3, "Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsOnRightAndDown()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 0.0, 1.0, 1.0, 0.0 };
			possibleMoves[1] = new[] { 2.0, 0.0, 1.0, 1.0, 0.0 };
			possibleMoves[2] = new[] { 3.0, 0.0, 1.0, 1.0, 0.0 };
			possibleMoves[3] = new[] { 4.0, 0.0, 1.0, 1.0, 0.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 1 && result != 4, "Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsOnRightAndDownAndLeft()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 0.0, 1.0, 1.0, 1.0 };
			possibleMoves[1] = new[] { 2.0, 0.0, 1.0, 1.0, 1.0 };
			possibleMoves[2] = new[] { 3.0, 0.0, 1.0, 1.0, 1.0 };
			possibleMoves[3] = new[] { 4.0, 0.0, 1.0, 1.0, 1.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 1 && result != 3 && result != 4, "Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsOnRightAndLeft()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 0.0, 1.0, 0.0, 1.0 };
			possibleMoves[1] = new[] { 2.0, 0.0, 1.0, 0.0, 1.0 };
			possibleMoves[2] = new[] { 3.0, 0.0, 1.0, 0.0, 1.0 };
			possibleMoves[3] = new[] { 4.0, 0.0, 1.0, 0.0, 1.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 1 && result != 3, "Snake crashed a border!");
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
		public void NeuralNetworkResponseWhenObstacleIsUpAndLeft()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 1.0, 0.0, 0.0, 1.0 };
			possibleMoves[1] = new[] { 2.0, 1.0, 0.0, 0.0, 1.0 };
			possibleMoves[2] = new[] { 3.0, 1.0, 0.0, 0.0, 1.0 };
			possibleMoves[3] = new[] { 4.0, 1.0, 0.0, 0.0, 1.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 2 && result != 3, "Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsUpAndLeftAndDown()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 1.0, 0.0, 1.0, 1.0 };
			possibleMoves[1] = new[] { 2.0, 1.0, 0.0, 1.0, 1.0 };
			possibleMoves[2] = new[] { 3.0, 1.0, 0.0, 1.0, 1.0 };
			possibleMoves[3] = new[] { 4.0, 1.0, 0.0, 1.0, 1.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 2 && result != 3 && result != 4, "Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsUpAndRightAndDown()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 1.0, 1.0, 1.0, 0.0 };
			possibleMoves[1] = new[] { 2.0, 1.0, 1.0, 1.0, 0.0 };
			possibleMoves[2] = new[] { 3.0, 1.0, 1.0, 1.0, 0.0 };
			possibleMoves[3] = new[] { 4.0, 1.0, 1.0, 1.0, 0.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 1 && result != 2 && result != 4, "Snake crashed a border!");
		}

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsUpAndDown()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 1.0, 0.0, 1.0, 0.0 };
			possibleMoves[1] = new[] { 2.0, 1.0, 0.0, 1.0, 0.0 };
			possibleMoves[2] = new[] { 3.0, 1.0, 0.0, 1.0, 0.0 };
			possibleMoves[3] = new[] { 4.0, 1.0, 0.0, 1.0, 0.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 2 && result != 4, "Snake crashed a border!");
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

		[Fact()]
		public void NeuralNetworkResponseWhenObstacleIsDownAndLeft()
		{
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, 0.0, 0.0, 1.0, 1.0 };
			possibleMoves[1] = new[] { 2.0, 0.0, 0.0, 1.0, 1.0 };
			possibleMoves[2] = new[] { 3.0, 0.0, 0.0, 1.0, 1.0 };
			possibleMoves[3] = new[] { 4.0, 0.0, 0.0, 1.0, 1.0 };

			var result = _neuralNetwork.ChooseDirection(possibleMoves);

			Assert.True(result != 3 && result != 4, "Snake crashed a border!");
		}
	}
}
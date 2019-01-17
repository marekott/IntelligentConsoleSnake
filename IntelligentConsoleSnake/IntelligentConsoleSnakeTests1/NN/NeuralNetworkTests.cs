using IntelligentConsoleSnake.NN;
using Xunit;

namespace IntelligentConsoleSnakeTests1.NN
{
	public class NeuralNetworkTests
	{
		[Fact()]
		public void NeuralNetworkConstructorCheckIfBadWeightsInArrayInSetWeightsIsNotThrown()
		{
			int numberOfInputs = 5;
			int numberOfNeuronsInFirstHiddenLayer = 5;
			int numberOfOutputNeurons = 2;

			var neuralNetwork = new NeuralNetwork(numberOfInputs, numberOfNeuronsInFirstHiddenLayer, numberOfOutputNeurons);
		}
	}
}
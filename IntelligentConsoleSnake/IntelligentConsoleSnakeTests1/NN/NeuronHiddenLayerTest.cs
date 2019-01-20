using Xunit;
using IntelligentConsoleSnake.NN;

namespace IntelligentConsoleSnakeTests1.NN
{
	public class NeuronHiddenLayerTest
	{
		private readonly double[] _inputs;

		public NeuronHiddenLayerTest()
		{
			_inputs = new[] { -30.0, 0.0, 50.0};
		}

		[Fact]
		public void ComputeOutputForFirstNeuronInLayerForInputLessThan0()
		{
			var neuronHiddenLayer = new NeuronHiddenLayer(1,0);

			var result = neuronHiddenLayer.ComputeOutput(_inputs);

			Assert.Equal(-1.0, result, 2);
		}

		[Fact]
		public void ComputeOutputForSecondNeuronInLayerForInputEqual0()
		{
			var neuronHiddenLayer = new NeuronHiddenLayer(1, 1);

			var result = neuronHiddenLayer.ComputeOutput(_inputs);

			Assert.Equal(0.0, result, 2);
		}

		[Fact]
		public void ComputeOutputForThirdNeuronInLayerForInputGraterThan0()
		{
			var neuronHiddenLayer = new NeuronHiddenLayer(1, 2);

			var result = neuronHiddenLayer.ComputeOutput(_inputs);

			Assert.Equal(1.0, result, 2);
		}
	}
}

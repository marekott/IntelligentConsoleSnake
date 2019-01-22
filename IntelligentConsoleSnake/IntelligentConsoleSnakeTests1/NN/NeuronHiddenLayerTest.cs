using System;
using Xunit;
using IntelligentConsoleSnake.NN;

namespace IntelligentConsoleSnakeTests1.NN
{
	public class NeuronHiddenLayerTest
	{
		private readonly double[] _inputs;
		private readonly double[] _biases;

		public NeuronHiddenLayerTest()
		{
			_inputs = new[] { -30.0, 0.0, 50.0, 60.0, -70.0, 80.0 };
			_biases = new[] { 60.0, -5.0, -50.0 };
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

		[Fact]
		public void ComputeOutputForFirstNeuronInLayerForInputLessThan0AndBiases()
		{
			var neuronHiddenLayer = new NeuronHiddenLayer(1, 0);

			var result = neuronHiddenLayer.ComputeOutput(_inputs, _biases);

			Assert.Equal(1.0, result, 2);
		}

		[Fact]
		public void ComputeOutputForSecondNeuronInLayerForInputEqual0AndBiases()
		{
			var neuronHiddenLayer = new NeuronHiddenLayer(1, 1);

			var result = neuronHiddenLayer.ComputeOutput(_inputs, _biases);

			Assert.Equal(-1.0, result, 2);
		}

		[Fact]
		public void ComputeOutputForThirdNeuronInLayerForInputGraterThan0AndBiases()
		{
			var neuronHiddenLayer = new NeuronHiddenLayer(1, 2);

			var result = neuronHiddenLayer.ComputeOutput(_inputs, _biases);

			Assert.Equal(0.0, result, 2);
		}

		[Fact]
		public void ThrowIndexWasOutOfRangeException()
		{
			var neuronHiddenLayer = new NeuronHiddenLayer(1, 4);

			Assert.Throws<IndexOutOfRangeException>(() => neuronHiddenLayer.ComputeOutput(_inputs, _biases));
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using Xunit;
using IntelligentConsoleSnake.NN;

namespace IntelligentConsoleSnakeTests1.NN
{
	public class NeuronTest
	{
		private readonly double[] _inputsWith3Numbers;
		private readonly double[] _inputsWith10Numbers;
		private readonly double[] _inputsWith150Numbers;

		public NeuronTest()
		{
			_inputsWith3Numbers = new[] { 1.0, 2.0, 3.0 };
			_inputsWith10Numbers = new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0};

			IEnumerable<double> inputs1 = Enumerable.Repeat(1.0, 50);
			IEnumerable<double> inputs2 = Enumerable.Repeat(2.0, 50);
			IEnumerable<double> inputs3 = Enumerable.Repeat(3.0, 50);

			List<double> combined = inputs1.Concat(inputs2).Concat(inputs3).ToList();
			_inputsWith150Numbers = new double[150];

			for (int i = 0; i < _inputsWith150Numbers.Length; i++)
			{
				_inputsWith150Numbers[i] = combined[i];
			}
		}

		[Fact]
		public void ComputeOutputFirstNeuronInLayerOneInputTest()
		{
			int numberOfInputs = 1;
			int neuronPositionFromTop = 0;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith3Numbers);

			Assert.Equal(_inputsWith3Numbers[neuronPositionFromTop], neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputSecondNeuronInLayerOneInputTest()
		{
			int numberOfInputs = 1;
			int neuronPositionFromTop = 1;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith3Numbers);

			Assert.Equal(_inputsWith3Numbers[neuronPositionFromTop], neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputThirdNeuronInLayerOneInputTest()
		{
			int numberOfInputs = 1;
			int neuronPositionFromTop = 2;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith3Numbers);

			Assert.Equal(_inputsWith3Numbers[neuronPositionFromTop], neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputFirstNeuronInLayerFiveInputsTest()
		{
			int numberOfInputs = 5;
			int neuronPositionFromTop = 0;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith10Numbers);

			Assert.Equal(15.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputSecondNeuronInLayerFiveInputsTest()
		{
			int numberOfInputs = 5;
			int neuronPositionFromTop = 1;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith10Numbers);

			Assert.Equal(40.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputFirstNeuronInLayerFiftyInputsTest()
		{
			int numberOfInputs = 50;
			int neuronPositionFromTop = 0;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith150Numbers);

			Assert.Equal(50.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputSecondNeuronInLayerFiftyInputsTest()
		{
			int numberOfInputs = 50;
			int neuronPositionFromTop = 1;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith150Numbers);

			Assert.Equal(100.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputThirdNeuronInLayerFiftyInputsTest()
		{
			int numberOfInputs = 50;
			int neuronPositionFromTop = 2;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith150Numbers);

			Assert.Equal(150.0, neuronOutput, 5);
		}
	}
}

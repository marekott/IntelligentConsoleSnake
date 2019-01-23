using System;
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
		private readonly double[] _inputsWith3Biases;
		private readonly double[] _inputsWith10Biases;
		private readonly double[] _inputsWith150Biases;

		public NeuronTest()
		{
			_inputsWith3Numbers = new[] {1.0, 2.0, 3.0};
			_inputsWith10Numbers = new[] {1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0};
			_inputsWith3Biases = new[] {5.0, 10.0, 20.0};
			_inputsWith10Biases = new[] {10.0, 9.0, 8.0, 7.0, 6.0, 5.0, 4.0, 3.0, 2.0, 1.0};

			IEnumerable<double> inputs1 = Enumerable.Repeat(1.0, 50);
			IEnumerable<double> inputs2 = Enumerable.Repeat(2.0, 50);
			IEnumerable<double> inputs3 = Enumerable.Repeat(3.0, 50);

			List<double> combined = inputs1.Concat(inputs2).Concat(inputs3).ToList();
			_inputsWith150Numbers = new double[150];

			IEnumerable<double> inputsBiases1 = Enumerable.Repeat(7.0, 50);
			IEnumerable<double> inputsBiases2 = Enumerable.Repeat(5.0, 50);
			IEnumerable<double> inputsBiases3 = Enumerable.Repeat(3.0, 50);

			List<double> combinedBiases = inputsBiases1.Concat(inputsBiases2).Concat(inputsBiases3).ToList();
			_inputsWith150Biases = new double[150];

			for (int i = 0; i < _inputsWith150Numbers.Length; i++)
			{
				_inputsWith150Numbers[i] = combined[i];
				_inputsWith150Biases[i] = combinedBiases[i];
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

		[Fact]
		public void ComputeOutputFirstNeuronInLayerOneInputAndBiasesTest()
		{
			int numberOfInputs = 1;
			int neuronPositionFromTop = 0;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith3Numbers, _inputsWith3Biases);

			Assert.Equal(6.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputSecondNeuronInLayerOneInputAndBiasesTest()
		{
			int numberOfInputs = 1;
			int neuronPositionFromTop = 1;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith3Numbers, _inputsWith3Biases);

			Assert.Equal(12.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputThirdNeuronInLayerOneInputAndBiasesTest()
		{
			int numberOfInputs = 1;
			int neuronPositionFromTop = 2;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith3Numbers, _inputsWith3Biases);

			Assert.Equal(23.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputFirstNeuronInLayerFiveInputsAndBiasesTest()
		{
			int numberOfInputs = 5;
			int neuronPositionFromTop = 0;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith10Numbers, _inputsWith10Biases);

			Assert.Equal(25.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputSecondNeuronInLayerFiveInputsAndBiasesTest()
		{
			int numberOfInputs = 5;
			int neuronPositionFromTop = 1;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith10Numbers, _inputsWith10Biases);

			Assert.Equal(49.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputFirstNeuronInLayerFiftyInputsAndBiasesTest()
		{
			int numberOfInputs = 50;
			int neuronPositionFromTop = 0;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith150Numbers, _inputsWith150Biases);

			Assert.Equal(57.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputSecondNeuronInLayerFiftyInputsAndBiasesTest()
		{
			int numberOfInputs = 50;
			int neuronPositionFromTop = 1;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith150Numbers, _inputsWith150Biases);

			Assert.Equal(107.0, neuronOutput, 5);
		}

		[Fact]
		public void ComputeOutputThirdNeuronInLayerFiftyInputsAndBiasesTest()
		{
			int numberOfInputs = 50;
			int neuronPositionFromTop = 2;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			double neuronOutput = neuron.ComputeOutput(_inputsWith150Numbers, _inputsWith150Biases);

			Assert.Equal(157.0, neuronOutput, 5);
		}

		[Fact]
		public void ThrowIndexWasOutOfRangeException()
		{
			int numberOfInputs = 10;
			int neuronPositionFromTop = 10;

			var neuron = new Neuron(numberOfInputs, neuronPositionFromTop);

			Assert.Throws<IndexOutOfRangeException>(() => neuron.ComputeOutput(_inputsWith150Numbers, _inputsWith3Biases));
		}
	}
}

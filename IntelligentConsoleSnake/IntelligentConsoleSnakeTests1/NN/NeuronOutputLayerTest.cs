using System;
using Xunit;
using IntelligentConsoleSnake.NN;

namespace IntelligentConsoleSnakeTests1.NN
{
	public class NeuronOutputLayerTest
	{
		private readonly double[] _biases;

		public NeuronOutputLayerTest()
		{
			_biases = new[] { 1.0, 1.0 };
		}

		[Fact]
		public void NnOutputFromTwoOutputsFirstNeuronTestForMinus3()
		{
			double[] input = {-3.0, 3.0 };

			double excepted = 0.00247262315663477;
			var actual = new NeuronOutputLayer(1,0).ComputeOutput(input);

			Assert.Equal(excepted,actual,15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsSecondNeuronTestFor3()
		{
			double[] input = { -3.0, 3.0 };

			double excepted = 0.997527376843365;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsFirstNeuronTestForTwice0()
		{
			double[] input = { 0.0, 0.0 };

			double excepted = 0.5;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsSecondNeuronTestForTwice0()
		{
			double[] input = { 0.0, 0.0 };

			double excepted = 0.5;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsFirstNeuronTestForDifferentSignsInInput()
		{
			double[] input = { 3.7, -5.4 };

			double excepted = 0.99988834665937;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsSecondNeuronTestForDifferentSignsInInput()
		{
			double[] input = { 3.7, -5.4 };

			double excepted = 0.000111653340629563;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsFirstNeuronTestForMinus3AndBiases()
		{
			double[] input = { -4.0, 2.0 };

			double excepted = 0.00247262315663477;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
			Assert.Equal(-3.0, input[0], 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsSecondNeuronTestFor3AndBiases()
		{
			double[] input = { -4.0, 2.0 };

			double excepted = 0.997527376843365;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
			Assert.Equal(3.0, input[1], 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsFirstNeuronTestForTwice0AndBiases()
		{
			double[] input = { -1.0, -1.0 };

			double excepted = 0.5;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
			Assert.Equal(0.0, input[0], 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsSecondNeuronTestForTwice0AndBiases()
		{
			double[] input = { -1.0, -1.0 };

			double excepted = 0.5;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input,_biases);

			Assert.Equal(excepted, actual, 15);
			Assert.Equal(0.0, input[1], 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsFirstNeuronTestForDifferentSignsInInputAndBiases()
		{
			double[] input = { 2.7, -6.4 };

			double excepted = 0.99988834665937;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
			Assert.Equal(3.7, input[0], 15);
		}

		[Fact]
		public void NnOutputFromTwoOutputsSecondNeuronTestForDifferentSignsInInputAndBiases()
		{
			double[] input = { 2.7, -6.4 };

			double excepted = 0.000111653340629563;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
			Assert.Equal(-5.4, input[1], 15);
		}

		[Fact]
		public void ThrowIndexWasOutOfRangeException()
		{
			double[] input = { 1.0, 1.0, 1.0 };
			var outputNeuron = new NeuronOutputLayer(1, 2);

			Assert.Throws<IndexOutOfRangeException>(() => outputNeuron.ComputeOutput(input, _biases));
		}

		[Fact]
		public void NnOutputFromThreeOutputs()
		{
			double[] input = { 1.0, 2.0, 3.0 };

			double exceptedFirstNeuron = 0.0900305731703805;
			double exceptedSecondNeuron = 0.244728471054798;
			double exceptedThirdNeuron = 0.665240955774822;

			var actualFirstNeuron = new NeuronOutputLayer(1, 0).ComputeOutput(input);
			var actualSecondNeuron = new NeuronOutputLayer(1, 1).ComputeOutput(input);
			var actualThirdNeuron = new NeuronOutputLayer(1, 2).ComputeOutput(input);

			Assert.Equal(exceptedFirstNeuron, actualFirstNeuron, 15);
			Assert.Equal(exceptedSecondNeuron, actualSecondNeuron, 15);
			Assert.Equal(exceptedThirdNeuron, actualThirdNeuron, 15);
		}

		[Fact]
		public void NnOutputFromFiveOutputs()
		{
			double[] input = { 1.0, 2.0, 3.0, 4.0, 5.0 };

			double exceptedFirstNeuron = 0.0116562309560396;
			double exceptedSecondNeuron = 0.0316849207961243;
			double exceptedThirdNeuron = 0.0861285444362687;
			double exceptedFourthNeuron = 0.234121657252737;
			double exceptedFifthNeuron = 0.636408646558831;

			var actualFirstNeuron = new NeuronOutputLayer(1, 0).ComputeOutput(input);
			var actualSecondNeuron = new NeuronOutputLayer(1, 1).ComputeOutput(input);
			var actualThirdNeuron = new NeuronOutputLayer(1, 2).ComputeOutput(input);
			var actualFourthNeuron = new NeuronOutputLayer(1, 3).ComputeOutput(input);
			var actualFifthNeuron = new NeuronOutputLayer(1, 4).ComputeOutput(input);

			Assert.Equal(exceptedFirstNeuron, actualFirstNeuron, 15);
			Assert.Equal(exceptedSecondNeuron, actualSecondNeuron, 15);
			Assert.Equal(exceptedThirdNeuron, actualThirdNeuron, 15);
			Assert.Equal(exceptedFourthNeuron, actualFourthNeuron, 15);
			Assert.Equal(exceptedFifthNeuron, actualFifthNeuron, 15);
		}
	}
}

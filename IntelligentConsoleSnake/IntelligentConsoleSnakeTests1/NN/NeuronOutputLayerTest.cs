using System;
using Xunit;
using IntelligentConsoleSnake.NN;

namespace IntelligentConsoleSnakeTests1.NN
{
	//TODO dopisz testy na więcej neuronów wyjściowych niż dwa
	public class NeuronOutputLayerTest
	{
		private double[] _biases;

		public NeuronOutputLayerTest()
		{
			_biases = new[] { 1.0, 1.0 };
		}

		[Fact]
		public void NnOutputFirstNeuronTestForMinus3()
		{
			double[] input = {-3.0, 3.0 };

			double excepted = 0.00247262315663477;
			var actual = new NeuronOutputLayer(1,0).ComputeOutput(input);

			Assert.Equal(excepted,actual,15);
		}

		[Fact]
		public void NnOutputSecondNeuronTestFor3()
		{
			double[] input = { -3.0, 3.0 };

			double excepted = 0.997527376843365;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFirstNeuronTestForTwice0()
		{
			double[] input = { 0.0, 0.0 };

			double excepted = 0.5;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputSecondNeuronTestForTwice0()
		{
			double[] input = { 0.0, 0.0 };

			double excepted = 0.5;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFirstNeuronTestForDifferentSignsInInput()
		{
			double[] input = { 3.7, -5.4 };

			double excepted = 0.99988834665937;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputSecondNeuronTestForDifferentSignsInInput()
		{
			double[] input = { 3.7, -5.4 };

			double excepted = 0.000111653340629563;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFirstNeuronTestForMinus3AndBiases()
		{
			double[] input = { -4.0, 2.0 };

			double excepted = 0.00247262315663477;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputSecondNeuronTestFor3AndBiases()
		{
			double[] input = { -4.0, 2.0 };

			double excepted = 0.997527376843365;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFirstNeuronTestForTwice0AndBiases()
		{
			double[] input = { -1.0, -1.0 };

			double excepted = 0.5;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputSecondNeuronTestForTwice0AndBiases()
		{
			double[] input = { -1.0, -1.0 };

			double excepted = 0.5;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input,_biases);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputFirstNeuronTestForDifferentSignsInInputAndBiases()
		{
			double[] input = { 2.7, -6.4 };

			double excepted = 0.99988834665937;
			var actual = new NeuronOutputLayer(1, 0).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void NnOutputSecondNeuronTestForDifferentSignsInInputAndBiases()
		{
			double[] input = { 2.7, -6.4 };

			double excepted = 0.000111653340629563;
			var actual = new NeuronOutputLayer(1, 1).ComputeOutput(input, _biases);

			Assert.Equal(excepted, actual, 15);
		}

		[Fact]
		public void ThrowIndexWasOutOfRangeException()
		{
			double[] input = { 1.0, 1.0, 1.0 };
			var outputNeuron = new NeuronOutputLayer(1, 2);

			Assert.Throws<IndexOutOfRangeException>(() => outputNeuron.ComputeOutput(input, _biases));
		}
	}
}

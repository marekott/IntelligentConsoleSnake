using System;

namespace IntelligentConsoleSnake.NN
{
	public class NeuronHiddenLayer : Neuron
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="numberOfInputs">counting from 1</param>
		/// <param name="neuronPositionFromTop">counting from 0</param>
		public NeuronHiddenLayer(int numberOfInputs, int neuronPositionFromTop) : base(numberOfInputs, neuronPositionFromTop)
		{
		}

		public override double ComputeOutput(double[] inputs, double[] biases = null)
		{
			if (biases != null)
			{
				inputs[NeuronPositionFromTop] += biases[NeuronPositionFromTop];
			}

			return HyperTan(inputs[NeuronPositionFromTop]);
		}

		private static double HyperTan(double x)
		{
			return Math.Tanh(x);
		}
	}
}

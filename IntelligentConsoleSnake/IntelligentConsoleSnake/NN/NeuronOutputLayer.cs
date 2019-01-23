using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentConsoleSnake.NN
{
	public class NeuronOutputLayer : Neuron
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="numberOfInputs">counting from 1</param>
		/// <param name="neuronPositionFromTop">counting from 0</param>
		public NeuronOutputLayer(int numberOfInputs, int neuronPositionFromTop) : base(numberOfInputs, neuronPositionFromTop)
		{
		}

		public override double ComputeOutput(double[] inputs, double[] biases = null)
		{
			if (biases != null)
			{
				inputs = AddBiases(inputs, biases);
			}

			double sum = 0.0;
			foreach (var input in inputs)
			{
				sum += Math.Exp(input);
			}

			var result = Math.Exp(inputs[NeuronPositionFromTop]) / sum;

			return result;
		}

		private double[] AddBiases(double[] inputs, double[] biases)
		{
			for (int i = 0; i < inputs.Length; i++)
			{
				inputs[i] += biases[i];
			}

			return inputs;
		}
	}
}

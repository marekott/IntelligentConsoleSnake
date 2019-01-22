using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentConsoleSnake.NN
{
	public class NeuronOutputLayer : Neuron
	{
		public NeuronOutputLayer(int numberOfInputs, int neuronPositionFromTop) : base(numberOfInputs, neuronPositionFromTop)
		{
		}

		public override double ComputeOutput(double[] inputs, double[] biases = null)
		{
			if (biases != null)
			{
				throw new NotImplementedException();
			}

			throw new NotImplementedException();
		}
	}
}

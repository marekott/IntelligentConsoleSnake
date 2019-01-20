using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentConsoleSnake.NN
{
	//TODO kiepsko, że trzeba podać w konstruktorze wartość dla liczby inputów bo nie będize prawdopodobnie potrzebne, jeżeli tak będzie zamień kolejność i zrób opcjonalnym
	public class NeuronHiddenLayer : Neuron
	{
		public NeuronHiddenLayer(int numberOfInputs, int neuronPositionFromTop) : base(numberOfInputs, neuronPositionFromTop)
		{
			
		}

		public override double ComputeOutput(double[] inputs)
		{
			return HyperTan(inputs[NeuronPositionFromTop]);
		}

		private static double HyperTan(double x)
		{
			return Math.Tanh(x);
		}
	}
}

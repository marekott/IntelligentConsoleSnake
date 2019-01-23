namespace IntelligentConsoleSnake.NN
{
	public class Neuron
	{
		private readonly int _numberOfInputs;
		protected readonly int NeuronPositionFromTop; 

		/// <summary>
		/// 
		/// </summary>
		/// <param name="numberOfInputs">counting from 1</param>
		/// <param name="neuronPositionFromTop">counting from 0</param>
		public Neuron(int numberOfInputs, int neuronPositionFromTop)
		{
			_numberOfInputs = numberOfInputs;
			NeuronPositionFromTop = neuronPositionFromTop;
		}

		public virtual double ComputeOutput(double[] inputs, double[] biases = null)
		{
			double inputSum = 0;

			for (int i = _numberOfInputs * NeuronPositionFromTop; i <= _numberOfInputs * (NeuronPositionFromTop + 1) - 1; i++) //for numberOfInputs=5 and neuronPositionFromTop=2 takes arguments from inputs(with Length=10) with indexes from <5:9>)
			{
				inputSum += inputs[i];
			}

			if (biases != null)
			{
				inputSum += biases[NeuronPositionFromTop];
			}

			return inputSum;
		}
	}
}

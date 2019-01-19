namespace IntelligentConsoleSnake.NN
{
	public class Neuron
	{
		private readonly int _numberOfInputs;
		private readonly int _neuronPositionFromTop; 

		/// <summary>
		/// 
		/// </summary>
		/// <param name="numberOfInputs">counting from 1</param>
		/// <param name="neuronPositionFromTop">counting from 1</param>
		public Neuron(int numberOfInputs, int neuronPositionFromTop)
		{
			_numberOfInputs = numberOfInputs;
			_neuronPositionFromTop = neuronPositionFromTop;
		}

		public double ComputeOutput(double[] inputs)
		{
			double inputSum = 0;

			for (int i = _numberOfInputs * _neuronPositionFromTop; i <= _numberOfInputs * (_neuronPositionFromTop + 1) - 1; i++)
			{
				inputSum += inputs[i];
			}

			return inputSum;
		}
	}
}

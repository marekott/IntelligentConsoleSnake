using System;

namespace IntelligentConsoleSnake.NN
{
	public class NNBuilder
	{
		private const int NumberOfNeuronsInFirstLayer = 5; 
		private const int NumberOfNeuronsInFirstHiddenLayer = 5; 
		private const int NumberOfNeuronsInOutputLayer = 2; 

		public static NeuralNetwork CreateNN()
		{
			NeuralNetwork neuralNetwork = new NeuralNetwork(NumberOfNeuronsInFirstLayer, NumberOfNeuronsInFirstHiddenLayer, NumberOfNeuronsInOutputLayer);

			return neuralNetwork;
		}
		

		public class NeuralNetwork
		{
			private readonly int _numberOfNeuronsInFirstLayer;
			private readonly int _numberOfNeuronsInFirstHiddenLayer;
			private readonly int _numberOfNeuronsInOutputLayer;

			private double[] inputSignals;
			private double[][] inputToHiddenWeights; // in first dimension are all input neurons and second dimension are their connections to neurons of first hidden layer
			private double[] firstHiddenLayerNeuronsBiases; //biases of each neuron of first hidden layer
			private double[] firstHiddenLayerOutputs; 
			private double[][] hiddenToOutputWeights; // in first dimension are all hidden layer neurons and second dimension are their connections to neurons of output layer

			private double[] outputsNeuronsBiases;
			private double[] outputsOfNetwork;
			private readonly double[] _weightsFromFile;

			public NeuralNetwork(int numberOfInputs, int numberOfNeuronsInFirstHiddenLayer, int numberOfOutputNeurons)
			{
				_numberOfNeuronsInFirstLayer = numberOfInputs;
				_numberOfNeuronsInFirstHiddenLayer = numberOfNeuronsInFirstHiddenLayer;
				_numberOfNeuronsInOutputLayer = numberOfOutputNeurons;

				inputSignals = new double[numberOfInputs];

				inputToHiddenWeights = MakeMatrix(numberOfInputs, numberOfNeuronsInFirstHiddenLayer);
				firstHiddenLayerNeuronsBiases = new double[numberOfNeuronsInFirstHiddenLayer];
				firstHiddenLayerOutputs = new double[numberOfNeuronsInFirstHiddenLayer];

				hiddenToOutputWeights = MakeMatrix(numberOfNeuronsInFirstHiddenLayer, numberOfOutputNeurons);
				outputsNeuronsBiases = new double[numberOfOutputNeurons];
				outputsOfNetwork = new double[numberOfOutputNeurons];

				_weightsFromFile = CsvReader.ReadWeightsAndSplitToArray();

				SetWeights();
			} 

			private static double[][] MakeMatrix(int rows,int cols, double startingValue = 0.0)
			{
				double[][] result = new double[rows][];
				for (int r = 0; r < result.Length; ++r)
				{
					result[r] = new double[cols];
				}

				for (int i = 0; i < rows; ++i)
				{
					for (int j = 0; j < cols; ++j)
					{
						result[i][j] = startingValue;
					}
				}

				return result;
			}

			public void SetWeights()
			{
				// copy serialized weights and biases in weights[] array
				// to i-h weights, i-h biases, h-o weights, h-o biases
				int numWeights = CountAllWeights();
				if (_weightsFromFile.Length != numWeights)
				{
					throw new Exception("Bad weights array in SetWeights");
				}

				int k = 0; // points into weights param

				for (int i = 0; i < _numberOfNeuronsInFirstLayer; ++i)
				{
					for (int j = 0; j < _numberOfNeuronsInFirstHiddenLayer; ++j)
					{
						inputToHiddenWeights[i][j] = _weightsFromFile[k++];
					}
				}

				for (int i = 0; i < _numberOfNeuronsInFirstHiddenLayer; ++i)
				{
					firstHiddenLayerNeuronsBiases[i] = _weightsFromFile[k++];
				}

				for (int i = 0; i < _numberOfNeuronsInFirstHiddenLayer; ++i)
				{
					for (int j = 0; j < _numberOfNeuronsInOutputLayer; ++j)
					{
						hiddenToOutputWeights[i][j] = _weightsFromFile[k++];
					}
				}

				for (int i = 0; i < _numberOfNeuronsInOutputLayer; ++i)
				{
					outputsNeuronsBiases[i] = _weightsFromFile[k++];
				}
			}

			private int CountAllWeights()
			{
				int result = (_numberOfNeuronsInFirstLayer * _numberOfNeuronsInFirstHiddenLayer) +
				             (_numberOfNeuronsInFirstHiddenLayer * _numberOfNeuronsInOutputLayer) + _numberOfNeuronsInFirstHiddenLayer + _numberOfNeuronsInOutputLayer;
				return result;
			}

			public int ChooseDirection(double[][] allPossibilityScenarios)
			{
				int winIndex = 1;
				double strongestDecision = 0;
				for (int i = 0; i < allPossibilityScenarios.GetLength(0); i++)
				{
					var x = ComputeOutputs(allPossibilityScenarios[i]);
					if (x[0] > strongestDecision)
					{
						strongestDecision = x[0];
						winIndex = i+1;
					}
				}

				return winIndex;
			}

			public double[] ComputeOutputs(double[] xValues)
			{
				double[] hSums = new double[_numberOfNeuronsInFirstHiddenLayer]; // hidden nodes sums scratch array
				double[] oSums = new double[_numberOfNeuronsInOutputLayer]; // output nodes sums

				for (int i = 0; i < xValues.Length; ++i) // copy x-values to inputs
					inputSignals[i] = xValues[i];
				// note: no need to copy x-values unless you implement a ToString.
				// more efficient is to simply use the xValues[] directly.

				for (int j = 0; j < _numberOfNeuronsInFirstHiddenLayer; ++j) // compute i-h sum of weights * inputs, wejście pierwszego neuronu jest kolejno przemnażane przez wagi jego połączeń z każdym neuronem warstwy ukrytej
				for (int i = 0; i < _numberOfNeuronsInFirstLayer; ++i)
					hSums[j] += inputSignals[i] * inputToHiddenWeights[i][j]; // note +=

				for (int i = 0; i < _numberOfNeuronsInFirstHiddenLayer; ++i) // add biases to hidden sums, hSums odpowiada za gradntowi wartości połączeń danego neuronu waarstwy ukrytej z każdym z neuronów warstwy wejściowej
					hSums[i] += firstHiddenLayerNeuronsBiases[i];

				for (int i = 0; i < _numberOfNeuronsInFirstHiddenLayer; ++i) // apply activation
					firstHiddenLayerOutputs[i] = HyperTan(hSums[i]); // hard-coded

				for (int j = 0; j < _numberOfNeuronsInOutputLayer; ++j) // compute h-o sum of weights * hOutputs
				for (int i = 0; i < _numberOfNeuronsInFirstHiddenLayer; ++i)
					oSums[j] += firstHiddenLayerOutputs[i] * hiddenToOutputWeights[i][j];

				for (int i = 0; i < _numberOfNeuronsInOutputLayer; ++i) // add biases to output sums
					oSums[i] += outputsNeuronsBiases[i];

				double[] softOut = Softmax(oSums); // all outputs at once for efficiency, softmax jest funkcją aktywacji neuronów warstwy wyjściowej
				Array.Copy(softOut, outputsOfNetwork, softOut.Length);

				double[] retResult = new double[_numberOfNeuronsInOutputLayer]; // could define a GetOutputs, odpowiedzi neuronów wartwy wyjściowej
				Array.Copy(outputsOfNetwork, retResult, retResult.Length);
				return retResult;
			}

			private static double HyperTan(double x)
			{
				if (x < -20.0) return -1.0; // approximation is correct to 30 decimals
				else if (x > 20.0) return 1.0;
				else return Math.Tanh(x);
			}

			private static double[] Softmax(double[] oSums)
			{
				// does all output nodes at once so scale
				// doesn't have to be re-computed each time

				double sum = 0.0;
				for (int i = 0; i < oSums.Length; ++i)
				{
					sum += Math.Exp(oSums[i]);
				}

				double[] result = new double[oSums.Length];
				for (int i = 0; i < oSums.Length; ++i)
				{
					result[i] = Math.Exp(oSums[i]) / sum;
				}

				return result; // now scaled so that xi sum to 1.0
			}
		}
	}
}

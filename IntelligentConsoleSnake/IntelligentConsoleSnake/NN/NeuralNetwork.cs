using System;

namespace IntelligentConsoleSnake.NN
{
	public class NeuralNetwork
	{
		private readonly int _numberOfNeuronsInFirstLayer; //actual 5
		private readonly int _numberOfNeuronsInFirstHiddenLayer; // actual 5
		private readonly int _numberOfNeuronsInOutputLayer; //actual 2

		private readonly double[][] _inputToHiddenWeights; // in first dimension are all input neurons and second dimension are their connections to neurons of first hidden layer
		private readonly double[] _firstHiddenLayerNeuronsBiases; //biases of each neuron of first hidden layer
		private readonly double[][] _hiddenToOutputWeights; // in first dimension are all hidden layer neurons and second dimension are their connections to neurons of output layer

		private readonly double[] _outputsNeuronsBiases;
		private readonly double[] _weightsFromFile;

		private readonly double[] _neuralNetworkResponse;

		private readonly Neuron[] _inputLayer;
		private readonly NeuronHiddenLayer[] _firstHiddenLayer;
		private readonly NeuronOutputLayer[] _outputLayer;

		public NeuralNetwork(int numberOfInputs, int numberOfNeuronsInFirstHiddenLayer, int numberOfOutputNeurons)
		{
			_numberOfNeuronsInFirstLayer = numberOfInputs;
			_numberOfNeuronsInFirstHiddenLayer = numberOfNeuronsInFirstHiddenLayer;
			_numberOfNeuronsInOutputLayer = numberOfOutputNeurons;

			_inputToHiddenWeights = MakeMatrix(numberOfInputs, numberOfNeuronsInFirstHiddenLayer);
			_firstHiddenLayerNeuronsBiases = new double[numberOfNeuronsInFirstHiddenLayer];

			_hiddenToOutputWeights = MakeMatrix(numberOfNeuronsInFirstHiddenLayer, numberOfOutputNeurons);
			_outputsNeuronsBiases = new double[numberOfOutputNeurons];

			_neuralNetworkResponse = new double[_numberOfNeuronsInOutputLayer];

			_weightsFromFile = CsvReader.ReadWeightsAndSplitToArray();

			SetWeights();

			//TODO wyciągniecie do osobnej metody, number of inputs jest na sztywno
			_inputLayer = new Neuron[numberOfInputs];
			for (int i = 0; i < numberOfInputs; i++)
			{
				_inputLayer[i] = new Neuron(1,i);
			}

			_firstHiddenLayer = new NeuronHiddenLayer[numberOfNeuronsInFirstHiddenLayer];
			for (int i = 0; i < numberOfNeuronsInFirstHiddenLayer; i++)
			{
				_firstHiddenLayer[i] = new NeuronHiddenLayer(numberOfInputs, i);
			}
			
			_outputLayer = new NeuronOutputLayer[numberOfOutputNeurons];
			for (int i = 0; i < numberOfOutputNeurons; i++)
			{
				_outputLayer[i] = new NeuronOutputLayer(numberOfNeuronsInFirstHiddenLayer, i);
			}
		} 

		private static double[][] MakeMatrix(int rows,int cols)
		{
			double[][] result = new double[rows][];
			for (int r = 0; r < result.Length; ++r)
			{
				result[r] = new double[cols];
			}

			return result;
		}

		private void SetWeights()
		{
			int numWeights = CountAllWeights();
			if (_weightsFromFile.Length != numWeights)
			{
				throw new Exception("Bad weights array in SetWeights");
			}

			int k = 0; 

			for (int i = 0; i < _numberOfNeuronsInFirstLayer; ++i)
			{
				for (int j = 0; j < _numberOfNeuronsInFirstHiddenLayer; ++j)
				{
					_inputToHiddenWeights[i][j] = _weightsFromFile[k++];
				}
			}

			for (int i = 0; i < _numberOfNeuronsInFirstHiddenLayer; ++i)
			{
				_firstHiddenLayerNeuronsBiases[i] = _weightsFromFile[k++];
			}

			for (int i = 0; i < _numberOfNeuronsInFirstHiddenLayer; ++i)
			{
				for (int j = 0; j < _numberOfNeuronsInOutputLayer; ++j)
				{
					_hiddenToOutputWeights[i][j] = _weightsFromFile[k++];
				}
			}

			for (int i = 0; i < _numberOfNeuronsInOutputLayer; ++i)
			{
				_outputsNeuronsBiases[i] = _weightsFromFile[k++];
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

		private double[] ComputeOutputs(double[] inputSignals)
		{
			double[] hSums = new double[_numberOfNeuronsInFirstHiddenLayer]; // hidden nodes sums scratch array
			double[] oSums = new double[_numberOfNeuronsInOutputLayer]; // output nodes sums

			//TODO zamiast tego fora możnaby dodać extension method, która obliczy hSums według poniższego wzoru ale poza tą klasą
			for (int j = 0; j < _numberOfNeuronsInFirstHiddenLayer; ++j) // compute i-h sum of weights * inputs, wejście pierwszego neuronu jest kolejno przemnażane przez wagi jego połączeń z każdym neuronem warstwy ukrytej
			{
				for (int i = 0; i < _numberOfNeuronsInFirstLayer; ++i)
				{
					hSums[j] += _inputLayer[i].ComputeOutput(inputSignals) * _inputToHiddenWeights[i][j];
				}
			}

			//TODO Biasy powinny się dodać wewnątrz neuronu więc ten for do wywalenia i ta część ma się obliczyć w _firstHiddenLayer[i].ComputeOutput(hSums);
			for (int i = 0; i < _numberOfNeuronsInFirstHiddenLayer; ++i) // add biases to hidden sums, hSums odpowiada za gradntowi wartości połączeń danego neuronu waarstwy ukrytej z każdym z neuronów warstwy wejściowej
			{
				hSums[i] += _firstHiddenLayerNeuronsBiases[i];
			}

			for (int j = 0; j < _numberOfNeuronsInOutputLayer; ++j) // compute h-o sum of weights * hOutputs
			{
				for (int i = 0; i < _numberOfNeuronsInFirstHiddenLayer; ++i)
				{
					oSums[j] += _firstHiddenLayer[i].ComputeOutput(hSums) * _hiddenToOutputWeights[i][j];
				}
			}

			for (int i = 0; i < _outputLayer.Length; i++)
			{
				_neuralNetworkResponse[i] = _outputLayer[i].ComputeOutput(oSums, _outputsNeuronsBiases);
			}

			return _neuralNetworkResponse;
		}
	}
}

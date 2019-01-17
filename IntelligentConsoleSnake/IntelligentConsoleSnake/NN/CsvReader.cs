using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IntelligentConsoleSnake.NN
{
	public static class CsvReader
	{
		private const char FileDelimiter = ';';
		private static readonly string CurrentDirectory;
		private static readonly DirectoryInfo Directory;
		private static readonly string FileName;

		static CsvReader()
		{
			CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
			Directory = new DirectoryInfo(CurrentDirectory);
			FileName = Path.Combine(Directory.FullName, @"NN\NNWeights8.txt");
		}

		public static double[] ReadWeightsAndSplitToArray()
		{
			using (var reader = new StreamReader(FileName))
			{
				List<string> wholeFile = new List<string>();
				while (!reader.EndOfStream)
				{
					wholeFile.Add(reader.ReadLine());
				}

				wholeFile = SplitBySymbol(FileDelimiter, wholeFile);
				var weights = AssignWeightsToArray(wholeFile);

				return weights;
			}

		}

		private static List<string> SplitBySymbol(char symbol, List<string> wholeFile)
		{
			wholeFile = wholeFile[0].Split(symbol).ToList();
			wholeFile.RemoveAt(wholeFile.Count - 1); //last char in file is ';' so there will by empty record which is deleted

			return wholeFile;
		}

		private static double[] AssignWeightsToArray(List<string> wholeFile)
		{
			double[] weights = InitializeWeightsArray(wholeFile);

			for (int i = 0; i < wholeFile.Count; i++)
			{
				weights[i] = double.Parse(wholeFile[i]);
			}

			return weights;
		}

		private static double[] InitializeWeightsArray(List<string> wholeFile)
		{
			double[] weights = new double[wholeFile.Count];
			return weights;
		}

		
	}
}

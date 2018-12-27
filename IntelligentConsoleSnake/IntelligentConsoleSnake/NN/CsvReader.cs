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
		private static List<string> _wholeFile;
		private static double[] _weights;

		static CsvReader()
		{
			CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
			Directory = new DirectoryInfo(CurrentDirectory);
			FileName = Path.Combine(Directory.FullName, @"NN\NNWeights8.txt");
			
		}

		public static double[] ReadWeightsAndSplitToArray()
		{
			//TODO: Jak się nie wyzeruje to przy drugim uruchomieniu kontruktora NN coś dalej siedzi w _weights i świruje. StackOverflow sugeruje nie używać klasy syatycznej ale można też chyba coś pokombinować z IDisposible
			_wholeFile = null;
			_wholeFile = new List<string>();
			_weights = null;

			using (var reader = new StreamReader(FileName))
			{
				while (!reader.EndOfStream)
				{
					_wholeFile.Add(reader.ReadLine());
				}
			}

			SplitBySymbol(FileDelimiter);
			InitializeWeightsArray();
			AssignWeightsToArray();
				
			return _weights;
			
		}

		private static void SplitBySymbol(char symbol)
		{
			_wholeFile = _wholeFile[0].Split(symbol).ToList();
			_wholeFile.RemoveAt(_wholeFile.Count - 1); //last char in file is ';'
		}

		private static void InitializeWeightsArray()
		{
			_weights = new double[_wholeFile.Count];
		}

		private static void AssignWeightsToArray()
		{
			for (int i = 0; i < _wholeFile.Count; i++)
			{
				_weights[i] = double.Parse(_wholeFile[i]);
			}
		}
	}
}

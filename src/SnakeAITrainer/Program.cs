using System;
using Microsoft.ML;

namespace SnakeAITrainer
{
    public class Program
    {
        public static void Main()
        {
            var mlContext = new MLContext();
            var ui = new UserInterface();
            var fastTree = new FastTree(mlContext);

            ui.DisplayModelTraining();

            fastTree.Train();

            ui.DisplayMetrics(fastTree.Evaluate());
            ui.SaveModel(mlContext, fastTree.Model, fastTree.DataView);

            Console.ReadKey();
        }
    }
}

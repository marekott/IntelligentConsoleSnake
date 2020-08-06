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
            var fastTreeTrainer = new FastTreeTrainer(mlContext);

            ui.DisplayModelTraining();

            fastTreeTrainer.Train();

            ui.DisplayMetrics(fastTreeTrainer.Evaluate());
            ui.SaveModel(mlContext, fastTreeTrainer.Model, fastTreeTrainer.DataView);

            Console.ReadKey();
        }
    }
}

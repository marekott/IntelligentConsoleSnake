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
            var logisticRegression = new LogisticRegression(mlContext);

            var filePath = ui.AskForFilePath();
            ui.DisplayModelTraining();

            logisticRegression.Train(filePath);

            ui.DisplayMetrics(logisticRegression.Evaluate());
            ui.SaveModel(mlContext, logisticRegression.Model, logisticRegression.DataView);
            
            Console.ReadKey();
        }
    }
}

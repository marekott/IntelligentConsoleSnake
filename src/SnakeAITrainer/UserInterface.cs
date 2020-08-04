using System;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace SnakeAITrainer
{
    public class UserInterface
    {
        public void DisplayModelTraining()
        {
            Console.Clear();
            Console.Write("Training model...");
        }

        public void DisplayMetrics(CalibratedBinaryClassificationMetrics metrics)
        {
            Console.Clear();

            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
        }

        public void SaveModel(MLContext mlContext, ITransformer model, IDataView dataView)
        {
            Console.Write("\nSave model?(Y/N):");
            var userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.Y:
                    mlContext.Model.Save(model, dataView.Schema, "model.zip");
                    Console.WriteLine("\nSaved.");
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("\nModel not saved.");
                    break;
            }
        }
    }
}

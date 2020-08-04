using System.Collections.Generic;
using System.IO;
using Microsoft.ML;
using SnakeAI.Models;

namespace SnakeAI
{
    public class SnakeAIModel
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _trainedModel;

        public SnakeAIModel() //TODO factory method
        {
            _mlContext = new MLContext();
            _trainedModel = _mlContext.Model.Load($@"{Directory.GetCurrentDirectory()}\model.zip", out _);
        }

        public IEnumerable<SnakeDataPrediction> MakePredictions(IEnumerable<SnakeData> data)
        {
            var snakeData = _mlContext.Data.LoadFromEnumerable(data);
            var predictions = _trainedModel.Transform(snakeData);

            return _mlContext.Data.CreateEnumerable<SnakeDataPrediction>(predictions, false);
        }
    }
}

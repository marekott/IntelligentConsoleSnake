using Microsoft.ML;
using Microsoft.ML.Data;
using SnakeAITrainer.Models;
using static Microsoft.ML.DataOperationsCatalog;

namespace SnakeAITrainer
{
    public class LogisticRegression
    {
        private readonly MLContext _mlContext;
        private TrainTestData _trainTestData;
        public ITransformer Model { get; private set; }
        public IDataView DataView { get; private set; }

        public LogisticRegression(MLContext mlContext)
        {
            _mlContext = mlContext;
        }

        public void Train(string filePath)
        {
            DataView = _mlContext.Data.LoadFromTextFile<SnakeData>(filePath, ';', true);
            _trainTestData = _mlContext.Data.TrainTestSplit(DataView, 0.2);

            var estimator = _mlContext.Transforms.Concatenate("Features", "SuggestedDirection",
                    "ObstacleUp", "ObstacleRight", "ObstacleDown", "ObstacleLeft")
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

            Model = estimator.Fit(_trainTestData.TrainSet);
        }

        public CalibratedBinaryClassificationMetrics Evaluate()
        {
            var predictions = Model.Transform(_trainTestData.TestSet);
            return _mlContext.BinaryClassification.Evaluate(predictions);
        }
    }
}

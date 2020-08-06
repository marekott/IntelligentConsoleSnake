using Microsoft.ML.Data;

namespace SnakeAI.Models
{
    public class SnakeDataPrediction : SnakeData
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
}

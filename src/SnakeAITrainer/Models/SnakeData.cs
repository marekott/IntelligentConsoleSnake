using Microsoft.ML.Data;

namespace SnakeAITrainer.Models
{
    public class SnakeData
    {
        [LoadColumn(0)]
        public float SuggestedDirection { get; set; }

        [LoadColumn(1)]
        public float ObstacleUp { get; set; }

        [LoadColumn(2)]
        public float ObstacleRight { get; set; }

        [LoadColumn(3)]
        public float ObstacleDown { get; set; }

        [LoadColumn(4)]
        public float ObstacleLeft { get; set; }

        [LoadColumn(5)]
        [ColumnName("Label")]
        public bool IsSnakeDead { get; set; }
    }
}

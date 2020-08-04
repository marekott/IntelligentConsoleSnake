using SnakeGame;

namespace SnakeAI
{
    public class ModelInputHelper
    {
        public bool ObstacleUp(Snake snake, Map map)
        {
            return snake.HeadDistanceFromTop == 1;
        }

        public bool ObstacleRight(Snake snake, Map map)
        {
            return snake.HeadDistanceFromLeft == map.Width - 1;
        }

        public bool ObstacleDown(Snake snake, Map map)
        {
            return snake.HeadDistanceFromTop == map.Height - 1;
        }

        public bool ObstacleLeft(Snake snake, Map map)
        {
            return snake.HeadDistanceFromLeft == 1;
        }
    }
}

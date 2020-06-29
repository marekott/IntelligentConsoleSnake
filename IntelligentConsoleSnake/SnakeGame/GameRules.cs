namespace SnakeGame
{
    public class GameRules
    {
        public bool IsGameOver(Snake snake, Map map)
        {
            return snake.HasSnakeEatenHimself() || snake.HeadDistanceFromLeft <= 0 || snake.HeadDistanceFromTop <= 0 ||
                   snake.HeadDistanceFromLeft >= map.Width || snake.HeadDistanceFromTop >= map.Height;
        }
    }
}

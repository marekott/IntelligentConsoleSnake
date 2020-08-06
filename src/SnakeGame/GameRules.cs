namespace SnakeGame
{
    public class GameRules
    {
        private bool _gameWasCancelled;

        public bool IsGameOver(Snake snake, Map map)
        {
            return _gameWasCancelled || snake.HasSnakeEatenHimself() || snake.HeadDistanceFromLeft <= 0 || 
                   snake.HeadDistanceFromTop <= 0 || snake.HeadDistanceFromLeft >= map.Width || snake.HeadDistanceFromTop >= map.Height;
        }

        public bool IsRewardCollected(Snake snake, Reward reward)
        {
            return snake.HeadDistanceFromLeft == reward.DistanceFromLeft &&
                   snake.HeadDistanceFromTop == reward.DistanceFromTop;
        }

        public void CancelGame()
        {
            _gameWasCancelled = true;
        }
    }
}

using System.Threading;

namespace SnakeGame
{
    public class Game
    {
        private readonly Snake _snake;
        private readonly Map _map;
        private readonly GameRules _gameRules;
        private bool _isGameOver;
        private readonly int _snakeSpeedInMilliseconds;

        public Game(Snake snake, Map map, GameRules gameRules, int snakeSpeedInMilliseconds)
        {
            _snake = snake;
            _map = map;
            _gameRules = gameRules;
            _snakeSpeedInMilliseconds = snakeSpeedInMilliseconds;
        }

        public void StartGame()
        {
            while (_isGameOver == false)
            {
                Thread.Sleep(_snakeSpeedInMilliseconds); 

                //Monitor is used to prevent situation when first element was moved and before second will inherit his direction of move, 
                //first once more changes direction of move. So the change is possible only between calls of MoveSnake method 
                Monitor.Enter(_snake);
                _snake.MoveSnake();
                _isGameOver = _gameRules.IsGameOver(_snake, _map);
                Monitor.Pulse(_snake);
                Monitor.Exit(_snake);
            }
        }

        public void TurnSnake(DirectionOfMove newDirection)
        {
            Monitor.Enter(_snake);
            _snake.TurnSnake(newDirection);
            Monitor.Exit(_snake);
        }
    }
}

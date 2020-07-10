using System.Threading;
using SnakeGame.Interfaces;

namespace SnakeGame
{
    public class Game
    {
        private readonly Snake _snake;
        private readonly Map _map;
        private readonly GameRules _gameRules;
        private readonly Reward _reward;
        private readonly IDisplay _display;
        private bool _isGameOver;
        private readonly int _snakeSpeedInMilliseconds;
        private int _score;

        public Game(Snake snake, Map map, GameRules gameRules, Reward reward, IDisplay display, int snakeSpeedInMilliseconds) //TODO builder zamiast x parametrów?
        {
            _snake = snake;
            _map = map;
            _gameRules = gameRules;
            _reward = reward;
            _display = display;
            _snakeSpeedInMilliseconds = snakeSpeedInMilliseconds;
        }

        public void StartGame()
        {
            _reward.GenerateRandom(_map);
            _score = 0;

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

                if (_gameRules.IsRewardCollected(_snake, _reward))
                {
                    _score++;
                    _reward.Collect(_score);
                    _snake.GrowSnake();
                    _reward.GenerateRandom(_map);
                }
            }

            _display.GameOver();
        }

        public void TurnSnake(DirectionOfMove newDirection)
        {
            Monitor.Enter(_snake);
            _snake.TurnSnake(newDirection);
            Monitor.Exit(_snake);
        }
    }
}

using System.Threading;
using SnakeGame.Interfaces;

namespace SnakeGame.Games
{
    public class AIGame : IGame //TODO dużo wspólnego z StandardGame, może klasa abstrakcyjna?
    {
        private readonly IntelligentSnake _snake;
        private readonly Map _map;
        private readonly GameRules _gameRules;
        private readonly Reward _reward;
        private readonly IDisplay _display;
        private bool _isGameOver;
        private readonly int _snakeSpeedInMilliseconds;
        private readonly ISnakeBot _snakeBot;
        private int _score;

        public AIGame(IntelligentSnake snake, Map map, GameRules gameRules, Reward reward, IDisplay display, int snakeSpeedInMilliseconds, ISnakeBot snakeBot) //TODO builder zamiast x parametrów?
        {
            _snake = snake;
            _map = map;
            _gameRules = gameRules;
            _reward = reward;
            _display = display;
            _snakeSpeedInMilliseconds = snakeSpeedInMilliseconds;
            _snakeBot = snakeBot;
        }

        public void StartGame()
        {
            _reward.GenerateRandom(_map);

            while (_isGameOver == false)
            {
                Thread.Sleep(_snakeSpeedInMilliseconds);

                TurnSnake(_snakeBot.ChooseDirection(_snake, _reward, _map));
                _snake.MoveSnake();
                _isGameOver = _gameRules.IsGameOver(_snake, _map);

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
            _snake.TurnSnake(newDirection);
        }

        public void CancelGame()
        {
            _gameRules.CancelGame();
            _display.GameOver();
        }
    }
}

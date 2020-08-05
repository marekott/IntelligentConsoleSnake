using System.Collections.Generic;
using System.Threading;
using SnakeGame.Interfaces;

namespace SnakeGame.Games
{
    public class AIGame : BaseGame
    {
        private readonly IntelligentSnake _snake;
        private readonly ISnakeBot _snakeBot;
        private HashSet<int> SnakeTopPositions => _snake.GetSnakeTopPositions();
        private HashSet<int> SnakeLeftPositions => _snake.GetSnakeLeftPositions();

        public AIGame(IntelligentSnake snake, Map map, GameRules gameRules, Reward reward, IDisplay display, int snakeSpeedInMilliseconds, ISnakeBot snakeBot) : base(map, gameRules, reward, display, snakeSpeedInMilliseconds)
        {
            _snake = snake;
            _snakeBot = snakeBot;
        }

        public override void StartGame()
        {
            Reward.GenerateRandom(Map,SnakeLeftPositions, SnakeTopPositions);

            while (IsGameOver == false)
            {
                Thread.Sleep(SnakeSpeedInMilliseconds);

                TurnSnake(_snakeBot.ChooseDirection(_snake, Reward, Map));
                _snake.MoveSnake();
                IsGameOver = GameRules.IsGameOver(_snake, Map);

                if (GameRules.IsRewardCollected(_snake, Reward))
                {
                    Score++;
                    Reward.Collect(Score);
                    _snake.GrowSnake();
                    Reward.GenerateRandom(Map, SnakeLeftPositions, SnakeTopPositions);
                }
            }

            Display.GameOver();
        }

        public override void TurnSnake(DirectionOfMove newDirection)
        {
            _snake.TurnSnake(newDirection);
        }
    }
}

using System.Threading;
using SnakeGame.Interfaces;

namespace SnakeGame.Games
{
    public class StandardGame : BaseGame
    {
        private readonly Snake _snake;
        private bool _doesSnakeMoved;

        public StandardGame(Snake snake, Map map, GameRules gameRules, Reward reward, IDisplay display, int snakeSpeedInMilliseconds) : base(map, gameRules, reward, display, snakeSpeedInMilliseconds)
        {
            _snake = snake;
        }

        public override void StartGame()
        {
            Reward.GenerateRandom(Map);

            while (IsGameOver == false)
            {
                Thread.Sleep(SnakeSpeedInMilliseconds); 

                //Monitor is used to prevent situation when first element was moved and before second will inherit his direction of move, 
                //first once more changes direction of move. So the change is possible only between calls of MoveSnake method 
                Monitor.Enter(_snake);
                _snake.MoveSnake();
                IsGameOver = GameRules.IsGameOver(_snake, Map);
                Monitor.Pulse(_snake);
                Monitor.Exit(_snake);

                _doesSnakeMoved = true;

                if (GameRules.IsRewardCollected(_snake, Reward))
                {
                    Score++;
                    Reward.Collect(Score);
                    _snake.GrowSnake();
                    Reward.GenerateRandom(Map);
                }
            }

            Display.GameOver();
        }

        public override void TurnSnake(DirectionOfMove newDirection)
        {
            if (_doesSnakeMoved)
            {
                Monitor.Enter(_snake);
                _snake.TurnSnake(newDirection);
                Monitor.Exit(_snake);

                _doesSnakeMoved = false;
            }
        }
    }
}

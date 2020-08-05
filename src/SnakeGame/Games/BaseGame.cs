using SnakeGame.Interfaces;

namespace SnakeGame.Games
{
    public abstract class BaseGame : IGame
    {
        protected readonly Map Map;
        protected readonly GameRules GameRules;
        protected readonly Reward Reward;
        protected readonly IDisplay Display;
        protected readonly int SnakeSpeedInMilliseconds;
        protected int Score;
        protected bool IsGameOver;

        protected BaseGame(Map map, GameRules gameRules, Reward reward, IDisplay display, int snakeSpeedInMilliseconds)
        {
            GameRules = gameRules;
            Display = display;
            Map = map;
            Reward = reward;
            SnakeSpeedInMilliseconds = snakeSpeedInMilliseconds;
        }

        public abstract void StartGame();

        public abstract void TurnSnake(DirectionOfMove newDirection);

        public virtual void CancelGame()
        {
            GameRules.CancelGame();
            Display.GameOver();
        }
    }
}

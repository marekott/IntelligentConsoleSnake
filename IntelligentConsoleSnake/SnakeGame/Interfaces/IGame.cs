namespace SnakeGame.Interfaces
{
    public interface IGame
    {
        void StartGame();
        void TurnSnake(DirectionOfMove newDirection);
        void CancelGame();
    }
}
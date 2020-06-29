namespace SnakeGame.Interfaces
{
    public interface IDisplay
    {
        void Draw(int distanceFromLeft, int distanceFromTop);
        void Clear(int distanceFromLeft, int distanceFromTop);
    }
}

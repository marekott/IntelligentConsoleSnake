namespace SnakeGame.Interfaces
{
    public interface IDisplay
    {
        void DrawSnakeElement(int distanceFromLeft, int distanceFromTop);
        void Clear(int distanceFromLeft, int distanceFromTop);
    }
}

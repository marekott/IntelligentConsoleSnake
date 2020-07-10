namespace SnakeGame.Interfaces
{
    public interface IDisplay
    {
        void SnakeElement(int distanceFromLeft, int distanceFromTop);
        void Reward(int distanceFromLeft, int distanceFromTop);
        void Score(int score);
        void Clear(int distanceFromLeft, int distanceFromTop);
    }
}

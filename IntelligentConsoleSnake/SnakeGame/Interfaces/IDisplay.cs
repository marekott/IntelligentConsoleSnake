namespace SnakeGame.Interfaces
{
    public interface IDisplay
    {
        void DrawSnakeElement(int distanceFromLeft, int distanceFromTop);
        void DrawReward(int distanceFromLeft, int distanceFromTop);
        void DrawScore(int score);
        void Clear(int distanceFromLeft, int distanceFromTop);
    }
}

using SnakeGame.Interfaces;

namespace SnakeGame.UnitTests.Stub
{
    public class Display : IDisplay
    {
        public void SnakeElement(int distanceFromLeft, int distanceFromTop)
        {
        }

        public void Reward(int distanceFromLeft, int distanceFromTop)
        {
        }

        public void Score(int score)
        {
        }

        public void Clear(int distanceFromLeft, int distanceFromTop)
        {
        }

        public void GameOver()
        {
        }
    }
}

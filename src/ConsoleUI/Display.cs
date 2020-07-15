using System;
using ConsoleUI.Configuration;
using SnakeGame.Interfaces;

namespace ConsoleUI
{
    public class Display : IDisplay //TODO singleton?
    {
        private readonly int _leftOffset;
        private readonly int _topOffset;
        private readonly int _scoreLabelTopPosition;
        private readonly int _gameOverLabelTopPosition;
        private readonly int _gameOverLabelLeftPosition;

        public Display(IConfigProvider configProvider)
        {
            _leftOffset = configProvider.GetGameLeftOffset();
            _topOffset = configProvider.GetGameTopOffset();
            _scoreLabelTopPosition = _topOffset - 1;
            _gameOverLabelTopPosition = _topOffset - 2;
            _gameOverLabelLeftPosition = _leftOffset + 10;
        }

        public void SnakeElement(int distanceFromLeft, int distanceFromTop)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(distanceFromLeft + _leftOffset, distanceFromTop + _topOffset);
            Console.Write("*");
        }

        public void Reward(int distanceFromLeft, int distanceFromTop)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(distanceFromLeft + _leftOffset, distanceFromTop + _topOffset);
            Console.Write("*");
        }

        public void Score(int score)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(_leftOffset, _scoreLabelTopPosition);
            Console.Write($"Score: {score}");
        }

        public void Clear(int distanceFromLeft, int distanceFromTop)
        {
            Console.SetCursorPosition(distanceFromLeft + _leftOffset, distanceFromTop + _topOffset);
            Console.Write(" ");
        }

        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_gameOverLabelLeftPosition, _gameOverLabelTopPosition);
            Console.Write("Game Over! Press any key to exit.");
        }
    }
}

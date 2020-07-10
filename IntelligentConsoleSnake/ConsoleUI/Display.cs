using System;
using ConsoleUI.Configuration;
using SnakeGame.Interfaces;

namespace ConsoleUI
{
    public class Display : IDisplay //TODO singleton?
    {
        private readonly int _leftOffset;
        private readonly int _topOffset;

        public Display(IConfigProvider configProvider)
        {
            _leftOffset = configProvider.GetGameLeftOffset();
            _topOffset = configProvider.GetGameTopOffset();
        }

        public void DrawSnakeElement(int distanceFromLeft, int distanceFromTop)
        {
            Console.SetCursorPosition(distanceFromLeft + _leftOffset, distanceFromTop + _topOffset);
            Console.Write("*");
        }

        public void Clear(int distanceFromLeft, int distanceFromTop)
        {
            Console.SetCursorPosition(distanceFromLeft + _leftOffset, distanceFromTop + _topOffset);
            Console.Write(" ");
        }
    }
}

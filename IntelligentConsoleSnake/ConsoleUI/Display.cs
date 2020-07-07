using System;
using SnakeGame.Interfaces;

namespace ConsoleUI
{
    public class Display : IDisplay
    {
        public void Draw(int distanceFromLeft, int distanceFromTop)
        {
            Console.SetCursorPosition(distanceFromLeft, distanceFromTop);
            Console.Write("*");
        }

        public void Clear(int distanceFromLeft, int distanceFromTop)
        {
            Console.SetCursorPosition(distanceFromLeft, distanceFromTop);
            Console.Write(" ");
        }
    }
}

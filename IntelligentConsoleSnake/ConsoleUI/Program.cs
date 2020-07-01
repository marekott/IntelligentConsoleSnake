using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SnakeGame;
using SnakeGame.Interfaces;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            var map = new Map(20, 50);
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(10,5,DirectionOfMove.Right),
                new SnakeElement(9,5,DirectionOfMove.Right),
                new SnakeElement(8,5,DirectionOfMove.Right),
                new SnakeElement(7,5,DirectionOfMove.Right)
            };
            var display = new Display();
            var snake = new Snake(snakeBody, display);
            var gameRules = new GameRules();
            var game = new Game(snake,map,gameRules,150);

            for (int i = 0; i <= map.Width; i++) //drawing border horizontally 
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("|");
                Console.SetCursorPosition(i, map.Height);
                Console.Write("|");
            }

            for (int i = 0; i <= map.Height; i++) //drawing border vertically
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(map.Width, i);
                Console.Write("|");
            }

            var snakeMovingTask = new Task(game.StartGame);
            snakeMovingTask.Start();

            while (snakeMovingTask.Status.Equals(TaskStatus.WaitingToRun) || snakeMovingTask.Status.Equals(TaskStatus.Running))
            {
                var newDirection = DirectionOfMove.Right;
                var pressedKey = Console.ReadKey(true);

                switch (pressedKey.Key)
                {
                    case ConsoleKey.RightArrow:
                        newDirection = DirectionOfMove.Right;
                        break;

                    case ConsoleKey.UpArrow:
                        newDirection = DirectionOfMove.Up;
                        break;

                    case ConsoleKey.LeftArrow:
                        newDirection = DirectionOfMove.Left;
                        break;

                    case ConsoleKey.DownArrow:
                        newDirection = DirectionOfMove.Down;
                        break;
                }

                game.TurnSnake(newDirection);
            }

        }
    }

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

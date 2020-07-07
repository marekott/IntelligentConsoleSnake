using System;
using System.Threading.Tasks;
using SnakeGame;

namespace ConsoleUI
{
    public class XYZ //TODO wymyślić sensowną nazwę
    {
        private readonly IGameCreator _gameCreator;

        public XYZ(IGameCreator gameCreator)
        {
            _gameCreator = gameCreator;
        }

        public void NewGame()
        {
            var map = new Map(20, 50);
            var game = _gameCreator.FactoryMethod();

            GameCore(map, game);
        }

        private static void GameCore(Map map, Game game)
        {
            DisplayMapBorders(map);

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

        private static void DisplayMapBorders(Map map)
        {
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
        }
    }
}

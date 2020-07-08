using System;
using System.Threading.Tasks;
using SnakeGame;

namespace ConsoleUI
{
    public class GameController
    {
        private readonly Game _game;

        public GameController(IGameCreator gameCreator)
        {
            _game = gameCreator.FactoryMethod();
        }

        public void NewGame()
        {
            var snakeMovingTask = new Task(_game.StartGame);
            snakeMovingTask.Start();

            ReadPlayerKey(snakeMovingTask);
        }

        private void ReadPlayerKey(Task snakeMovingTask)
        {
            while (snakeMovingTask.Status.Equals(TaskStatus.WaitingToRun) || snakeMovingTask.Status.Equals(TaskStatus.Running))
            {
                DirectionOfMove newDirection;
                var pressedKey = Console.ReadKey(true);

                switch (pressedKey.Key)
                {
                    case ConsoleKey.RightArrow:
                        newDirection = DirectionOfMove.Right;
                        _game.TurnSnake(newDirection);
                        break;

                    case ConsoleKey.UpArrow:
                        newDirection = DirectionOfMove.Up;
                        _game.TurnSnake(newDirection);
                        break;

                    case ConsoleKey.LeftArrow:
                        newDirection = DirectionOfMove.Left;
                        _game.TurnSnake(newDirection);
                        break;

                    case ConsoleKey.DownArrow:
                        newDirection = DirectionOfMove.Down;
                        _game.TurnSnake(newDirection);
                        break;
                }
            }
        }
    }
}

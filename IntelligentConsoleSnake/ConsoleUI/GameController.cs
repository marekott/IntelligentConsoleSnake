using System;
using System.Threading.Tasks;
using ConsoleUI.FactoryMethods;
using SnakeGame;
using SnakeGame.Interfaces;

namespace ConsoleUI
{
    public class GameController
    {
        private readonly IGameCreator _gameCreator;
        private IGame _game;

        public GameController(IGameCreator gameCreator)
        {
            _gameCreator = gameCreator;
        }

        public void NewGame()
        {
            _game = _gameCreator.FactoryMethod();

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

                    case ConsoleKey.Escape:
                        _game.CancelGame();
                        break;
                }
            }
        }
    }
}

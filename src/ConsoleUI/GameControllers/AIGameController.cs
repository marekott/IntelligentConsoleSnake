using System;
using System.Threading.Tasks;
using ConsoleUI.FactoryMethods;
using SnakeGame.Interfaces;

namespace ConsoleUI.GameControllers
{
    public class AIGameController : IGameController
    {
        private readonly IGameCreator _gameCreator;
        private IGame _game;

        public AIGameController(IGameCreator gameCreator)
        {
            _gameCreator = gameCreator;
        }

        public void NewGame()
        {
            _game = _gameCreator.AIGameFactoryMethod();

            var snakeMovingTask = new Task(_game.StartGame);
            snakeMovingTask.Start();

            ReadPlayerKey(snakeMovingTask);
        }

        private void ReadPlayerKey(Task snakeMovingTask)
        {
            while (snakeMovingTask.Status.Equals(TaskStatus.WaitingToRun) || snakeMovingTask.Status.Equals(TaskStatus.Running))
            {
                var pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    _game.CancelGame();
                }
            }
        }
    }
}

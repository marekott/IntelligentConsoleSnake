using System.Collections.Generic;
using ConsoleUI.Configuration;
using SnakeGame;
using SnakeGame.Games;
using SnakeGame.Interfaces;

namespace ConsoleUI.FactoryMethods
{
    public class GameCreator : IGameCreator
    {
        private readonly IConfigProvider _configProvider;
        private readonly IDisplay _display;

        public GameCreator(IConfigProvider configProvider, IDisplay display)
        {
            _configProvider = configProvider;
            _display = display;
        }

        public IGame StandardGameFactoryMethod()
        {
            var map = CreateMap();
            var snake = CreateSnake();
            var gameRules = new GameRules();
            var reward = new Reward(_display);
            return new StandardGame(snake, map, gameRules, reward, _display, 150);
        }

        private Map CreateMap()
        {
            return new Map(_configProvider.GetMapHeight(), _configProvider.GetMapWidth());
        }

        private Snake CreateSnake()
        {
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(10, 5, DirectionOfMove.Right),
            };
            var snake = new Snake(snakeBody, _display);
            SetSnakeInitialLength(snake);
            return snake;
        }

        private void SetSnakeInitialLength(Snake snake)
        {
            const int snakeInitialLength = 4;
            for (int i = 1; i < snakeInitialLength; i++)
            {
                snake.GrowSnake();
            }
        }
    }
}

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
        private readonly ISnakeBot _snakeBot;

        public GameCreator(IConfigProvider configProvider, IDisplay display, ISnakeBot snakeBot)
        {
            _configProvider = configProvider;
            _display = display;
            _snakeBot = snakeBot;
        }

        public IGame StandardGameFactoryMethod()
        {
            var map = CreateMap();
            var snake = CreateSnake();
            var gameRules = new GameRules();
            var reward = new Reward(_display);
            return new StandardGame(snake, map, gameRules, reward, _display, _configProvider.GetSnakeSpeedInMilliseconds());
        }

        public IGame AIGameFactoryMethod()
        {
            var map = CreateMap();
            var snake = CreateIntelligentSnake();
            var gameRules = new GameRules();
            var reward = new Reward(_display);
            return new AIGame(snake, map, gameRules, reward, _display, _configProvider.GetIntelligentSnakeSpeedInMilliseconds(), _snakeBot);
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

        private IntelligentSnake CreateIntelligentSnake()
        {
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(10, 5, DirectionOfMove.Right),
            };
            var snake = new IntelligentSnake(snakeBody, _display);
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

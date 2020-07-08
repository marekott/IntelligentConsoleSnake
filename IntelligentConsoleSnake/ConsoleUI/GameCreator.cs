using System.Collections.Generic;
using SnakeGame;

namespace ConsoleUI
{
    public class GameCreator : IGameCreator
    {
        public Game FactoryMethod()
        {
            var configProvider = new ConfigProvider();//TODO DI
            var map = new Map(configProvider.GetMapHeight(), configProvider.GetMapWidth());
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(10, 5, DirectionOfMove.Right),
                new SnakeElement(9, 5, DirectionOfMove.Right),
                new SnakeElement(8, 5, DirectionOfMove.Right),
                new SnakeElement(7, 5, DirectionOfMove.Right)
            };
            var display = new Display(configProvider); 
            var snake = new Snake(snakeBody, display);
            var gameRules = new GameRules();
            return new Game(snake, map, gameRules, 150);
        }
    }
}

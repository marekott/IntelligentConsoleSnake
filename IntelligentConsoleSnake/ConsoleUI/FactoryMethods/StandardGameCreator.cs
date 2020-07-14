using System.Collections.Generic;
using ConsoleUI.Configuration;
using SnakeGame;
using SnakeGame.Interfaces;

namespace ConsoleUI.FactoryMethods
{
    public class StandardGameCreator : IGameCreator
    {
        public IGame FactoryMethod()
        {
            var configProvider = new ConfigProvider();
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
            var reward = new Reward(display);
            return new StandardGame(snake, map, gameRules, reward, display, 150);
        }
    }
}

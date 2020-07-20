using System;
using SnakeGame.Interfaces;

namespace SnakeGame
{
    public class SnakeBot : ISnakeBot
    {
        private readonly Random _random;

        public SnakeBot()
        {
            _random = new Random();
        }

        public DirectionOfMove ChooseDirection(Snake snake, Reward reward, Map map)
        {
            return (DirectionOfMove)_random.Next(0, 4);
        }
    }
}

using System;
using System.Collections.Generic;
using SnakeGame.Extensions;
using SnakeGame.Interfaces;

namespace SnakeGame
{
    public class Reward
    {
        private readonly Random _random;
        private readonly IDisplay _display;
        public int DistanceFromLeft { get; private set; }
        public int DistanceFromTop { get; private set; }

        public Reward(IDisplay display)
        {
            _random = new Random();
            _display = display;
        }

        public void GenerateRandom(Map map, HashSet<int> excludeWidths, HashSet<int> excludeHeights)
        {
            DistanceFromLeft = _random.Next(1, map.Width, excludeWidths);
            DistanceFromTop = _random.Next(1, map.Height, excludeHeights);
            
            _display.Reward(DistanceFromLeft, DistanceFromTop);
        }

        public void Collect(int score)
        {
            _display.Clear(DistanceFromLeft, DistanceFromTop);
            _display.Score(score);
        }
    }
}

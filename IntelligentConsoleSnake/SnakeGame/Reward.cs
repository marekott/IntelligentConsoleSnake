﻿using System;
using SnakeGame.Interfaces;

namespace SnakeGame
{
    public class Reward
    {
        private readonly Random _random;
        private readonly IDisplay _display;
        public int DistanceFromLeft { get; private set; }
        public int DistanceFromTop { get; private set; }

        public Reward(Random random, IDisplay display)
        {
            _random = random;
            _display = display;
        }

        public void GenerateRandom(Map map)
        {
            DistanceFromLeft = _random.Next(1, map.Width);
            DistanceFromTop = _random.Next(1, map.Height);
            
            _display.DrawReward(DistanceFromLeft, DistanceFromTop);
        }

        public void Collect()
        {
            _display.Clear(DistanceFromLeft, DistanceFromTop);
        }
    }
}

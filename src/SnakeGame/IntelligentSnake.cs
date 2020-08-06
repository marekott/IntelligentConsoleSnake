using System.Collections.Generic;
using SnakeGame.Interfaces;

namespace SnakeGame
{
    public class IntelligentSnake : Snake
    {
        public IntelligentSnake(List<SnakeElement> body, IDisplay display) : base(body, display)
        { }

        public bool ObstacleUp()
        {
            for (int i = 1; i < Body.Count; i++)
            {
                if (Head.DistanceFromLeft == Body[i].DistanceFromLeft && Head.DistanceFromTop == Body[i].DistanceFromTop + 1)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObstacleRight()
        {
            for (int i = 1; i < Body.Count; i++)
            {
                if (Head.DistanceFromTop == Body[i].DistanceFromTop && Head.DistanceFromLeft == Body[i].DistanceFromLeft - 1)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObstacleDown()
        {
            for (int i = 1; i < Body.Count; i++)
            {
                if (Head.DistanceFromLeft == Body[i].DistanceFromLeft && Head.DistanceFromTop == Body[i].DistanceFromTop - 1)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObstacleLeft()
        {
            for (int i = 1; i < Body.Count; i++)
            {
                if (Head.DistanceFromTop == Body[i].DistanceFromTop && Head.DistanceFromLeft == Body[i].DistanceFromLeft + 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

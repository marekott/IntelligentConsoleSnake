using System.Collections.Generic;
using System.Linq;
using SnakeGame.Interfaces;

namespace SnakeGame
{
    public class Snake
    {
        protected readonly List<SnakeElement> Body;
        private readonly IDisplay _display;
        private int LastElementIndex => Body.Count - 1;
        protected readonly SnakeElement Head;
        public int HeadDistanceFromLeft => Head.DistanceFromLeft;
        public int HeadDistanceFromTop => Head.DistanceFromTop;

        public Snake(List<SnakeElement> body, IDisplay display)
        {
            Body = body;
            _display = display;
            Head = Body[0];
        }

        public void MoveSnake()
        {
            foreach (var element in Body)
            {
                _display.Clear(element.DistanceFromLeft, element.DistanceFromTop);
                element.Move();
                _display.SnakeElement(element.DistanceFromLeft, element.DistanceFromTop);
            }
            InheritDirectionOfMoveFromPreviousElement();
        }

        private void InheritDirectionOfMoveFromPreviousElement()
        {
            //this part provides ability to turn head of snake even if snake is not straight(in line). 
            //After each move beginning from end, each element take direction from element before it (element 0 not because player change its direction).
            for (int i = LastElementIndex; i > 0; i--)
            {
                Body[i].ChangeDirection(Body[i - 1].DirectionOfMove);
            }
        }

        public void GrowSnake()
        {
            Body.Add(Body[LastElementIndex].CreateSnakeElementBehind());
        }

        public void TurnSnake(DirectionOfMove newDirectionOfMove)
        {
            Head.ChangeDirection(newDirectionOfMove);
        }

        public bool HasSnakeEatenHimself()
        {
            for (int i = 1; i <= LastElementIndex; i++)
            {
                if (Head.DistanceFromLeft == Body[i].DistanceFromLeft && Head.DistanceFromTop == Body[i].DistanceFromTop)
                {
                    return true;
                }
            }

            return false;
        }

        public HashSet<int> GetSnakeTopPositions()
        {
            return new HashSet<int>(Body.Select(e => e.DistanceFromTop));
        }

        public HashSet<int> GetSnakeLeftPositions()
        {
            return new HashSet<int>(Body.Select(e => e.DistanceFromLeft));
        }
    }
}
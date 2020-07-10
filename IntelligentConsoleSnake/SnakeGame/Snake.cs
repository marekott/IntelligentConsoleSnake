using System.Collections.Generic;
using SnakeGame.Interfaces;

namespace SnakeGame
{
    public class Snake
    {
        private readonly List<SnakeElement> _body;
        private readonly IDisplay _display;
        private int LastElementIndex => _body.Count - 1;
        private readonly SnakeElement _head;
        public int HeadDistanceFromLeft => _head.DistanceFromLeft;
        public int HeadDistanceFromTop => _head.DistanceFromTop;

        public Snake(List<SnakeElement> body, IDisplay display)
        {
            _body = body;
            _display = display;
            _head = _body[0];
        }

        public void MoveSnake()
        {
            foreach (var element in _body)
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
                _body[i].ChangeDirection(_body[i - 1].DirectionOfMove);
            }
        }

        public void GrowSnake()
        {
            _body.Add(_body[LastElementIndex].CreateSnakeElementBehind());
        }

        public void TurnSnake(DirectionOfMove newDirectionOfMove)
        {
            _head.ChangeDirection(newDirectionOfMove);
        }

        public bool HasSnakeEatenHimself()
        {
            for (int i = 1; i <= LastElementIndex; i++)
            {
                if (_head.DistanceFromLeft == _body[i].DistanceFromLeft && _head.DistanceFromTop == _body[i].DistanceFromTop)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
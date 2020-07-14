using System;

namespace SnakeGame
{
    public class SnakeElement
    {
        public int DistanceFromLeft { get; private set; }
        public int DistanceFromTop { get; private set; }
        public DirectionOfMove DirectionOfMove { get; private set; }

        public SnakeElement(int distanceFromLeft, int distanceFromTop, DirectionOfMove directionOfMove)
        {
            DistanceFromLeft = distanceFromLeft;
            DistanceFromTop = distanceFromTop;

            if (IsValidDirectionOfMove(directionOfMove))
            {
                DirectionOfMove = directionOfMove;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(DirectionOfMove) ,"Invalid direction of move value.");
            }
        }

        private static bool IsValidDirectionOfMove(DirectionOfMove directionOfMove)
        {
            return directionOfMove == DirectionOfMove.Up || directionOfMove == DirectionOfMove.Down ||
                   directionOfMove == DirectionOfMove.Right || directionOfMove == DirectionOfMove.Left;
        }

        public void Move()
        {
            switch (DirectionOfMove)
            {
                case DirectionOfMove.Right:
                    DistanceFromLeft++;
                    break;
                case DirectionOfMove.Up:
                    DistanceFromTop--;
                    break;
                case DirectionOfMove.Left:
                    DistanceFromLeft--;
                    break;
                case DirectionOfMove.Down:
                    DistanceFromTop++;
                    break;
            }
        }

        public void ChangeDirection(DirectionOfMove newDirection)
        {
            if (IsValidDirectionOfMove(newDirection) == false)
            {
                throw new ArgumentOutOfRangeException(nameof(DirectionOfMove), "Invalid direction of move value.");
            }

            switch (newDirection)
            {
                case DirectionOfMove.Right when DirectionOfMove != DirectionOfMove.Left:
                    DirectionOfMove = newDirection;
                    break;
                case DirectionOfMove.Up when DirectionOfMove != DirectionOfMove.Down:
                    DirectionOfMove = newDirection;
                    break;
                case DirectionOfMove.Left when DirectionOfMove != DirectionOfMove.Right:
                    DirectionOfMove = newDirection;
                    break;
                case DirectionOfMove.Down when DirectionOfMove != DirectionOfMove.Up:
                    DirectionOfMove = newDirection;
                    break;
            }
        }

        public SnakeElement CreateSnakeElementBehind()
        {
            var newSnakeElement = (SnakeElement)MemberwiseClone();

            switch (DirectionOfMove)
            {
                case DirectionOfMove.Right:
                    newSnakeElement.DistanceFromLeft--;
                    break;

                case DirectionOfMove.Up:
                    newSnakeElement.DistanceFromTop++;
                    break;

                case DirectionOfMove.Left:
                    newSnakeElement.DistanceFromLeft++;
                    break;

                case DirectionOfMove.Down:
                    newSnakeElement.DistanceFromTop--;
                    break;
            }

            return newSnakeElement;
        }
    }
}

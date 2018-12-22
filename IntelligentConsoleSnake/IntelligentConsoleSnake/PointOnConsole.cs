using System;

namespace IntelligentConsoleSnake
{
	public class PointOnConsole
	{
		protected int LeftPositionProtected;
		public int LeftPosition => LeftPositionProtected;
		protected int TopPositionProtected;
		public int TopPosition => TopPositionProtected;
		protected string Symbol;
		public ConsoleColor PointColor { get; }
		public DirectionOfMoveEnum DirectionOfMove { get; set;}

		public PointOnConsole(int leftPositionProtected, int topPositionProtected, string symbol, DirectionOfMoveEnum directionOfMove = DirectionOfMoveEnum.Right, ConsoleColor pointColor = ConsoleColor.White)
		{
			LeftPositionProtected = leftPositionProtected;
			TopPositionProtected = topPositionProtected;
			Symbol = symbol;
			DirectionOfMove = directionOfMove;
			PointColor = pointColor;
		}

		public void MovePoint()
		{
			switch (DirectionOfMove)
			{
				case DirectionOfMoveEnum.Right:
					LeftPositionProtected += 1;
					DrawPoint();
					break;

				case DirectionOfMoveEnum.Left:
					LeftPositionProtected -= 1;
					DrawPoint();
					break;

				case DirectionOfMoveEnum.Up:
					TopPositionProtected -= 1;
					DrawPoint();
					break;

				case DirectionOfMoveEnum.Down:
					TopPositionProtected += 1;
					DrawPoint();
					break;
			}
		}

		public void DrawPoint()
		{
			BoardDrawer.WriteOnBoard(LeftPositionProtected, TopPosition, Symbol, PointColor);
		}

		public void ChangeDirectionOfMove(DirectionOfMoveEnum newDirection)
		{
			switch (newDirection)
			{
				case DirectionOfMoveEnum.Right when DirectionOfMove != DirectionOfMoveEnum.Right && DirectionOfMove != DirectionOfMoveEnum.Left:
					AssignNewDirection(newDirection);
					break;
				case DirectionOfMoveEnum.Up when DirectionOfMove != DirectionOfMoveEnum.Up && DirectionOfMove != DirectionOfMoveEnum.Down:
					AssignNewDirection(newDirection);
					break;
				case DirectionOfMoveEnum.Left when DirectionOfMove != DirectionOfMoveEnum.Left && DirectionOfMove != DirectionOfMoveEnum.Right:
					AssignNewDirection(newDirection);
					break;
				case DirectionOfMoveEnum.Down when DirectionOfMove != DirectionOfMoveEnum.Down && DirectionOfMove != DirectionOfMoveEnum.Up:
					AssignNewDirection(newDirection);
					break;
			}
		}

		private void AssignNewDirection(DirectionOfMoveEnum newDirection)
		{
			DirectionOfMove = newDirection;
		}

		public PointOnConsole CreateNewLastElementForSnakeList()
		{
			var newLastElement = new PointOnConsole(LeftPositionProtected, TopPosition,
											Symbol, DirectionOfMove, PointColor);

			switch (DirectionOfMove)
			{
				case DirectionOfMoveEnum.Right:
					newLastElement.LeftPositionProtected--;
					return newLastElement;

				case DirectionOfMoveEnum.Up:
					newLastElement.TopPositionProtected++;
					return newLastElement;

				case DirectionOfMoveEnum.Left:
					newLastElement.LeftPositionProtected++;
					return newLastElement;

				case DirectionOfMoveEnum.Down:
					newLastElement.TopPositionProtected--;
					return newLastElement;
			}

			return newLastElement;
		}

	}
}

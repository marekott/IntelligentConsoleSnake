using System.IO;
using IntelligentConsoleSnake;
using Xunit;

namespace IntelligentConsoleSnakeTests1
{
	public class PointOnConsoleTests
	{
		private readonly PointOnConsole _point;

		public PointOnConsoleTests()
		{
			_point = new PointOnConsole(1,1,"*");
		}

		[Fact()]
		public void MovePointRightTest()
		{
			PointOnConsole point = new PointOnConsole(1, 1, "*");

			try
			{
				point.MovePoint();
			}
			catch (IOException)
			{
				Assert.True(point.LeftPosition == 2);
			}
		}

		[Fact()]
		public void MovePointLeftTest()
		{
			PointOnConsole point = new PointOnConsole(1, 1, "*", DirectionOfMoveEnum.Left);

			try
			{
				point.MovePoint();
			}
			catch (IOException)
			{
				Assert.True(point.LeftPosition == 0);
			}
		}

		[Fact()]
		public void MovePointUpTest()
		{
			PointOnConsole point = new PointOnConsole(1, 1, "*", DirectionOfMoveEnum.Up);

			try
			{
				point.MovePoint();
			}
			catch (IOException)
			{
				Assert.True(point.TopPosition == 0);
			}
		}

		[Fact()]
		public void MovePointDownTest()
		{
			PointOnConsole point = new PointOnConsole(1, 1, "*", DirectionOfMoveEnum.Down);

			try
			{
				point.MovePoint();
			}
			catch (IOException)
			{
				Assert.True(point.TopPosition == 2);
			}
		}

		[Fact()]
		public void ChangeDirectionOfMoveToUp()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Up);

			DirectionOfMoveEnum expectedNewDirection = DirectionOfMoveEnum.Up;

			Assert.Equal(expectedNewDirection,_point.DirectionOfMove);
		}

		[Fact()]
		public void ChangeDirectionOfMoveToDown()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Down);

			DirectionOfMoveEnum expectedNewDirection = DirectionOfMoveEnum.Down;

			Assert.Equal(expectedNewDirection, _point.DirectionOfMove);
		}

		[Fact()]
		public void ChangeDirectionOfMoveToRight()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Down); //change default right direction
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Right); //actual test case

			DirectionOfMoveEnum expectedNewDirection = DirectionOfMoveEnum.Right;

			Assert.Equal(expectedNewDirection, _point.DirectionOfMove);
		}

		[Fact()]
		public void TryToChangeDirectionOfMoveFromRightToLeft()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Left);

			DirectionOfMoveEnum expectedNewDirection = DirectionOfMoveEnum.Right;

			Assert.Equal(expectedNewDirection, _point.DirectionOfMove);
		}

		[Fact()]
		public void ChangeDirectionOfMoveFromRightToRight()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Right);

			DirectionOfMoveEnum expectedNewDirection = DirectionOfMoveEnum.Right;

			Assert.Equal(expectedNewDirection, _point.DirectionOfMove);
		}

		[Fact()]
		public void TryToChangeDirectionOfMoveFromUpToDown()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Up); //change from default right to up
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Down); //actual test case

			DirectionOfMoveEnum expectedNewDirection = DirectionOfMoveEnum.Up;

			Assert.Equal(expectedNewDirection, _point.DirectionOfMove);
		}

		[Fact()]
		public void TryToChangeDirectionOfMoveFromLeftToRight()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Up); //change from default right to up
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Left); 
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Right); //actual test case

			DirectionOfMoveEnum expectedNewDirection = DirectionOfMoveEnum.Left;

			Assert.Equal(expectedNewDirection, _point.DirectionOfMove);
		}

		[Fact()]
		public void TryToChangeDirectionOfMoveFromDownToUp()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Down); //change from default right to down
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Up); //actual test case

			DirectionOfMoveEnum expectedNewDirection = DirectionOfMoveEnum.Down;

			Assert.Equal(expectedNewDirection, _point.DirectionOfMove);
		}

		[Fact()]
		public void CreateNewLastElementForSnakeListRightDirectionOfMoveTest()
		{
			var actualNewPoint = _point.CreateNewLastElementForSnakeList();
			PointOnConsole expectedNewPoint = new PointOnConsole(0,1,"*");

			Assert.Equal(expectedNewPoint.LeftPosition, actualNewPoint.LeftPosition);
			Assert.Equal(expectedNewPoint.TopPosition, actualNewPoint.TopPosition);
			Assert.Equal(expectedNewPoint.DirectionOfMove, actualNewPoint.DirectionOfMove);
		}

		//TODO przeanalizuj expectedNewPoint w testach poniżej czy na pewno takie wartości powinien mieć po wykonaniu tych ruchów
		[Fact()]
		public void CreateNewLastElementForSnakeListUpDirectionOfMoveTest()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Up);
			var actualNewPoint = _point.CreateNewLastElementForSnakeList();
			PointOnConsole expectedNewPoint = new PointOnConsole(1, 2, "*",DirectionOfMoveEnum.Up);

			Assert.Equal(expectedNewPoint.LeftPosition, actualNewPoint.LeftPosition);
			Assert.Equal(expectedNewPoint.TopPosition, actualNewPoint.TopPosition);
			Assert.Equal(expectedNewPoint.DirectionOfMove, actualNewPoint.DirectionOfMove);
		}

		[Fact()]
		public void CreateNewLastElementForSnakeListLeftDirectionOfMoveTest()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Up);
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Left);
			var actualNewPoint = _point.CreateNewLastElementForSnakeList();
			PointOnConsole expectedNewPoint = new PointOnConsole(2, 1, "*", DirectionOfMoveEnum.Left);

			Assert.Equal(expectedNewPoint.LeftPosition, actualNewPoint.LeftPosition);
			Assert.Equal(expectedNewPoint.TopPosition, actualNewPoint.TopPosition);
			Assert.Equal(expectedNewPoint.DirectionOfMove, actualNewPoint.DirectionOfMove);
		}

		[Fact()]
		public void CreateNewLastElementForSnakeListDownDirectionOfMoveTest()
		{
			_point.ChangeDirectionOfMove(DirectionOfMoveEnum.Down);
			var actualNewPoint = _point.CreateNewLastElementForSnakeList();
			PointOnConsole expectedNewPoint = new PointOnConsole(1, 0, "*", DirectionOfMoveEnum.Down);

			Assert.Equal(expectedNewPoint.LeftPosition, actualNewPoint.LeftPosition);
			Assert.Equal(expectedNewPoint.TopPosition, actualNewPoint.TopPosition);
			Assert.Equal(expectedNewPoint.DirectionOfMove, actualNewPoint.DirectionOfMove);
		}
	}
}
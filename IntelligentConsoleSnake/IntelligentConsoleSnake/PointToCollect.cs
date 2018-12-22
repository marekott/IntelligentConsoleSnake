using System;

namespace IntelligentConsoleSnake
{
	public class PointToCollect : PointOnConsole
	{
		public int PointWithValue { get; set; }

		public PointToCollect(int leftPositionProtected, int topPositionProtected, string symbol, DirectionOfMoveEnum directionOfMove, ConsoleColor pointColor = ConsoleColor.Yellow, int pointWithValue=1) : base(leftPositionProtected, topPositionProtected, symbol, directionOfMove, pointColor)
		{
			PointWithValue = pointWithValue;
		}

		public void ShowPointToCollect(Snake snake, Map map)
		{
			bool shouldContinueLoping = true;

			while (shouldContinueLoping)
			{
				GenerateNewPointPosition(map);

				//mechanism of preventing showing reward on snake
				foreach (var element in snake.ListOfPoints)
				{
					if (LeftPosition == element.LeftPosition & TopPosition == element.TopPosition)
					{
						shouldContinueLoping = true;
						break;
					}
					else shouldContinueLoping = false;
				}
			}

			DrawPoint();
		}

		private void GenerateNewPointPosition(Map map)
		{
			var randomWidth = new Random();
			var randomHeight = new Random();

			LeftPositionProtected = randomWidth.Next(map.MapStartingWidthValue + 1, map.MapWidth);
			TopPositionProtected = randomHeight.Next(map.MapStartingHeightValue + 1, map.MapHeight);
		}
	}
}

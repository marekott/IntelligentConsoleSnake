using System.Collections.Generic;
using System.Linq;

namespace IntelligentConsoleSnake
{
	public class Snake
	{
		private readonly LinkedList<PointOnConsole> _listOfPoints;
		public IEnumerable<PointOnConsole> ListOfPoints => _listOfPoints;  //Property to see position of elements but cannot Add, remove etc.

		public Snake(List<PointOnConsole> listOfPoints)
		{
			_listOfPoints = new LinkedList<PointOnConsole>();

			foreach(var point in listOfPoints)
			{
				_listOfPoints.AddLast(point);
			}
		}

		public void MoveSnake(PointToCollect reward, Map map , Score score)
		{
			ClearSnake();

			foreach(var point in _listOfPoints)
			{
				point.MovePoint();
			}

			InheritDirectionOfMoveFromPreviousElement();
			IsRewardCollected(reward, score, map);
			HasSnakeCrashedTheBorder(map);
			HasSnakeEatenHimself();
		}

		private void ClearSnake()
		{
			foreach (var element in _listOfPoints)
			{
				BoardDrawer.WriteOnBoard(element.LeftPosition, element.TopPosition, " ");
			}
		}

		private void InheritDirectionOfMoveFromPreviousElement()
		{
			//this part provides ability to turn head of snake even if snake is not straight(in line). 
			//After each move beginning from end, each element take direction from element before it (element 0 not because player change its direction).
			for (int j = _listOfPoints.Count - 1; j > 0; j--)
			{
				_listOfPoints.ElementAt(j).DirectionOfMove = _listOfPoints.ElementAt(j - 1).DirectionOfMove;
			}
		}

		private void IsRewardCollected(PointToCollect reward, Score score, Map map)
		{
			if (_listOfPoints.First.Value.LeftPosition == reward.LeftPosition & _listOfPoints.First.Value.TopPosition == reward.TopPosition)
			{
				score.ManipulateScore(reward);
				GrowSnake();
				reward.ShowPointToCollect(this, map);
			}
		}

		private void GrowSnake()
		{
			_listOfPoints.AddLast(_listOfPoints.Last.Value.CreateNewLastElementForSnakeList());
		}

		private void HasSnakeCrashedTheBorder(Map map)
		{
			if ((_listOfPoints.First.Value.LeftPosition <= map.MapStartingWidthValue || _listOfPoints.First.Value.LeftPosition >= map.MapWidth) ||
				(_listOfPoints.First.Value.TopPosition <= map.MapStartingHeightValue || _listOfPoints.First.Value.TopPosition >= map.MapHeight))
			{
				SnakeMovingTasks.GameOver();
			}
		}

		private void HasSnakeEatenHimself()
		{
			for (int i = 1; i < _listOfPoints.Count - 1; i++)
			{
				if (_listOfPoints.First.Value.LeftPosition == _listOfPoints.ElementAt(i).LeftPosition & _listOfPoints.First.Value.TopPosition == _listOfPoints.ElementAt(i).TopPosition)
				{
					SnakeMovingTasks.GameOver();
				}
			}
		}

		public void TurnSnake(DirectionOfMoveEnum newDirection)
		{
			_listOfPoints.First.Value.ChangeDirectionOfMove(newDirection);
		}

		// TODO: Zrób refactor poniższych metod
		public double[][] CreatePossibleScenariosOfMove(Map map)
		{
			//1 dimension: all 4 possible directions of move, 2 dimension: suggested direction(1.0 - right ,2.0 - up, 3.0 - left, 4.0 - down), obstacleUp(0.0 - no, 1.0 - yes), obstacleRight, obstacleDown, obstacleLeft
			double[][] possibleMoves = new double[4][];
			possibleMoves[0] = new[] { 1.0, IsObstacleUp(map), IsObstacleRight(map), IsObstacleDown(map), IsObstacleLeft(map) };
			possibleMoves[1] = new[] { 2.0, IsObstacleUp(map), IsObstacleRight(map), IsObstacleDown(map), IsObstacleLeft(map) };
			possibleMoves[2] = new[] { 3.0, IsObstacleUp(map), IsObstacleRight(map), IsObstacleDown(map), IsObstacleLeft(map) };
			possibleMoves[3] = new[] { 4.0, IsObstacleUp(map), IsObstacleRight(map), IsObstacleDown(map), IsObstacleLeft(map) };

			return possibleMoves;
		}

		private double IsObstacleUp(Map map)
		{
			int distanceToUpBorder = ComputeDistanceToUpBorder(map);
			bool isSnakeElementUp = CheckIfAnyElementOfSnakeIsAboveHead();

			if (distanceToUpBorder == 1 || isSnakeElementUp)
			{
				return 1.0;
			}

			return 0.0;
		}

		private int ComputeDistanceToUpBorder(Map map)
		{
			int distance = (_listOfPoints.First.Value.TopPosition - map.MapStartingHeightValue);

			return distance;
		}

		private bool CheckIfAnyElementOfSnakeIsAboveHead()
		{
			for (int i = 1; i < _listOfPoints.Count - 1; i++)
			{
				if (_listOfPoints.First.Value.LeftPosition == _listOfPoints.ElementAt(i).LeftPosition && (_listOfPoints.First.Value.TopPosition - _listOfPoints.ElementAt(i).TopPosition) == 1)
				{
					return true;
				}
			}
			return false;
		}

		private double IsObstacleRight(Map map)
		{
			int distanceToRightBorder = ComputeDistanceToRightBorder(map);
			bool isSnakeElementRight = CheckIfAnyElementOfSnakeIsRightToHead();

			if (distanceToRightBorder == -1 || isSnakeElementRight)
			{
				return 1.0;
			}

			return 0.0;
		}

		private int ComputeDistanceToRightBorder(Map map)
		{
			int distance = (_listOfPoints.First.Value.LeftPosition - map.MapWidth);

			return distance;
		}

		private bool CheckIfAnyElementOfSnakeIsRightToHead()
		{
			for (int i = 1; i < _listOfPoints.Count - 1; i++)
			{
				if (_listOfPoints.First.Value.LeftPosition - _listOfPoints.ElementAt(i).LeftPosition == -1 && _listOfPoints.First.Value.TopPosition == _listOfPoints.ElementAt(i).TopPosition)
				{
					return true;
				}
			}

			return false;
		}

		private double IsObstacleDown(Map map)
		{
			int distanceToDownBorder = ComputeDistanceToDownBorder(map);
			bool isSnakeElementDown = CheckIfAnyElementOfSnakeIsDownToHead();

			if (distanceToDownBorder == -1 || isSnakeElementDown)
			{
				return 1.0;
			}

			return 0.0;
		}

		private int ComputeDistanceToDownBorder(Map map)
		{
			int distance = (_listOfPoints.First.Value.TopPosition - map.MapHeight);

			return distance;
		}

		private bool CheckIfAnyElementOfSnakeIsDownToHead()
		{
			for (int i = 1; i < _listOfPoints.Count - 1; i++)
			{
				if (_listOfPoints.First.Value.LeftPosition == _listOfPoints.ElementAt(i).LeftPosition && (_listOfPoints.First.Value.TopPosition - _listOfPoints.ElementAt(i).TopPosition) == -1)
				{
					return true;
				}
			}

			return false;
		}

		private double IsObstacleLeft(Map map)
		{
			int distanceToLeftBorder = ComputeDistanceToLeftBorder(map);
			bool isSnakeElementLeft = CheckIfAnyElementOfSnakeIsLeftToHead();

			if (distanceToLeftBorder == 1 || isSnakeElementLeft)
			{
				return 1.0;
			}

			return 0.0;
		}

		private int ComputeDistanceToLeftBorder(Map map)
		{
			int distance = (_listOfPoints.First.Value.LeftPosition - map.MapStartingWidthValue);

			return distance;
		}

		private bool CheckIfAnyElementOfSnakeIsLeftToHead()
		{
			for (int i = 1; i < _listOfPoints.Count - 1; i++)
			{
				if (_listOfPoints.First.Value.LeftPosition - _listOfPoints.ElementAt(i).LeftPosition == 1 && _listOfPoints.First.Value.TopPosition == _listOfPoints.ElementAt(i).TopPosition)
				{
					return true;
				}
			}

			return false;
		}
	}
}

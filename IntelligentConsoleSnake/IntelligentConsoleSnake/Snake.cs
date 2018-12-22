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
	}
}

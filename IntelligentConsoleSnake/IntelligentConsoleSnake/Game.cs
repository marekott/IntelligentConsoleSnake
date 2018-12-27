using System;
using System.Collections.Generic;

namespace IntelligentConsoleSnake
{
	public class Game : GameVisualLogic
	{
		private const string SnakeAndRewardSymbol = "*";
		private static int _playerChoice;
		public static int InitialHeadOfSnakeLeftPosition = 20; 
		public static int InitialHeadOfSnakeTopPosition = 15;
		private static Snake _playersSnake;

		public static void InitializeGame()
		{
			var map = new Map();
			map.SetConsoleWidthAndHeight();
			while (true)
			{
				_playerChoice = Menu.LoadMenu();

				//TODO: Może switch?
				if (_playerChoice == 1)
				{
					SnakeMovingTasks.NewGame();
					StartGame(map);
				}
				else if (_playerChoice == 2)
				{
					SnakeMovingTasks.NewGame();
					StartGameWithAi(map);
				}
				else if (_playerChoice == 3)
				{
					ShowInstructions();
				}
				else if (_playerChoice == 4)
				{
					ExitGame();
					break;
				}
			}
		}

		private static void StartGame(Map map)
		{
			map.DrawMap();

			var reward = new PointToCollect(InitialHeadOfSnakeLeftPosition + 10, InitialHeadOfSnakeTopPosition - 5, SnakeAndRewardSymbol, DirectionOfMoveEnum.Right);
			reward.DrawPoint();

			_playersSnake = new Snake(CreateListOfPointsForSnakeConstructor());

			SnakeMovingTasks snakeTasks = new SnakeMovingTasks(_playersSnake);

			var movingSnake = snakeTasks.MovingSnakeAction(reward, map);
			var readingKeyFromPlayer = snakeTasks.TurningSnakeAction();

			movingSnake.Start();
			readingKeyFromPlayer.Start();

			movingSnake.Wait();
			GameOver();
			Console.ReadKey(true);
		}

		private static void StartGameWithAi(Map map)
		{
			//TODO: nie da się przerwać gry
			map.DrawMap();

			var reward = new PointToCollect(InitialHeadOfSnakeLeftPosition + 10, InitialHeadOfSnakeTopPosition - 5, SnakeAndRewardSymbol, DirectionOfMoveEnum.Right);
			reward.DrawPoint();

			_playersSnake = new Snake(CreateListOfPointsForSnakeConstructor());

			NN.NeuralNetwork neuralNetwork = new NN.NeuralNetwork(5, 5, 2);

			SnakeMovingTasks snakeTasks = new SnakeMovingTasks(_playersSnake);
			snakeTasks.MoveSnakeAutomatically(reward, map, neuralNetwork);

			GameOver();
			Console.ReadKey(true);
		}

		private static List<PointOnConsole> CreateListOfPointsForSnakeConstructor()
		{
			List<PointOnConsole> listOfPointsForSnakeConstructor = new List<PointOnConsole>();
			for (int pointLeftPosition = InitialHeadOfSnakeLeftPosition; pointLeftPosition > InitialHeadOfSnakeTopPosition; pointLeftPosition--)
			{
				listOfPointsForSnakeConstructor.Add(new PointOnConsole(pointLeftPosition, InitialHeadOfSnakeTopPosition, SnakeAndRewardSymbol));
			}

			return listOfPointsForSnakeConstructor;
		}
	}
}

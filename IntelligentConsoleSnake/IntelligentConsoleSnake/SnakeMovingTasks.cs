﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntelligentConsoleSnake
{
	public class SnakeMovingTasks
	{
		private const int PauseBeforeEachSnakeMoveInMilliseconds = 150; 
		private static bool _doesSnakeMoved;
		private readonly Snake _snake;
		private readonly Score _score;
		private static bool _isGameOver;
		private static readonly NN.NeuralNetwork NeuralNetwork = new NN.NeuralNetwork(5, 5, 2);

		public SnakeMovingTasks(Snake snake)
		{
			_snake = snake;
			_score = new Score();
		}

		public Task MovingSnakeAction(PointToCollect reward, Map map, bool isAiPlaying)
		{
			Action Moving = () =>
			{
				while (!_isGameOver)
				{
					Thread.Sleep(PauseBeforeEachSnakeMoveInMilliseconds);

					//Monitor is used to prevent situation when first element was moved and before second will inherit his direction of move, 
					//first once more changes direction of move. So the change is possible only between calls of MoveSnake method 
					Monitor.Enter(_snake);
					if (isAiPlaying)
					{
						TurnSnakeAutomatically(map);
					}
					_snake.MoveSnake(reward, map, _score);
					_doesSnakeMoved = true;
					Monitor.Pulse(_snake);
					Monitor.Exit(_snake);
				}
			};

			Task movingSnakeTask = new Task(Moving);

			return movingSnakeTask;
		}

		public Task TurningSnakeAction(bool isAiPlaying)
		{
			Action ReadingKey = () =>
			{
				while (!_isGameOver)
				{
					if (_doesSnakeMoved)
					{
						ReadPlayerKey(isAiPlaying);
						_doesSnakeMoved = false;
					}
				}
			};

			Task readKeyTask = new Task(ReadingKey);

			return readKeyTask;
		}


		private void ReadPlayerKey(bool isAiPlaying)
		{
			DirectionOfMoveEnum newDirection = DirectionOfMoveEnum.Right;

			ConsoleKeyInfo pressedKey = Console.ReadKey(true);

			switch (pressedKey.Key)
			{
				case ConsoleKey.RightArrow:
					newDirection = DirectionOfMoveEnum.Right;
					break;

				case ConsoleKey.UpArrow:
					newDirection = DirectionOfMoveEnum.Up;
					break;

				case ConsoleKey.LeftArrow:
					newDirection = DirectionOfMoveEnum.Left;
					break;

				case ConsoleKey.DownArrow:
					newDirection = DirectionOfMoveEnum.Down;
					break;

				case ConsoleKey.Escape:
					GameOver();
					return;
			}

			Monitor.Enter(_snake);
			if(!isAiPlaying)
			{
				_snake.TurnSnake(newDirection);
			}
			Monitor.Exit(_snake);
		}

		public void TurnSnakeAutomatically(Map map)
		{
			double[][] possibleMoves = _snake.CreatePossibleScenariosOfMove(map);

			var winIndex = NeuralNetwork.ChooseDirection(possibleMoves);
			TurnIntelligentSnake(winIndex);
		}

		private void TurnIntelligentSnake(int winIndex)
		{
			DirectionOfMoveEnum newDirection = DirectionOfMoveEnum.Right;

			switch (winIndex)
			{
				case 1:
					newDirection = DirectionOfMoveEnum.Right;
					break;
				case 2:
					newDirection = DirectionOfMoveEnum.Up;
					break;
				case 3:
					newDirection = DirectionOfMoveEnum.Left;
					break;
				case 4:
					newDirection = DirectionOfMoveEnum.Down;
					break;
			}

			_snake.TurnSnake(newDirection);
		}


		public static void GameOver()
		{
			_isGameOver = true;
		}

		public static void NewGame()
		{
			_isGameOver = false;
		}
	}
}

using System;

namespace IntelligentConsoleSnake
{
	public static class Menu
	{
		private const int BorderStartingWidth = 18;
		private const int BorderClosingWidth = 53;
		private const int BorderStartingHeight = 10;
		private const int BorderClosingHeight = 20;
		private const int TitlePositionLeft = 30;
		private const int TitlePositionTop = 5;
		private const int StartGameTextPositionLeft = 21;
		private const int StartGameTextPositionTop = 12;
		private const string ConsoleTitle = "CONSOLE SNAKE";
		private const string FirstOptionToChooseForPlayer = "1. Start Game";
		private const string SecondOptionToChooseForPlayer = "2. Instructions";
		private const string ThirdOptionToChooseForPlayer = "3. Exit Game";
		private const ConsoleColor TitleColor = ConsoleColor.Green;

		public static int LoadMenu()
		{
			Console.Clear();

			var playerChoice = DisplayMenu();

			Console.Clear();
			return playerChoice;
		}

		private static int DisplayMenu()
		{
			BoardDrawer.DrawBorders(BorderStartingWidth, BorderClosingWidth, BorderStartingHeight, BorderClosingHeight);
			BoardDrawer.WriteOnBoard(TitlePositionLeft, TitlePositionTop, ConsoleTitle, TitleColor);
			BoardDrawer.WriteOnBoard(StartGameTextPositionLeft, StartGameTextPositionTop, FirstOptionToChooseForPlayer);
			BoardDrawer.WriteOnBoard(StartGameTextPositionLeft, StartGameTextPositionTop + 2, SecondOptionToChooseForPlayer);
			BoardDrawer.WriteOnBoard(StartGameTextPositionLeft, StartGameTextPositionTop + 4, ThirdOptionToChooseForPlayer);

			var choosedOption = ReadPlayerChoice();

			return choosedOption;
		}

		private static int ReadPlayerChoice()
		{
			bool shouldMenuBeOpen = true;
			int choosedOption=1; 

			while (shouldMenuBeOpen)
			{
				ConsoleKeyInfo pressedKey = Console.ReadKey(true);

				switch (pressedKey.Key)
				{
					case ConsoleKey.D1:
						choosedOption = 1;
						shouldMenuBeOpen = false;
					break;

					case ConsoleKey.D2:
						choosedOption = 2;
						shouldMenuBeOpen = false;
					break;

					case ConsoleKey.D3:
						choosedOption = 3;
						shouldMenuBeOpen = false;
					break;
				}
			}

			return choosedOption;
		}
	}
}

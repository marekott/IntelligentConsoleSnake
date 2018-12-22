using System;

namespace IntelligentConsoleSnake
{
	public class GameVisualLogic
	{
		private const int ExitAndInstructionsTextLeftPosition = 0;
		private const int ExitAndInstructionsTextTopPosition = 2;
		private const string InstructionsText = "To move your snake use keybord arrows. Collect yellow elements\nto gain more points. " +
					"\nEvry collected point makes your snake to become bigger." +
					"\nYou will lose if snake will crash the border or eat himself." +
					"\nIf you want to exit during the game press Escape." +
					"\n\nPress any key to return to menu.";
		private const string ExitText = "Thank you for playing my game.\n" +
					"To see more stuff, visit my github: https://github.com/marekott" +
					"\nIf you have questions,\n" + "contact me on on LinkedIn: www.linkedin.com/in/marek-ott-171608152";
		private const int GameOverTextLeftPosition = 25; 
		private const int GameOverTextTopPosition = 3; 
		private const string GameOverText = "Game Over! Press any key to exit."; 
		private const ConsoleColor GameOverTextColor = ConsoleColor.Red; 

		protected static void ShowInstructions()
		{
			BoardDrawer.WriteOnBoard(ExitAndInstructionsTextLeftPosition, ExitAndInstructionsTextTopPosition, InstructionsText);
			Console.ReadKey(true);
		}

		protected static void ExitGame()
		{
			BoardDrawer.WriteOnBoard(ExitAndInstructionsTextLeftPosition, ExitAndInstructionsTextTopPosition, ExitText);
			Console.ReadKey(true);
		}

		protected static void GameOver()
		{
			BoardDrawer.WriteOnBoard(GameOverTextLeftPosition, GameOverTextTopPosition, GameOverText, GameOverTextColor);
		}
	}
}

using System;

namespace IntelligentConsoleSnake
{
	public class BoardDrawer
	{
		public static void DrawBorders(int borderStartingWidth, int borderClosingWidth, int borderStartingHeight, int borderClosingHeight, ConsoleColor textColor = ConsoleColor.White, string symbol = "*")
		{
			for (int i = borderStartingWidth; i <= borderClosingWidth; i++) //drawing border horizontally 
			{
				Console.ForegroundColor = textColor;
				Console.SetCursorPosition(i, borderStartingHeight);
				Console.Write(symbol);
				Console.SetCursorPosition(i, borderClosingHeight);
				Console.Write(symbol);
			}

			for (int i = borderStartingHeight; i <= borderClosingHeight; i++) //drawing border vertically
			{
				Console.ForegroundColor = textColor;
				Console.SetCursorPosition(borderClosingWidth, i);
				Console.Write(symbol);
				Console.SetCursorPosition(borderStartingWidth, i);
				Console.Write(symbol);
			}
		}

		public static void WriteOnBoard(int leftPosition, int topPosition, string whatToWrite, ConsoleColor color = ConsoleColor.White)
		{
			Console.SetCursorPosition(leftPosition, topPosition);
			Console.ForegroundColor = color;
			Console.WriteLine(whatToWrite);
		}
	}
}

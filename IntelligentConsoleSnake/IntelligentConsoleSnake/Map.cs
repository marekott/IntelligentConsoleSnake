using System;

namespace IntelligentConsoleSnake
{
	public class Map
	{
		private const int MapWidthConst = 70;
		private const int MapHeightConst = 25;
		public int MapWidth => MapWidthConst;
		public int MapHeight => MapHeightConst;
		public int MapStartingWidthValue => MapWidthConst - (MapWidthConst - 5); //-5 is offset from console border
		public int MapStartingHeightValue => MapHeightConst - (MapHeightConst - 4); //-4 is offset from console border
		private const ConsoleColor BorderColor = ConsoleColor.White;
		private const string Symbol = "|";

		public void SetConsoleWidthAndHeight()
		{
			Console.SetWindowSize(MapWidth+6, MapHeight+4); //6 and 4 are offset from console border
		}

		public void DrawMap()
		{
			BoardDrawer.DrawBorders(MapStartingWidthValue, MapWidth, MapStartingHeightValue, MapHeight, BorderColor, Symbol);
		}
	}
}

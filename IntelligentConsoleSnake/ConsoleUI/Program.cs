using System;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70,30);

            var gameCreator = new GameCreator();
            var xyz = new XYZ(gameCreator);
            var menu = new Menu(xyz); //TODO Constructor DI
            menu.DisplayMenu();
        }
    }
}

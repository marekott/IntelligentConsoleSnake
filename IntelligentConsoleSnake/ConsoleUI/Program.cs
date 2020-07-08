using System;
using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70,30);

            var gameCreator = new GameCreator();
            var gameController = new GameController(gameCreator);
            var configProvider = new ConfigProvider();
            var menu = new Menu(gameController, configProvider); //TODO Constructor DI
            menu.DisplayMenu();
        }
    }
}

using System;
using ConsoleUI.Configuration;

namespace ConsoleUI
{
    public class Menu
    {
        private readonly GameController _gameController;
        private readonly IConfigProvider _configProvider;
        private const string ConsoleTitle = "CONSOLE SNAKE";
        private const string StartNewGameLabel = "1. Start new game";
        private const string InstructionLabel = "2. Instructions";
        private const string ExitGameLabel = "3. Exit Game";
        private const string InstructionsText = "Game provides to modes. In first you control the snake, second allows " +
                                               "\nyou to watch how trained neural network is playing." +
                                               "\nIf you are controlling a snake, use keybord arrows to turn it." +
                                               "\nGame rules:" +
                                               "\nCollecting yellow elements earns points." +
                                               "\nEvery collected point is making snake bigger." +
                                               "\nThe game is over when snake will crash the border or eats himself." +
                                               "\nIf you want to exit during the game press Escape." +
                                               "\n\nPress any key to return to menu.";
        private const string ExitText = "Thank you for playing my game.\n" +
                                        "To see more stuff, visit my github: https://github.com/marekott" +
                                        "\nIf you have any questions,\n" + "contact me on on LinkedIn: www.linkedin.com/in/marek-ott-171608152";

        public Menu(GameController gameController, IConfigProvider configProvider)
        {
            _gameController = gameController;
            _configProvider = configProvider;
        }

        public void DisplayMenu()
        {
            var gameInProgress = true;

            while (gameInProgress)
            {
                Console.Clear();
                DisplayMenuBorders();
                DisplayMenuOptions();
                var selectedMenuOption = Console.ReadKey(true);

                switch (selectedMenuOption.Key)
                {
                    case ConsoleKey.D1:
                        DisplayMapBorders();
                        _gameController.NewGame();
                        break;

                    case ConsoleKey.D2:
                        DisplayInstruction();
                        break;

                    case ConsoleKey.D3:
                        gameInProgress = false;
                        break;
                }
            }

            DisplayExitText();
        }

        private void DisplayMenuBorders()
        {
            const int bordersWidth = 30;
            const int bordersHeight = 8;
            const int leftOffset = 20;
            const int topOffset = 10;

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i <= bordersWidth; i++) //drawing border horizontally 
            {
                Console.SetCursorPosition(i + leftOffset, topOffset);
                Console.Write("*");
                Console.SetCursorPosition(i + leftOffset, bordersHeight + topOffset);
                Console.Write("*");
            }

            for (int i = 0; i <= bordersHeight; i++) //drawing border vertically
            {
                Console.SetCursorPosition(leftOffset, i + topOffset);
                Console.Write("*");
                Console.SetCursorPosition(bordersWidth + leftOffset, i + topOffset);
                Console.Write("*");
            }
        }

        private void DisplayMenuOptions()
        {
            const int leftOffset = 25;
            const int topOffset = 5;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(leftOffset + 3, topOffset);
            Console.WriteLine(ConsoleTitle);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(leftOffset, topOffset + 7);
            Console.WriteLine(StartNewGameLabel);
            Console.SetCursorPosition(leftOffset, topOffset + 9);
            Console.WriteLine(InstructionLabel);
            Console.SetCursorPosition(leftOffset, topOffset + 11);
            Console.WriteLine(ExitGameLabel);
        }

        private void DisplayMapBorders()
        {
            var mapWidth = _configProvider.GetMapWidth();
            var mapHeight = _configProvider.GetMapHeight();
            var leftOffset = _configProvider.GetGameLeftOffset();
            var topOffset = _configProvider.GetGameTopOffset();

            Console.Clear();

            for (int i = 0; i <= mapWidth; i++) //drawing border horizontally 
            {
                Console.SetCursorPosition(i + leftOffset, topOffset);
                Console.Write("|");
                Console.SetCursorPosition(i + leftOffset, mapHeight + topOffset);
                Console.Write("|");
            }

            for (int i = 0; i <= mapHeight; i++) //drawing border vertically
            {
                Console.SetCursorPosition(leftOffset, i + topOffset);
                Console.Write("|");
                Console.SetCursorPosition(mapWidth + leftOffset, i + topOffset);
                Console.Write("|");
            }
        }

        private void DisplayInstruction()
        {
            const int leftOffset = 0;
            const int topOffset = 2;

            Console.Clear();
            Console.SetCursorPosition(leftOffset, topOffset);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(InstructionsText);
            Console.ReadKey(true);
        }

        private void DisplayExitText()
        {
            const int leftOffset = 0;
            const int topOffset = 2;

            Console.Clear();
            Console.SetCursorPosition(leftOffset, topOffset);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ExitText);
            Console.ReadKey(true);
        }
    }
}

using System;
using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using ConsoleUI.GameControllers;

namespace ConsoleUI
{
    public class Menu
    {
        private IGameController _gameController;
        private readonly IGameControllerCreator _gameControllerCreator;
        private readonly IConfigProvider _configProvider;
        private bool _gameInProgress;
        private const string ConsoleTitle = "CONSOLE SNAKE";
        private const string StartNewGameLabel = "1. Start new game";
        private const string StartNewGameWithAILabel = "2. Start new game AI";
        private const string InstructionLabel = "3. Instructions";
        private const string ExitGameLabel = "4. Exit Game";
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
        
        public Menu(IGameControllerCreator gameControllerCreator, IConfigProvider configProvider)
        {
            _gameControllerCreator = gameControllerCreator;
            _configProvider = configProvider;
        }

        public void DisplayMenu()
        {
            _gameInProgress = true;

            while (_gameInProgress)
            {
                Console.Clear();
                DisplayMenuBorders();
                DisplayMenuOptions();
                ReadPlayerKey();
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
            Console.SetCursorPosition(leftOffset, topOffset + 8);
            Console.WriteLine(StartNewGameWithAILabel);
            Console.SetCursorPosition(leftOffset, topOffset + 9);
            Console.WriteLine(InstructionLabel);
            Console.SetCursorPosition(leftOffset, topOffset + 10);
            Console.WriteLine(ExitGameLabel);
        }

        private void ReadPlayerKey()
        {
            var selectedMenuOption = Console.ReadKey(true);

            switch (selectedMenuOption.Key)
            {
                case ConsoleKey.D1:
                    DisplayMapBorders();
                    _gameController = _gameControllerCreator.StandardGameControllerFactoryMethod();
                    _gameController.NewGame();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    _gameController = _gameControllerCreator.AIGameControllerFactoryMethod();
                    _gameController.NewGame();
                    break;

                case ConsoleKey.D3:
                    DisplayInstruction();
                    break;

                case ConsoleKey.D4:
                    _gameInProgress = false;
                    break;
            }
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

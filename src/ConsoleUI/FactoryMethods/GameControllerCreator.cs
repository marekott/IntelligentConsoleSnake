using ConsoleUI.GameControllers;

namespace ConsoleUI.FactoryMethods
{
    public class GameControllerCreator : IGameControllerCreator
    {
        private readonly IGameCreator _gameCreator;

        public GameControllerCreator(IGameCreator gameCreator)
        {
            _gameCreator = gameCreator;
        }

        public IGameController StandardGameControllerFactoryMethod()
        {
            return new StandardGameController(_gameCreator);
        }

        public IGameController AIGameControllerFactoryMethod()
        {
            return new AIGameController(_gameCreator);
        }
    }
}

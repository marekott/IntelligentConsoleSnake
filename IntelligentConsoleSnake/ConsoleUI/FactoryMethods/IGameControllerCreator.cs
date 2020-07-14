using ConsoleUI.GameControllers;

namespace ConsoleUI.FactoryMethods
{
    public interface IGameControllerCreator
    {
        IGameController StandardGameControllerFactoryMethod();
        IGameController AIGameControllerFactoryMethod();
    }
}
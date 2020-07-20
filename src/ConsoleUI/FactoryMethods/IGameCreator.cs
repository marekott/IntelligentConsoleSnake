using SnakeGame.Interfaces;

namespace ConsoleUI.FactoryMethods
{
    public interface IGameCreator
    {
        IGame StandardGameFactoryMethod();
        IGame AIGameFactoryMethod();
    }
}
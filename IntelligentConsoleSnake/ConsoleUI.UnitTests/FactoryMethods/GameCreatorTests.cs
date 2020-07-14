using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using NUnit.Framework;
using SnakeGame;

namespace ConsoleUI.UnitTests.FactoryMethods
{
    [TestFixture]
    public class GameCreatorTests
    {
        [Test]
        public void StandardGameFactoryMethodTest()
        {
            // arrange
            var gameCreator = new GameCreator(new ConfigProvider(), new Display(new ConfigProvider()));

            // act
            var actual = gameCreator.StandardGameFactoryMethod();

            // assert
            Assert.IsInstanceOf<StandardGame>(actual);
        }
    }
}

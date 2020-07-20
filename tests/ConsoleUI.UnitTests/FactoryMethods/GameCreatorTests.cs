using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using NUnit.Framework;
using SnakeGame;
using SnakeGame.Games;

namespace ConsoleUI.UnitTests.FactoryMethods
{
    [TestFixture]
    public class GameCreatorTests
    {
        [Test]
        public void StandardGameFactoryMethodTest()
        {
            // arrange
            var gameCreator = new GameCreator(new ConfigProvider(), new Display(new ConfigProvider()), new SnakeBot());

            // act
            var actual = gameCreator.StandardGameFactoryMethod();

            // assert
            Assert.IsInstanceOf<StandardGame>(actual);
        }

        [Test]
        public void AIGameFactoryMethodTest()
        {
            // arrange
            var gameCreator = new GameCreator(new ConfigProvider(), new Display(new ConfigProvider()), new SnakeBot());

            // act
            var actual = gameCreator.AIGameFactoryMethod();

            // assert
            Assert.IsInstanceOf<AIGame>(actual);
        }
    }
}

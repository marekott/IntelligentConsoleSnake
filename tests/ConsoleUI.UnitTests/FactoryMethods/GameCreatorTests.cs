using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using Microsoft.Extensions.Configuration;
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
            var gameCreator = new GameCreator(new ConfigProvider(new ConfigurationBuilder().Build()), new Display(new ConfigProvider(new ConfigurationBuilder().Build())), new SnakeBot());

            // act
            var actual = gameCreator.StandardGameFactoryMethod();

            // assert
            Assert.IsInstanceOf<StandardGame>(actual);
        }

        [Test]
        public void AIGameFactoryMethodTest()
        {
            // arrange
            var gameCreator = new GameCreator(new ConfigProvider(new ConfigurationBuilder().Build()), new Display(new ConfigProvider(new ConfigurationBuilder().Build())), new SnakeBot());

            // act
            var actual = gameCreator.AIGameFactoryMethod();

            // assert
            Assert.IsInstanceOf<AIGame>(actual);
        }
    }
}

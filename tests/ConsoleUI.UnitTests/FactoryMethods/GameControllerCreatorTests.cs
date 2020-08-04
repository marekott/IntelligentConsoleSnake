using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using ConsoleUI.GameControllers;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SnakeAI;

namespace ConsoleUI.UnitTests.FactoryMethods
{
    [TestFixture]
    public class GameControllerCreatorTests
    {
        [Test]
        public void StandardGameControllerFactoryMethodTest()
        {
            // arrange
            var gameControllerCreator = new GameControllerCreator(new GameCreator(new ConfigProvider(new ConfigurationBuilder().Build()), new Display(new ConfigProvider(new ConfigurationBuilder().Build())), new SnakeBot(new SnakeAIModel(), new ModelInputHelper())));

            // act
            var actual = gameControllerCreator.StandardGameControllerFactoryMethod();

            // assert
            Assert.IsInstanceOf<StandardGameController>(actual);
        }

        [Test]
        public void AIGameControllerFactoryMethodTest()
        {
            // arrange
            var gameControllerCreator = new GameControllerCreator(new GameCreator(new ConfigProvider(new ConfigurationBuilder().Build()), new Display(new ConfigProvider(new ConfigurationBuilder().Build())), new SnakeBot(new SnakeAIModel(), new ModelInputHelper())));

            // act
            var actual = gameControllerCreator.AIGameControllerFactoryMethod();

            // assert
            Assert.IsInstanceOf<AIGameController>(actual);
        }
    }
}

using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using ConsoleUI.GameControllers;
using NUnit.Framework;

namespace ConsoleUI.UnitTests.FactoryMethods
{
    [TestFixture]
    public class GameControllerCreatorTests
    {
        [Test]
        public void StandardGameControllerFactoryMethodTest()
        {
            // arrange
            var gameControllerCreator = new GameControllerCreator(new GameCreator(new ConfigProvider(), new Display(new ConfigProvider())));

            // act
            var actual = gameControllerCreator.StandardGameControllerFactoryMethod();

            // assert
            Assert.IsInstanceOf<StandardGameController>(actual);
        }

        [Test]
        public void AIGameControllerFactoryMethodTest()
        {
            // arrange
            var gameControllerCreator = new GameControllerCreator(new GameCreator(new ConfigProvider(), new Display(new ConfigProvider())));

            // act
            var actual = gameControllerCreator.AIGameControllerFactoryMethod();

            // assert
            Assert.IsInstanceOf<AIGameController>(actual);
        }
    }
}

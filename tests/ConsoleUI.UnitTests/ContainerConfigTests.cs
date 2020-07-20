using Autofac;
using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using NUnit.Framework;
using SnakeGame.Interfaces;

namespace ConsoleUI.UnitTests
{
    [TestFixture]
    public class ContainerConfigTests
    {
        [Test]
        public void ConfigureRegistersIConfigProviderTest()
        {
            // arrange
            IConfigProvider actual;
            var container = ContainerConfig.Configure();

            // act
            using (var scope = container.BeginLifetimeScope())
            {
                actual = scope.Resolve<IConfigProvider>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureRegistersIGameCreatorTest()
        {
            // arrange
            IGameCreator actual;
            var container = ContainerConfig.Configure();

            // act
            using (var scope = container.BeginLifetimeScope())
            {
                actual = scope.Resolve<IGameCreator>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureRegistersIDisplayTest()
        {
            // arrange
            IDisplay actual;
            var container = ContainerConfig.Configure();

            // act
            using (var scope = container.BeginLifetimeScope())
            {
                actual = scope.Resolve<IDisplay>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureRegistersIGameControllerCreatorTest()
        {
            // arrange
            IGameControllerCreator actual;
            var container = ContainerConfig.Configure();

            // act
            using (var scope = container.BeginLifetimeScope())
            {
                actual = scope.Resolve<IGameControllerCreator>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureRegistersISnakeBotTest()
        {
            // arrange
            ISnakeBot actual;
            var container = ContainerConfig.Configure();

            // act
            using (var scope = container.BeginLifetimeScope())
            {
                actual = scope.Resolve<ISnakeBot>();
            }

            // assert
            Assert.IsNotNull(actual);
        }
    }
}

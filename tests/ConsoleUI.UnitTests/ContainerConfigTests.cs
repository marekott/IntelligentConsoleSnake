using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SnakeAI;
using SnakeGame.Interfaces;

namespace ConsoleUI.UnitTests
{
    [TestFixture]
    public class ContainerConfigTests
    {
        [Test]
        public void ConfigureServiceProviderRegistersIConfigurationTest()
        {
            // arrange
            IConfiguration actual;

            // act
            using (var serviceProvider = ContainerConfig.ConfigureServiceProvider())
            {
                actual = serviceProvider.GetService<IConfiguration>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureServiceProviderRegistersIConfigProviderTest()
        {
            // arrange
            IConfigProvider actual;

            // act
            using (var serviceProvider = ContainerConfig.ConfigureServiceProvider())
            {
                actual = serviceProvider.GetService<IConfigProvider>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureServiceProviderRegistersIGameCreatorTest()
        {
            // arrange
            IGameCreator actual;

            // act
            using (var serviceProvider = ContainerConfig.ConfigureServiceProvider())
            {
                actual = serviceProvider.GetService<IGameCreator>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureServiceProviderRegistersIDisplayTest()
        {
            // arrange
            IDisplay actual;

            // act
            using (var serviceProvider = ContainerConfig.ConfigureServiceProvider())
            {
                actual = serviceProvider.GetService<IDisplay>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureServiceProviderRegistersIGameControllerCreatorTest()
        {
            // arrange
            IGameControllerCreator actual;

            // act
            using (var serviceProvider = ContainerConfig.ConfigureServiceProvider())
            {
                actual = serviceProvider.GetService<IGameControllerCreator>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureServiceProviderRegistersISnakeBotTest()
        {
            // arrange
            ISnakeBot actual;

            // act
            using (var serviceProvider = ContainerConfig.ConfigureServiceProvider())
            {
                actual = serviceProvider.GetService<ISnakeBot>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureServiceProviderRegistersMenuTest()
        {
            // arrange
            Menu actual;

            // act
            using (var serviceProvider = ContainerConfig.ConfigureServiceProvider())
            {
                actual = serviceProvider.GetService<Menu>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureServiceProviderRegistersSnakeAIModelTest()
        {
            // arrange
            SnakeAIModel actual;

            // act
            using (var serviceProvider = ContainerConfig.ConfigureServiceProvider())
            {
                actual = serviceProvider.GetService<SnakeAIModel>();
            }

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ConfigureServiceProviderRegistersModelInputHelperTest()
        {
            // arrange
            ModelInputHelper actual;

            // act
            using (var serviceProvider = ContainerConfig.ConfigureServiceProvider())
            {
                actual = serviceProvider.GetService<ModelInputHelper>();
            }

            // assert
            Assert.IsNotNull(actual);
        }
    }
}

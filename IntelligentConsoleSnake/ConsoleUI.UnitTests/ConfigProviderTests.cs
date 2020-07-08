using NUnit.Framework;

namespace ConsoleUI.UnitTests
{
    [TestFixture]
    public class ConfigProviderTests
    {
        [Test]
        public void GetMapHeightTest()
        {
            // arrange
            const int expected = 20;
            var configProvider = new ConfigProvider();

            // act
            var actual = configProvider.GetMapHeight();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMapWidthTest()
        {
            // arrange
            const int expected = 50;
            var configProvider = new ConfigProvider();

            // act
            var actual = configProvider.GetMapWidth();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetGameLeftOffsetTest()
        {
            // arrange
            const int expected = 10;
            var configProvider = new ConfigProvider();

            // act
            var actual = configProvider.GetGameLeftOffset();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetGameTopOffsetTest()
        {
            // arrange
            const int expected = 4;
            var configProvider = new ConfigProvider();

            // act
            var actual = configProvider.GetGameTopOffset();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

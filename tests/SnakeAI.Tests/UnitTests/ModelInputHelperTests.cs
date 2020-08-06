using System.Collections.Generic;
using NUnit.Framework;
using SnakeAI.Tests.Stub;
using SnakeGame;

namespace SnakeAI.Tests.UnitTests
{
    [TestFixture]
    public class ModelInputHelperTests
    {
        [Test]
        public void ObstacleUpReturnsTrueTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(1, 1, 0)
            };
            var snake = new Snake(snakeBody, new Display());
            var map = new Map(10, 10);
            var modelInputHelper = new ModelInputHelper();

            // act
            var actual = modelInputHelper.ObstacleUp(snake, map);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ObstacleUpReturnsFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(1, 2, 0)
            };
            var snake = new Snake(snakeBody, new Display());
            var map = new Map(10, 10);
            var modelInputHelper = new ModelInputHelper();

            // act
            var actual = modelInputHelper.ObstacleUp(snake, map);

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ObstacleRightReturnsTrueTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(9, 1, 0)
            };
            var snake = new Snake(snakeBody, new Display());
            var map = new Map(10, 10);
            var modelInputHelper = new ModelInputHelper();

            // act
            var actual = modelInputHelper.ObstacleRight(snake, map);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ObstacleRightReturnsFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(8, 1, 0)
            };
            var snake = new Snake(snakeBody, new Display());
            var map = new Map(10, 10);
            var modelInputHelper = new ModelInputHelper();

            // act
            var actual = modelInputHelper.ObstacleRight(snake, map);

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ObstacleDownReturnsTrueTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(9, 9, 0)
            };
            var snake = new Snake(snakeBody, new Display());
            var map = new Map(10, 10);
            var modelInputHelper = new ModelInputHelper();

            // act
            var actual = modelInputHelper.ObstacleDown(snake, map);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ObstacleDownReturnsFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(9, 8, 0)
            };
            var snake = new Snake(snakeBody, new Display());
            var map = new Map(10, 10);
            var modelInputHelper = new ModelInputHelper();

            // act
            var actual = modelInputHelper.ObstacleDown(snake, map);

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ObstacleLeftReturnsTrueTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(1, 9, 0)
            };
            var snake = new Snake(snakeBody, new Display());
            var map = new Map(10, 10);
            var modelInputHelper = new ModelInputHelper();

            // act
            var actual = modelInputHelper.ObstacleLeft(snake, map);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ObstacleLeftReturnsFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(2, 9, 0)
            };
            var snake = new Snake(snakeBody, new Display());
            var map = new Map(10, 10);
            var modelInputHelper = new ModelInputHelper();

            // act
            var actual = modelInputHelper.ObstacleLeft(snake, map);

            // assert
            Assert.False(actual);
        }
    }
}

using System.Collections.Generic;
using NUnit.Framework;
using SnakeGame.UnitTests.Stub;

namespace SnakeGame.UnitTests
{
    [TestFixture]
    public class IntelligentSnakeTests
    {
        [Test]
        public void ObstacleUpReturnsTrueTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3,2 ,0),
                new SnakeElement(3,1 ,0),
            };
            var snake = new IntelligentSnake(snakeBody, new Display());

            // act
            var actual = snake.ObstacleUp();

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ObstacleUpReturnsFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3,2 ,0),
                new SnakeElement(3,3 ,0),
            };
            var snake = new IntelligentSnake(snakeBody, new Display());

            // act
            var actual = snake.ObstacleUp();

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ObstacleRightReturnsTrueTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3,2 ,0),
                new SnakeElement(4,2 ,0),
            };
            var snake = new IntelligentSnake(snakeBody, new Display());

            // act
            var actual = snake.ObstacleRight();

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ObstacleRightReturnsFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3,2 ,0),
                new SnakeElement(2,2 ,0),
            };
            var snake = new IntelligentSnake(snakeBody, new Display());

            // act
            var actual = snake.ObstacleRight();

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ObstacleDownReturnsTrueTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3,2 ,0),
                new SnakeElement(3,3 ,0),
            };
            var snake = new IntelligentSnake(snakeBody, new Display());

            // act
            var actual = snake.ObstacleDown();

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ObstacleDownReturnsFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3,2 ,0),
                new SnakeElement(3,1 ,0),
            };
            var snake = new IntelligentSnake(snakeBody, new Display());

            // act
            var actual = snake.ObstacleDown();

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ObstacleLeftReturnsTrueTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3,3 ,0),
                new SnakeElement(2,3 ,0),
            };
            var snake = new IntelligentSnake(snakeBody, new Display());

            // act
            var actual = snake.ObstacleLeft();

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ObstacleLeftReturnsFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3,3 ,0),
                new SnakeElement(4,3 ,0),
            };
            var snake = new IntelligentSnake(snakeBody, new Display());

            // act
            var actual = snake.ObstacleLeft();

            // assert
            Assert.False(actual);
        }
    }
}

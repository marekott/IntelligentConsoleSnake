using System.Collections.Generic;
using NUnit.Framework;
using SnakeGame.UnitTests.Stub;

namespace SnakeGame.UnitTests
{
    [TestFixture]
    public class SnakeTests
    {
        [Test]
        public void MoveSnakeDoesNotThrowsArgumentOutOfRangeExceptionWhenSnakeLengthIsOneTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(1, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            // assert
            Assert.DoesNotThrow(() => snake.MoveSnake());
        }

        [Test]
        public void MoveSnakeDoesNotThrowsArgumentOutOfRangeExceptionWhenSnakeLengthIsTwoTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(2, 1, DirectionOfMove.Right), 
                new SnakeElement(1, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            // assert
            Assert.DoesNotThrow(() => snake.MoveSnake());
        }

        [Test]
        public void MoveSnakeDoesNotThrowsArgumentOutOfRangeExceptionWhenSnakeLengthIsThreeTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3, 1, DirectionOfMove.Right),
                new SnakeElement(2, 1, DirectionOfMove.Right),
                new SnakeElement(1, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            // assert
            Assert.DoesNotThrow(() => snake.MoveSnake());
        }

        [Test]
        public void GrowSnakeDoesNotThrowsArgumentOutOfRangeExceptionTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3, 1, DirectionOfMove.Right),
                new SnakeElement(2, 1, DirectionOfMove.Right),
                new SnakeElement(1, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            // assert
            Assert.DoesNotThrow(() => snake.GrowSnake());
        }

        [Test]
        public void HasSnakeEatenHimselfDoesNotThrowsArgumentOutOfRangeExceptionTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3, 1, DirectionOfMove.Right),
                new SnakeElement(2, 1, DirectionOfMove.Right),
                new SnakeElement(1, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            // assert
            Assert.DoesNotThrow(() => snake.HasSnakeEatenHimself());
        }

        [Test]
        public void HasSnakeEatenHimselfReturnsFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3, 1, DirectionOfMove.Right),
                new SnakeElement(2, 1, DirectionOfMove.Right),
                new SnakeElement(1, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            var actual = snake.HasSnakeEatenHimself();

            // assert
            Assert.False(actual);
        }

        [Test]
        public void HasSnakeEatenHimselfReturnsTrueWhenHeadEatsElementBeforeIfTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3, 1, DirectionOfMove.Right),
                new SnakeElement(3, 1, DirectionOfMove.Right),
                new SnakeElement(2, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            var actual = snake.HasSnakeEatenHimself();

            // assert
            Assert.True(actual);
        }

        [Test]
        public void HasSnakeEatenHimselfReturnsTrueWhenHeadEatsLastElementTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3, 1, DirectionOfMove.Right),
                new SnakeElement(2, 1, DirectionOfMove.Right),
                new SnakeElement(3, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            var actual = snake.HasSnakeEatenHimself();

            // assert
            Assert.True(actual);
        }

        [Test]
        public void GetSnakeTopPositionsWithoutDuplicatesTest()
        {
            // arrange
            var expected = new HashSet<int> {2, 3, 4, 5};
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3, 2, DirectionOfMove.Right),
                new SnakeElement(3, 3, DirectionOfMove.Right),
                new SnakeElement(3, 4, DirectionOfMove.Right),
                new SnakeElement(3, 5, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            var actual = snake.GetSnakeTopPositions();

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSnakeTopPositionsWithDuplicatesTest()
        {
            // arrange
            var expected = new HashSet<int> { 5 };
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(2, 5, DirectionOfMove.Right),
                new SnakeElement(3, 5, DirectionOfMove.Right),
                new SnakeElement(4, 5, DirectionOfMove.Right),
                new SnakeElement(5, 5, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            var actual = snake.GetSnakeTopPositions();

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSnakeLeftPositionsWithoutDuplicatesTest()
        {
            // arrange
            var expected = new HashSet<int> { 2, 3, 4, 5 };
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(2, 5, DirectionOfMove.Right),
                new SnakeElement(3, 5, DirectionOfMove.Right),
                new SnakeElement(4, 5, DirectionOfMove.Right),
                new SnakeElement(5, 5, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            var actual = snake.GetSnakeLeftPositions();

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSnakeLeftPositionsWithDuplicatesTest()
        {
            // arrange
            var expected = new HashSet<int> { 3 };
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3, 2, DirectionOfMove.Right),
                new SnakeElement(3, 3, DirectionOfMove.Right),
                new SnakeElement(3, 4, DirectionOfMove.Right),
                new SnakeElement(3, 5, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);

            // act
            var actual = snake.GetSnakeLeftPositions();

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

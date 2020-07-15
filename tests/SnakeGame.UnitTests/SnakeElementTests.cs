using System;
using NUnit.Framework;

namespace SnakeGame.UnitTests
{
    [TestFixture]
    public class SnakeElementTests
    {
        [Test]
        public void ConstructorInvalidDirectionOfMoveTest()
        {
            // ReSharper disable once ObjectCreationAsStatement
            // arrange
            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SnakeElement(1, 1, (DirectionOfMove)100));
        }

        [Test]
        public void MoveRightTest()
        {
            // arrange
            const int expected = 1;
            var snakeElement = new SnakeElement(0, 0, DirectionOfMove.Right);

            // act
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DistanceFromLeft);
        }

        [Test]
        public void MoveUpTest()
        {
            // arrange
            const int expected = 0;
            var snakeElement = new SnakeElement(0, 1, DirectionOfMove.Up);

            // act
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DistanceFromTop);
        }

        [Test]
        public void MoveLeftTest()
        {
            // arrange
            const int expected = 0;
            var snakeElement = new SnakeElement(1, 1, DirectionOfMove.Left);

            // act
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DistanceFromLeft);
        }

        [Test]
        public void MoveDownTest()
        {
            // arrange
            const int expected = 1;
            var snakeElement = new SnakeElement(1, 0, DirectionOfMove.Down);

            // act
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DistanceFromTop);
        }

        [Test]
        public void ChangeDirectionToRightValidConditionsTest()
        {
            // arrange
            const DirectionOfMove expected = DirectionOfMove.Right;
            var snakeElement = new SnakeElement(0, 0, DirectionOfMove.Up);

            // act
            snakeElement.ChangeDirection(expected);
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DirectionOfMove);
        }

        [Test]
        public void ChangeDirectionToUpValidConditionsTest()
        {
            // arrange
            const DirectionOfMove expected = DirectionOfMove.Up;
            var snakeElement = new SnakeElement(1, 1, DirectionOfMove.Right);

            // act
            snakeElement.ChangeDirection(expected);
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DirectionOfMove);
        }

        [Test]
        public void ChangeDirectionToLeftValidConditionsTest()
        {
            // arrange
            const DirectionOfMove expected = DirectionOfMove.Left;
            var snakeElement = new SnakeElement(1, 1, DirectionOfMove.Down);

            // act
            snakeElement.ChangeDirection(expected);
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DirectionOfMove);
        }

        [Test]
        public void ChangeDirectionToDownValidConditionsTest()
        {
            // arrange
            const DirectionOfMove expected = DirectionOfMove.Down;
            var snakeElement = new SnakeElement(0, 0, DirectionOfMove.Left);

            // act
            snakeElement.ChangeDirection(expected);
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DirectionOfMove);
        }

        [Test]
        public void ChangeDirectionToRightWhenCurrentIsLeftTest()
        {
            // arrange
            const DirectionOfMove expected = DirectionOfMove.Left;
            var snakeElement = new SnakeElement(1, 1, DirectionOfMove.Left);

            // act
            snakeElement.ChangeDirection(DirectionOfMove.Right);
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DirectionOfMove);
        }

        [Test]
        public void ChangeDirectionToUpWhenCurrentIsDownTest()
        {
            // arrange
            const DirectionOfMove expected = DirectionOfMove.Down;
            var snakeElement = new SnakeElement(1, 1, DirectionOfMove.Down);

            // act
            snakeElement.ChangeDirection(DirectionOfMove.Up);
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DirectionOfMove);
        }

        [Test]
        public void ChangeDirectionToLeftWhenCurrentIsRightTest()
        {
            // arrange
            const DirectionOfMove expected = DirectionOfMove.Right;
            var snakeElement = new SnakeElement(1, 1, DirectionOfMove.Right);

            // act
            snakeElement.ChangeDirection(DirectionOfMove.Left);
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DirectionOfMove);
        }

        [Test]
        public void ChangeDirectionToDownWhenCurrentIsUpTest()
        {
            // arrange
            const DirectionOfMove expected = DirectionOfMove.Up;
            var snakeElement = new SnakeElement(1, 1, DirectionOfMove.Up);

            // act
            snakeElement.ChangeDirection(DirectionOfMove.Down);
            snakeElement.Move();

            // assert
            Assert.AreEqual(expected, snakeElement.DirectionOfMove);
        }

        [Test]
        public void ChangeDirectionThrowsArgumentOutOfRangeExceptionWhenInvalidEnumValueTest()
        {
            // arrange
            var snakeElement = new SnakeElement(1, 1, DirectionOfMove.Up);

            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => snakeElement.ChangeDirection((DirectionOfMove) 100));
        }

        [Test]
        public void CreateSnakeElementBehindDirectionIsRightTest()
        {
            // arrange
            const DirectionOfMove expectedDirection = DirectionOfMove.Right;
            const int expectedDistanceFromLeft = 1;
            const int expectedDistanceFromTop = 1;
            var snakeElement = new SnakeElement(expectedDistanceFromLeft + 1, expectedDistanceFromTop, expectedDirection);

            // act
            var newSnakeElement = snakeElement.CreateSnakeElementBehind();

            // assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDistanceFromLeft, newSnakeElement.DistanceFromLeft);
                Assert.AreEqual(expectedDistanceFromTop, newSnakeElement.DistanceFromTop);
                Assert.AreEqual(expectedDirection, newSnakeElement.DirectionOfMove);
            });
        }

        [Test]
        public void CreateSnakeElementBehindDirectionIsUpTest()
        {
            // arrange
            const DirectionOfMove expectedDirection = DirectionOfMove.Up;
            const int expectedDistanceFromLeft = 1;
            const int expectedDistanceFromTop = 2;
            var snakeElement = new SnakeElement(expectedDistanceFromLeft, expectedDistanceFromTop - 1, expectedDirection);

            // act
            var newSnakeElement = snakeElement.CreateSnakeElementBehind();

            // assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDistanceFromLeft, newSnakeElement.DistanceFromLeft);
                Assert.AreEqual(expectedDistanceFromTop, newSnakeElement.DistanceFromTop);
                Assert.AreEqual(expectedDirection, newSnakeElement.DirectionOfMove);
            });
        }

        [Test]
        public void CreateSnakeElementBehindDirectionIsLeftTest()
        {
            // arrange
            const DirectionOfMove expectedDirection = DirectionOfMove.Left;
            const int expectedDistanceFromLeft = 2;
            const int expectedDistanceFromTop = 1;
            var snakeElement = new SnakeElement(expectedDistanceFromLeft - 1, expectedDistanceFromTop, expectedDirection);

            // act
            var newSnakeElement = snakeElement.CreateSnakeElementBehind();

            // assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDistanceFromLeft, newSnakeElement.DistanceFromLeft);
                Assert.AreEqual(expectedDistanceFromTop, newSnakeElement.DistanceFromTop);
                Assert.AreEqual(expectedDirection, newSnakeElement.DirectionOfMove);
            });
        }

        [Test]
        public void CreateSnakeElementBehindDirectionIsDownTest()
        {
            // arrange
            const DirectionOfMove expectedDirection = DirectionOfMove.Down;
            const int expectedDistanceFromLeft = 1;
            const int expectedDistanceFromTop = 1;
            var snakeElement = new SnakeElement(expectedDistanceFromLeft, expectedDistanceFromTop + 1, expectedDirection);

            // act
            var newSnakeElement = snakeElement.CreateSnakeElementBehind();

            // assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDistanceFromLeft, newSnakeElement.DistanceFromLeft);
                Assert.AreEqual(expectedDistanceFromTop, newSnakeElement.DistanceFromTop);
                Assert.AreEqual(expectedDirection, newSnakeElement.DirectionOfMove);
            });
        }
    }
}

using System.Collections.Generic;
using NUnit.Framework;
using SnakeGame.UnitTests.Stub;

namespace SnakeGame.UnitTests
{
    [TestFixture]
    public class GameRulesTests
    {
        [Test]
        public void IsGameOverTrueBecauseSnakeEatenHimselfTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(3, 1, DirectionOfMove.Right),
                new SnakeElement(3, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);
            var gameRules = new GameRules();
            var map = new Map(100,100);

            // act
            var actual = gameRules.IsGameOver(snake, map);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void IsGameOverTrueBecauseHeadCrashedLeftBorderTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(0, 1, DirectionOfMove.Right),
                new SnakeElement(1, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);
            var gameRules = new GameRules();
            var map = new Map(100, 100);

            // act
            var actual = gameRules.IsGameOver(snake, map);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void IsGameOverTrueBecauseHeadCrashedTopBorderTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(1, 0, DirectionOfMove.Right),
                new SnakeElement(1, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);
            var gameRules = new GameRules();
            var map = new Map(100, 100);

            // act
            var actual = gameRules.IsGameOver(snake, map);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void IsGameOverTrueBecauseHeadCrashedRightBorderTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(100, 1, DirectionOfMove.Right),
                new SnakeElement(99, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);
            var gameRules = new GameRules();
            var map = new Map(100, 100);

            // act
            var actual = gameRules.IsGameOver(snake, map);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void IsGameOverTrueBecauseHeadCrashedBottomBorderTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(1, 100, DirectionOfMove.Right),
                new SnakeElement(1, 99, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);
            var gameRules = new GameRules();
            var map = new Map(100, 100);

            // act
            var actual = gameRules.IsGameOver(snake, map);

            // assert
            Assert.True(actual);
        }
    }
}

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

        [Test]
        public void IsGameOverTrueBecauseGameWasCancelledTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(2, 1, DirectionOfMove.Right),
                new SnakeElement(1, 1, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);
            var gameRules = new GameRules();
            var map = new Map(100, 100);

            // act
            gameRules.CancelGame();
            var actual = gameRules.IsGameOver(snake, map);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void IsRewardCollectedTrueTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(0, 0, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);
            var reward = new Reward(displayStub);
            var gameRules = new GameRules();

            // act
            var actual = gameRules.IsRewardCollected(snake, reward);

            // assert
            Assert.True(actual); //True because initial position values of reward are 0 and 0
        }

        [Test]
        public void IsRewardCollectedFalseTest()
        {
            // arrange
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(0, 0, DirectionOfMove.Right)
            };
            var displayStub = new Display();
            var snake = new Snake(snakeBody, displayStub);
            var map = new Map(10, 10);
            var reward = new Reward(displayStub);
            reward.GenerateRandom(map, new HashSet<int>{100}, new HashSet<int>{100});
            var gameRules = new GameRules();

            // act
            var actual = gameRules.IsRewardCollected(snake, reward);

            // assert
            Assert.False(actual); //False because after GenerateRandom() position values of reward can't be 0 and 0
        }
    }
}

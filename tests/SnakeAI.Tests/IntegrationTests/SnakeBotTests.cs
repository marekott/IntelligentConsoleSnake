using System.Collections.Generic;
using NUnit.Framework;
using SnakeAI.Tests.Stub;
using SnakeGame;

namespace SnakeAI.Tests.IntegrationTests
{
    [TestFixture]
    public class SnakeBotTests
    {
        [Test]
        public void WhenObstacleRightAIDoesNotChooseToMoveRightTest()
        {
            // arrange
            var map = new Map(10, 10);
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(map.Width-1,2, DirectionOfMove.Right)
            };
            var snake = new IntelligentSnake(snakeBody, new Display());
            var snakeBot = new SnakeBot(new SnakeAIModel(), new ModelInputHelper());

            // act
            var actual = snakeBot.ChooseDirection(snake, new Reward(new Display()), map);

            // assert
            Assert.AreNotEqual(actual, DirectionOfMove.Right);
        }

        [Test]
        public void WhenObstacleUpAIDoesNotChooseToMoveUpTest()
        {
            // arrange
            var map = new Map(10, 10);
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(5,1, DirectionOfMove.Right)
            };
            var snake = new IntelligentSnake(snakeBody, new Display());
            var snakeBot = new SnakeBot(new SnakeAIModel(), new ModelInputHelper());

            // act
            var actual = snakeBot.ChooseDirection(snake, new Reward(new Display()), map);

            // assert
            Assert.AreNotEqual(actual, DirectionOfMove.Up);
        }

        [Test]
        public void WhenObstacleLeftAIDoesNotChooseToMoveLeftTest()
        {
            // arrange
            var map = new Map(10, 10);
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(1,5, DirectionOfMove.Right)
            };
            var snake = new IntelligentSnake(snakeBody, new Display());
            var snakeBot = new SnakeBot(new SnakeAIModel(), new ModelInputHelper());

            // act
            var actual = snakeBot.ChooseDirection(snake, new Reward(new Display()), map);

            // assert
            Assert.AreNotEqual(actual, DirectionOfMove.Left);
        }

        [Test]
        public void WhenObstacleDownAIDoesNotChooseToMoveDownTest()
        {
            // arrange
            var map = new Map(10, 10);
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(2,map.Height-1, DirectionOfMove.Right)
            };
            var snake = new IntelligentSnake(snakeBody, new Display());
            var snakeBot = new SnakeBot(new SnakeAIModel(), new ModelInputHelper());

            // act
            var actual = snakeBot.ChooseDirection(snake, new Reward(new Display()), map);

            // assert
            Assert.AreNotEqual(actual, DirectionOfMove.Down);
        }

        [Test]
        public void WhenObstacleRightAndUpAIDoesNotChooseToMoveRightOrUpTest()
        {
            // arrange
            var map = new Map(10, 10);
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(map.Width-1,1, DirectionOfMove.Right)
            };
            var snake = new IntelligentSnake(snakeBody, new Display());
            var snakeBot = new SnakeBot(new SnakeAIModel(), new ModelInputHelper());

            // act
            var actual = snakeBot.ChooseDirection(snake, new Reward(new Display()), map);

            // assert
            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(actual, DirectionOfMove.Right);
                Assert.AreNotEqual(actual, DirectionOfMove.Up);
            });
        }

        [Test]
        public void WhenObstacleRightAndDownAIDoesNotChooseToMoveRightOrDownTest()
        {
            // arrange
            var map = new Map(10, 10);
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(map.Width-1,map.Height-1, DirectionOfMove.Right)
            };
            var snake = new IntelligentSnake(snakeBody, new Display());
            var snakeBot = new SnakeBot(new SnakeAIModel(), new ModelInputHelper());

            // act
            var actual = snakeBot.ChooseDirection(snake, new Reward(new Display()), map);

            // assert
            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(actual, DirectionOfMove.Right);
                Assert.AreNotEqual(actual, DirectionOfMove.Down);
            });
        }

        [Test]
        public void WhenObstacleLeftAndUpAIDoesNotChooseToMoveLeftOrUpTest()
        {
            // arrange
            var map = new Map(10, 10);
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(1,1, DirectionOfMove.Left)
            };
            var snake = new IntelligentSnake(snakeBody, new Display());
            var snakeBot = new SnakeBot(new SnakeAIModel(), new ModelInputHelper());

            // act
            var actual = snakeBot.ChooseDirection(snake, new Reward(new Display()), map);

            // assert
            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(actual, DirectionOfMove.Left);
                Assert.AreNotEqual(actual, DirectionOfMove.Up);
            });
        }

        [Test]
        public void WhenObstacleLeftAndDownAIDoesNotChooseToMoveLeftOrDownTest()
        {
            // arrange
            var map = new Map(10, 10);
            var snakeBody = new List<SnakeElement>
            {
                new SnakeElement(1,map.Height-1, DirectionOfMove.Right)
            };
            var snake = new IntelligentSnake(snakeBody, new Display());
            var snakeBot = new SnakeBot(new SnakeAIModel(), new ModelInputHelper());

            // act
            var actual = snakeBot.ChooseDirection(snake, new Reward(new Display()), map);

            // assert
            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(actual, DirectionOfMove.Left);
                Assert.AreNotEqual(actual, DirectionOfMove.Down);
            });
        }
    }
}

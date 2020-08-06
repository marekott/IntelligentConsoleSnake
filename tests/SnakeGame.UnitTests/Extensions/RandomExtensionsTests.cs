using System;
using System.Collections.Generic;
using NUnit.Framework;
using SnakeGame.Extensions;

namespace SnakeGame.UnitTests.Extensions
{
    [TestFixture]
    public class RandomExtensionsTests
    {
        [Test]
        [Repeat(100)]
        public void NextTest()
        {
            // arrange
            var random = new Random();
            var exclude = new HashSet<int>{1, 3, 5, 7, 9};

            // act
            var actual = random.Next(1, 11, exclude);

            // assert
            Assert.True(actual % 2 == 0, $"Returned value: {actual}"); //we are excluding odd numbers so result must be even
        }
    }
}

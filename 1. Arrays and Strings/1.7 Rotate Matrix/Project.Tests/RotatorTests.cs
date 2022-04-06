using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class RotatorTests
    {
        [Test]
        public void ShouldRotateCorrectlyWhenEvenNxN()
        {
            //Arrange
            int[][] image =
            {
                new int[]{ 1, 2, 3, 4 },
                new int[]{ 5, 6, 7, 8 },
                new int[]{ 9, 10, 11, 12 },
                new int[]{ 13, 14, 15, 16 },
            };

            IRotator rotator = new Rotator(image);


            //Act
            var result = rotator.Rotate90Degrees();

            //Assert
            int[][] expectedImage =
            {
                new int[]{ 13, 9, 5, 1 },
                new int[]{ 14, 10, 6, 2},
                new int[]{ 15, 11, 7, 3 },
                new int[]{ 16, 12, 8, 4},
            };

            result.Should().BeEquivalentTo(expectedImage);
        }

        [Test]
        public void ShouldRotateCorrectlyWhenOddNxN()
        {
            //Arrange
            int[][] image =
            {
                new int[]{ 1, 2, 3 },
                new int[]{ 4, 5, 6 },
                new int[]{ 7, 8, 9 },
            };
            IRotator rotator = new Rotator(image);


            //Act
            var result = rotator.Rotate90Degrees();

            //Assert
            int[][] expectedImage =
            {
                new int[]{ 7, 4, 1},
                new int[]{ 8, 5, 2},
                new int[]{ 9, 6, 3 },
            };

            result.Should().BeEquivalentTo(expectedImage);
        }

        [Test]
        [TestCase(null)]
        public void ShouldThrowExceptionIfArrayIsNullOrEmpty(dynamic emptyArray)
        {
            FluentActions.Invoking(() => new Rotator(emptyArray))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

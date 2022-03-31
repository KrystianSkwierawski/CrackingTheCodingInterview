using NUnit.Framework;
using FluentAssertions;
using System;

namespace Project.Tests
{
    public class MatrixTester
    {
        [Test]
        public void ShouldSetZeros()
        {
            //Arrange
            IMatrix matrix = new Matrix();
            int[][] image =
            {
                new int[]{ 1, 0, 3, 4 },
                new int[]{ 5, 6, 7, 8 },
                new int[]{ 9, 10, 11, 12 },
                new int[]{ 13, 14, 15, 0 },
                new int[]{ 17, 18, 19, 20 }
            };


            //Act
            var result = matrix.SetZeros(image);

            //Assert
            int[][] expectedResult =
            {
                new int[]{ 0, 0, 0, 0 },
                new int[]{ 5, 0, 7, 0 },
                new int[]{ 9, 0, 11, 0 },
                new int[]{ 0, 0, 0, 0 },
                new int[]{ 17, 0, 19, 0 }
            };

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void ShouldReturnSameArrayWhenDoesNotContainsZeros()
        {
            //Arrange
            IMatrix matrix = new Matrix();
            int[][] image =
            {
                new int[]{ 1, 2, 3, 4 },
                new int[]{ 5, 6, 7, 8 },
                new int[]{ 9, 10, 11, 12 },
                new int[]{ 13, 14, 15, 6 },
                new int[]{ 17, 18, 19, 20 }
            };


            //Act
            var result = matrix.SetZeros(image);

            //Assert
            result.Should().BeEquivalentTo(image);
        }

        [Test]
        [TestCase(null)]
        public void ShouldThrowExceptionIfTextIsNullOrEmpty(dynamic emptyArray)
        {
            IMatrix matrix = new Matrix();

            FluentActions.Invoking(() => matrix.SetZeros(emptyArray))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

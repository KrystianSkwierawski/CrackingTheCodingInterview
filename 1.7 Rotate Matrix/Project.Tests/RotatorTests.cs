using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class RotatorTests
    {
        [Test]
        public void ShouldRotate90Degrees()
        {
            //Arrange
            IRotator rotator = new Rotator();

            Array[] image =
            {
                new int[]{1,2,3,4},
                new int[]{2,3,4,5},
                new int[]{3,4,5,6},
                new int[]{7,8,9,10},
            };

            //Act
            var result = rotator.Rotate90Degrees(image);

            //Assert
            Array[] expectedImage =
            {
                new int[]{7,8,9,10},
                new int[]{1,2,3,4},
                new int[]{2,3,4,5},
                new int[]{3,4,5,6},
            };

            result.Should().BeEquivalentTo(expectedImage);
        }


        [Test]
        [TestCase(null)]
        public void ShouldThrowExceptionIfArrayIsNullOrEmpty(dynamic emptyArray)
        {
            IRotator rotator = new Rotator();

            FluentActions.Invoking(() => rotator.Rotate90Degrees(emptyArray))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

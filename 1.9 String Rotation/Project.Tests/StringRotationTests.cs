using NUnit.Framework;
using FluentAssertions;
using System;

namespace Project.Tests
{
    public class StringRotationTests
    {
        [Test]
        [TestCase("waterbottle", "erbottlewat", true)]
        [TestCase("erbottlewat", "waterbottle", true)]
        [TestCase("waterbottle", "erbottlewa", false)]
        [TestCase("waterbottle", "erbottlewta", false)]
        public void SholdCheckIfStringRotation(string s1, string s2, bool expectedResult)
        {
            //Arrange
            IStringRotation stringRotation = new StringRotation();

            //Act
            var result = stringRotation.IsRotation(s1, s2);

            //Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowExceptionIfTextIsNullOrEmpty(dynamic emptyText)
        {
            IStringRotation stringRotation = new StringRotation();

            FluentActions.Invoking(() => stringRotation.IsRotation(emptyText, emptyText))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

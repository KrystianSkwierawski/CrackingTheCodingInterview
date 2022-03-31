using NUnit.Framework;
using FluentAssertions;
using System;

namespace Project.Tests
{
    public class URLifyTests
    {
        [Test]
        [TestCase("Mr John Smith   ", "Mr%20John%20Smith", 13)]
        public void ShouldConvertToURL(string text, string expectedResult, int trueLength)
        {
            //Arrange
            IURLify uRLify = new URLify();

            //Act
            var result = uRLify.ToURL(text, trueLength);

            //Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowExceptionIfTextIsNullOrEmpty(dynamic emptyText)
        {
            IURLify uRLify = new URLify();

            FluentActions.Invoking(() => uRLify.ToURL(emptyText, 0))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

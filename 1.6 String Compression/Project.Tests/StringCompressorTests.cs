using NUnit.Framework;
using FluentAssertions;
using System;

namespace Project.Tests
{
    public class StringCompressorTests
    {
        [Test]
        [TestCase("aabcccccaaa", "a2b1c5a3")]
        [TestCase("a", "a")]
        [TestCase("AB", "AB")]
        public void ShouldCompresText(string text, string expectedResult)
        {
            //Arrange
            IStringCompressor compressor = new StringCompressor();

            //Act
            var result = compressor.Compress(text);

            //Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowExceptionIfTextIsNullOrEmpty(dynamic emptyText)
        {
            IStringCompressor compressor = new StringCompressor();

            FluentActions.Invoking(() => compressor.Compress(emptyText))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

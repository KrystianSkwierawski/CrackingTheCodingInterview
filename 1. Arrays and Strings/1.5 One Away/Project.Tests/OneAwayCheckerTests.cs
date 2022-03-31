using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class OneAwayCheckerTests
    {
        [Test]
        [TestCase("pale", "ple", true)]
        [TestCase("ple", "pale", true)]
        [TestCase("pales", "pale", true)]
        [TestCase("pale", "pales", true)]
        [TestCase("pale", "bale", true)]
        [TestCase("bale", "pale", true)]
        [TestCase("pale", "bake", false)]
        [TestCase("p", "paa", false)]
        [TestCase("paaa", "pa", false)]
        public void ShouldCheckIfOneAway(string text1, string text2, bool expectedResult)
        {
            //Arrange
            IOneAwayChecker checker = new OneAwayChecker();

            //Act
            var result = checker.IsOneAway(text1, text2);

            //Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowExceptionIfTextIsNullOrEmpty(dynamic emptyText)
        {
            IOneAwayChecker checker = new OneAwayChecker();

            FluentActions.Invoking(() => checker.IsOneAway(emptyText, emptyText))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

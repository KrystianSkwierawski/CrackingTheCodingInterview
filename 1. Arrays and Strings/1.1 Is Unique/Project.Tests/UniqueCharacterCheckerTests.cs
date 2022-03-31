using NUnit.Framework;
using FluentAssertions;
using System;

namespace Project.Tests
{
    public class UniqueCharacterCheckerTests
    {
        [Test]
        [TestCase("text", false)]
        [TestCase("uniquecharacterchecker", false)]
        [TestCase("cat", true)]
        public void ShouldCheckIfAllUniqueCharacters(string text, bool expectedResult)
        {
            //Arrange
            IUniqueCharacterChecker checker = new UniqueCharacterChecker();

            //Act
            bool result = checker.HasAllUniqueCharacter(text);

            //Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowExceptionIfTextIsNullOrEmpty(dynamic emptyText)
        {
            IUniqueCharacterChecker checker = new UniqueCharacterChecker();

            FluentActions.Invoking(() => checker.HasAllUniqueCharacter(emptyText))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

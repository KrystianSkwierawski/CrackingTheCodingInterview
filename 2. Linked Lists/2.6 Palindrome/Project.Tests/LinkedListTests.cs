using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Project.Tests
{
    public class LinkedListTests
    {
        [Test]
        [TestCase("racecar", true)]
        [TestCase("01210", true)]
        [TestCase("Racecar", false)]
        [TestCase("cat", false)]
        public void ShouldCheckIfIsPalidrome(string list, bool expectedResult)
        {
            //Arrange
            ILinkedList<char> linkedList = new LinkedList<char>(list.ToList());


            //Act
            var result = linkedList.IsPalidrome();


            //Assert
            result.Should().Be(expectedResult);
        }


        [Test]
        public void ShouldThrowExceptionIfHeadIsNull()
        {
            FluentActions.Invoking(() => new LinkedList<char>().IsPalidrome())
                .Should().Throw<ArgumentNullException>();
        }
    }
}

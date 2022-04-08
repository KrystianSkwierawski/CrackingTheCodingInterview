using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class LinkedListTests
    {
        [Test]
        public void ShouldRemoveDups()
        {
            //Arrange
            LinkedList<int> linkedList = new(new int[] { 1, 3, 7, 6, 1, 7, 1, 1});


            //Act
            linkedList.RemoveDups();


            //Assert
            LinkedList<int> expectedResult = new(new int[] {1, 3, 7, 6});
            linkedList.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void ShouldThrowExceptionIfHeadIsNull()
        {
            FluentActions.Invoking(() => new LinkedList<int>().RemoveDups())
                .Should().Throw<ArgumentNullException>();
        }
    }
}

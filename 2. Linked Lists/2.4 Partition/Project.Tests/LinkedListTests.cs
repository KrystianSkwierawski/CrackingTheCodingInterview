using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class LinkedListTests
    {
        [Test]
        [TestCase(new int[] { 3, 5, 8, 5, 10, 2 ,1 }, new int[] { 3, 2, 1, 5, 8, 5, 10 }, 5)]
        public void ShouldDoPartition(int[] list, int[] expectedList, int x)
        {
            //Arrange
            ILinkedList<int> linkedList = new LinkedList<int>(list);


            //Act
            var result = linkedList.DoPartition(x);


            //Assert
            ILinkedList<int> expectedResult = new LinkedList<int>(expectedList);
            result.List.Should().BeEquivalentTo(expectedResult.List);
        }

        [Test]
        public void ShouldThrowExceptionIfNodeIsNull()
        {
            FluentActions.Invoking(() => new LinkedList<int>().DoPartition(0))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

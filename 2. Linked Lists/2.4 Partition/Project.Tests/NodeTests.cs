using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Tests
{
    public class NodeTests
    {
        [Test]
        [TestCase(new int[] { 3, 5, 8, 5, 10, 2 ,1 }, new int[] { 3, 2, 1, 5, 8, 5, 10 }, 5)]
        public void ShouldDoPartition(int[] list, int[] expectedList, int x)
        {
            //Arrange
            ILinkedList<int> linkedList = new LinkedList<int>(list);


            //Act
            linkedList.DoPartition(linkedList.Head, x);


            //Assert
            ILinkedList<int> expectedResult = new LinkedList<int>(expectedList);
            linkedList.List.Should().BeEquivalentTo(expectedResult.List);
        }


        [Test]
        public void ShouldThrowExceptionIfNodeIsNull()
        {
            ILinkedList<int> linkedList = new LinkedList<int>();

            FluentActions.Invoking(() => linkedList.DoPartition(null, 0))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

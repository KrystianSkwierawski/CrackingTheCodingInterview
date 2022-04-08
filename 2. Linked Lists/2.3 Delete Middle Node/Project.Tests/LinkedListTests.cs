using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Tests
{
    public class LinkedListTests
    {
        [Test]
        public void ShouldDeleteMiddleNode()
        {
            //Arrange
            ILinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            Node<int> middleNode = linkedList.AddLast(2);
            linkedList.AddLast(3);


            //Act
            linkedList.DeleteMiddleNode(middleNode);


            //Assert
            var result = linkedList.List.Where(node => node == middleNode).ToList();
            result.Should().BeEmpty();
        }


        [Test]
        public void ShouldThrowExceptionIfNodeIsNull()
        {
            FluentActions.Invoking(() => new LinkedList<int>().DeleteMiddleNode(null))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

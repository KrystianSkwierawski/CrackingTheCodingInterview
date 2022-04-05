using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Project.Tests
{
    public class LinkedListTests
    {
        [Test]
        public void ShouldRemoveDups()
        {
            //Arrange
            LinkedList<int> linkedList = new();
            linkedList.AddLast(1);
            linkedList.AddLast(3);
            linkedList.AddLast(7);
            linkedList.AddLast(6);
            linkedList.AddLast(1);
            linkedList.AddLast(7);
            linkedList.AddLast(1);
            linkedList.AddLast(1);


            //Act
            linkedList.RemoveDups(linkedList.Head);

            //Assert
            LinkedList<int> expectedResult = new();
            expectedResult.AddLast(1);
            expectedResult.AddLast(3);
            expectedResult.AddLast(7);
            expectedResult.AddLast(6);

            linkedList.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void ShouldThrowExceptionIfNodeIsNull()
        {
            LinkedList<int> linkedList = new();

            FluentActions.Invoking(() => linkedList.RemoveDups(null))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

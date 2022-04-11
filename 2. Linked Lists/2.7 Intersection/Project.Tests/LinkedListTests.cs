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
        [TestCase(new int[] { 3, 1, 5, 9, 7, 2, 1 }, new int[] { 4, 6, 7, 2, 1 }, new int[] { 7, 2, 1 })]
        [TestCase(new int[] { 3, 1, 5, 9, 7, 2, 1 }, new int[] { 2, 5, 4, 6, 7, 2, 1 }, new int[] { 7, 2, 1 })]
        [TestCase(new int[] { 4, 6, 7, 2, 1 }, new int[] { 3, 1, 5, 9, 7, 2, 1 }, new int[] { 7, 2, 1 })]
        [TestCase(new int[] { 1, 5, 6, 9, 2, 1 }, new int[] { 4, 5, 6, 9, 2 }, new int[] { 5, 6, 9, 2 })]
        [TestCase(new int[] { 1, 2, 3, 5, 2, 9 }, new int[] { 1, 2, 3, 8, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 8, 2 }, new int[] { 1, 2, 3, 5, 2, 9 }, new int[] { 1, 2, 3 })]
        public void ShouldGetIntersectingLinkedList(int[] list1, int[] list2, int[] expectedList)
        {
            //Arrange
            ILinkedList<int> linkedList1 = new LinkedList<int>(list1);
            ILinkedList<int> linkedList2 = new LinkedList<int>(list2);


            //Act
            var result = LinkedList<int>.GetIntersectingLinkedList(linkedList1.Head, linkedList2.Head);


            //Assert
            ILinkedList<int> expectedResult = new LinkedList<int>(expectedList);
            result.Should().BeEquivalentTo(expectedResult);
        }


        [Test]
        public void ShouldThrowExceptionIfHeadIsNull()
        {
            FluentActions.Invoking(() => LinkedList<int>.GetIntersectingLinkedList(null, null))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

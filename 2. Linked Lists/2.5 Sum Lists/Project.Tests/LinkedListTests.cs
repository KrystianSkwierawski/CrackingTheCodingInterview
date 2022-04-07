using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class LinkedListTests
    {
        [Test]
        [TestCase(new int[] { 7, 1, 6 }, new int[] { 5, 9, 2 }, 912)]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 2)]
        [TestCase(new int[] { 1, 1 }, new int[] { 1, 1 }, 22)]
        [TestCase(new int[] { 0 }, new int[] { 0 }, 0)]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, 0)]
        public void ShouldSumLists(int[] list1, int[] list2, int expectedResult)
        {
            //Arrange
            ILinkedList<int> linkedList = new LinkedList<int>(list1);
            ILinkedList<int> linkedList2 = new LinkedList<int>(list2);


            //Act
            var result = linkedList.SumLists(linkedList2);

            //Assert
            result.Should().Be(expectedResult);
        }


        [Test]
        public void ShouldThrowExceptionIfNodeIsNull()
        {
            ILinkedList<int> linkedList = new LinkedList<int>();

            FluentActions.Invoking(() => linkedList.SumLists(null))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

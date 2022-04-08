using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class LinkedListTests
    {
        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 7)]
        [TestCase(0, 1)]
        public void ShouldFindKthToLast(int kth, int expectedResult)
        {
            ILinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 3, 7, 6, 1, 7, 1});

            var result = linkedList.FindKthToLast(kth);

            result.Should().Be(expectedResult);
        }

        [Test]
        public void ShouldThrowExceptionIfNotFoundNodeByIndex()
        {
            FluentActions.Invoking(() => new LinkedList<int>().FindKthToLast(1000000))
                .Should().Throw<Exception>();
        }

        [Test]
        public void ShouldThrowExceptionIfHeadIsNull()
        {
            FluentActions.Invoking(() => new LinkedList<int>().FindKthToLast(1))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

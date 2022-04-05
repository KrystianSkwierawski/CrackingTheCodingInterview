using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class LinkedListTests
    {
        ILinkedList<int> _linkedList;

        public LinkedListTests()
        {
            _linkedList = new LinkedList<int>();
            _linkedList.AddLast(1);
            _linkedList.AddLast(3);
            _linkedList.AddLast(7);
            _linkedList.AddLast(6);
            _linkedList.AddLast(1);
            _linkedList.AddLast(7);
            _linkedList.AddLast(1);
        }


        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 7)]
        public void ShouldFindKthToLast(int kth, int expectedResult)
        {
            var result = _linkedList.FindKthToLast(_linkedList.Head, kth);

            result.Should().Be(expectedResult);
        }

        [Test]
        public void ShouldThrowExceptionIfNotFoundNodeByIndex()
        {
            FluentActions.Invoking(() => _linkedList.FindKthToLast(_linkedList.Head, 1000000))
                .Should().Throw<Exception>();
        }

        [Test]
        public void ShouldThrowExceptionIfNodeIsNull()
        {
            FluentActions.Invoking(() => _linkedList.FindKthToLast(null, 0))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

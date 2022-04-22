using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class ThreeInOneTests
    {
        [Test]
        public void PopShouldRemoveLastItem()
        {
            IThreeInOne threeInOne = new ThreeInOne(new int[] { 1, 2, 3 }, null, null);

            var removedItem = threeInOne.Pop(0);

            removedItem.Should().Be(3);
        }

        [Test]
        public void PopShouldThrowExceptionIfStackIsEmpty()
        {
            FluentActions.Invoking(() => new ThreeInOne(null, null, null).Pop(0))
                .Should().Throw<Exception>();
        }

        [Test]
        public void PushShouldAddLastItem()
        {
            IThreeInOne threeInOne = new ThreeInOne(new int[] { 1, 2, 3 }, null, null);

            var newStackLength = threeInOne.Push(0, 5);

            newStackLength.Should().Be(4);
        }

        [Test]
        public void PeekShouldReturnLastItem()
        {
            IThreeInOne threeInOne = new ThreeInOne(new int[] { 1, 2, 3 }, null, null);

            var lastItem = threeInOne.Peek(0);

            lastItem.Should().Be(3);
        }

        [Test]
        public void PeekShouldThrowExceptionIfStackIsEmpty()
        {
            FluentActions.Invoking(() => new ThreeInOne(null, null, null).Peek(0))
                .Should().Throw<Exception>();
        }

        [Test]
        public void ShouldCheckIfIsEmpty()
        {
            IThreeInOne threeInOne = new ThreeInOne(new int[] { 1, 2, 3 }, null, null);

            var initializedArrayResult = threeInOne.IsEmpty(0);
            var emptyArrayResult = threeInOne.IsEmpty(1);

            initializedArrayResult.Should().BeFalse();
            emptyArrayResult.Should().BeTrue();
        }
    }
}

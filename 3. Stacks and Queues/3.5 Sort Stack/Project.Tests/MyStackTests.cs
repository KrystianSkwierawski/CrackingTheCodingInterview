using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class MyStackTests
    {

        [Test]
        [TestCase(new int[] { 1, 5, 4, 8, 2 }, new int[] { 1, 2, 4, 5, 8 })]
        [TestCase(new int[] { 1, 5, 4, 8, 2, 7 }, new int[] { 1, 2, 4, 5, 7, 8 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]

        public void ShouldSortStack(int[] list, int[] expectedList)
        {
            MyStack stack = new MyStack(list);

            stack.Sort();

            stack.List.Should().BeEquivalentTo(
                    expectedList
                );
        }


        [Test]
        public void RemoveShouldThrowExceptionIfStackIsEmpty()
        {
            FluentActions.Invoking(() => new MyStack().Sort())
                .Should().Throw<Exception>();
        }
    }
}

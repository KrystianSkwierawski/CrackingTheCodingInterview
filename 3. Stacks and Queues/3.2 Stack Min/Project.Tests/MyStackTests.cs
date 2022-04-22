using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Project.Tests
{
    public class MyStackTests
    {
        [Test]
        public void ShouldReturnMinValue()
        {
            MyStack myStack = new(new int[] { 5, 6, 7, 1, 8 });

            var result = myStack.Min();

            result.Should().Be(1);
        }


        [Test]
        public void ShouldReturnMinValueWhenSomePops()
        {
            MyStack myStack = new(new int[] { 5, 6, 7, 1, 8 });
            myStack.Pop();
            myStack.Pop(); //5, 6, 7

            var result = myStack.Min();

            result.Should().Be(5);
        }


        [Test]
        public void RemoveShouldThrowExceptionIfStackIsEmpty()
        {
            FluentActions.Invoking(() => new MyStack().Min())
                .Should().Throw<Exception>();
        }
    }
}

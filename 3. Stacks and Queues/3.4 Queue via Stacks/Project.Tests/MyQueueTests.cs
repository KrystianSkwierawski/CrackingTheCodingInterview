using NUnit.Framework;
using FluentAssertions;
using System;

namespace Project.Tests
{
    public class MyQueueTests
    {
        [Test]
        public void ShouldAdd()
        {
            //Arrange
            MyQueue<int> queue = new();
            queue.Add(1);
            queue.Add(2);
            queue.Add(3);


            //Act
            var peekResult = queue.Peek();


            //Assert
            queue.List.Should().BeEquivalentTo(new int[] { 1, 2, 3 });
            peekResult.Should().Be(1);
        }

        [Test]
        public void ShouldPeek()
        {
            //Arrange
            MyQueue<int> queue = new(new int[] { 1, 2, 3 });

            //Act
            var result = queue.Peek();

            //Assert
            result.Should().Be(1);
        }


        [Test]
        public void PeekShouldThrowExceptionIfStackIsEmpty()
        {
            FluentActions.Invoking(() => new MyQueue<int>().Peek())
                .Should().Throw<Exception>();
        }

        [Test]
        public void ShouldRemove()
        {
            //Arrange
            MyQueue<int> queue = new(new int[] { 1, 2, 3 });

            //Act
            var result = queue.Remove();

            //Assert
            result.Should().Be(1);
            queue.List.Should().HaveCount(2);
            queue.List.Should().BeEquivalentTo(new int[] { 2, 3 });
        }

        [Test]
        public void RemoveShouldThrowExceptionIfStackIsEmpty()
        {
            FluentActions.Invoking(() => new MyQueue<int>().Remove())
                .Should().Throw<Exception>();
        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class LinkedListTests
    {
        [Test]
        public void ShouldGetBeginningOfTheLoop()
        {
            //Arrange
            ILinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            Node<int> beginningOfTheLoop = linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);
            linkedList.AddLast(beginningOfTheLoop);


            //Act
            var result = linkedList.GetBeginningOfTheLoopIfExists();


            //Assert
            result.Should().Be(beginningOfTheLoop);
        }

        [Test]
        public void ShouldGetBeginningOfTheLoopWhenListIsRandom()
        {
            //Arrange
            ILinkedList<int> linkedList = new LinkedList<int>();
            Node<int> beginningOfTheLoop = linkedList.AddLast(3);

            for (int i = 0; i < new Random().Next(1, 1000); i++)
            {
                linkedList.AddLast(new Random().Next(1, 1000));
            }

            linkedList.AddLast(beginningOfTheLoop);


            //Act
            var result = linkedList.GetBeginningOfTheLoopIfExists();


            //Assert
            result.Should().Be(beginningOfTheLoop);
        }

        [Test]
        public void ShouldReturnNullWhenLoopDoesNotExists()
        {
            //Arrange
            ILinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });

            //Act
            var result = linkedList.GetBeginningOfTheLoopIfExists();

            //Assert
            result.Should().BeNull();
        }

        [Test]
        public void ShouldThrowExceptionIfHeadIsNull()
        {
            FluentActions.Invoking(() => new LinkedList<int>().GetBeginningOfTheLoopIfExists())
                .Should().Throw<ArgumentNullException>();
        }
    }
}

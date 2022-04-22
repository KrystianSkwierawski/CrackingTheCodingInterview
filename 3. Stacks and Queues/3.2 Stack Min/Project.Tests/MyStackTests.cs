using FluentAssertions;
using NUnit.Framework;

namespace Project.Tests
{
    public class MyStackTests
    {
        [Test]
        public void ShouldReturnMinValue()
        {
            MyStack<int> myStack = new MyStack<int>();
            myStack.Push(4);
            myStack.Push(2);
            myStack.Push(1);
            myStack.Push(3);


            var result = myStack.Min();


            result.Should().Be(1);
        }
    }
}

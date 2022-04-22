using FluentAssertions;
using NUnit.Framework;

namespace Project.Tests
{
    public class SetOfStacksTests
    {
        [Test]
        public void ShouldPopAt()
        {
            SetOfStacks<int> setOfStacks = new();
            setOfStacks.Push(1);
            setOfStacks.Push(2);
            setOfStacks.Push(3);

            setOfStacks.Push(4); // new set of stacks
            setOfStacks.Push(5);


            var result = setOfStacks.PopAt(1);


            result.Should().Be(5);
            setOfStacks.Stacks.Should().HaveCount(2);
            setOfStacks.Peek().Should().Be(4);
        }

        [Test]
        public void ShouldPop()
        {
            SetOfStacks<int> setOfStacks = new();
            setOfStacks.Push(1);
            setOfStacks.Push(2);
            setOfStacks.Push(3);

            setOfStacks.Push(4); // new set of stacks


            var result = setOfStacks.PopAt(1);


            result.Should().Be(4);
            setOfStacks.Stacks.Should().HaveCount(1);
            setOfStacks.Peek().Should().Be(3);
        }
    }
}

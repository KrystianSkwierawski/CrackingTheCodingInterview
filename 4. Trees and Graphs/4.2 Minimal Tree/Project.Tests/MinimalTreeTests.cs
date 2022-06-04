using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Project.Tests
{
    public class MinimalTreeTests
    {
        [Test]
        [TestCase(new int[] { 4, 8, 9, 16, 17, 19, 26, 32, 50, 55, 69, 93 })]
        [TestCase(new int[] { 1, 2, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1 })]
        public void ShouldCreateMinimalTree(int[] sortedArray)
        {
            IMinimalTree minimalTree = new MinimalTree(sortedArray);


            var nodes = minimalTree.GetNodes(minimalTree.Root);
            nodes.Select(Node => Node.Value).Should().BeEquivalentTo(sortedArray);
            nodes.Count().Should().Be(sortedArray.Length);
        }

        [Test]
        public void Constructor_ShouldThrowExceptionIfArrayIsNullOrEmpty()
        {
            FluentActions.Invoking(() => new MinimalTree(null))
                .Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void GetNodesInOrderTraversal_ShouldThrowExceptionIfRootIsNull()
        {
            IMinimalTree minimalTree = new MinimalTree(new int[] { 1 });

            FluentActions.Invoking(() => minimalTree.GetNodes(null))
                .Should().Throw<ArgumentNullException>();
        }

        //TODO: add get nodes tests some tests
    }
}

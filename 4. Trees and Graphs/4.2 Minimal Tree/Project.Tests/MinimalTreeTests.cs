using NUnit.Framework;
using FluentAssertions;
using System.Linq;

namespace Project.Tests
{
    public class MinimalTreeTests
    {
        [Test]
        [TestCase(new int[] { 4, 8, 9, 16, 17, 19, 26, 32, 50, 55, 69, 93 })]
        [TestCase(new int[] { 1, 2, 4, 5, 6, 7, 8, 9 })]
        public void ShouldCreateMinimalTree(int[] sortedArray)
        {
            MinimalTree minimalTree = new MinimalTree(sortedArray);


            var nodes = minimalTree.NodesInOrderTraversal;
            nodes.Select(Node => Node.Value).Should().BeEquivalentTo(sortedArray);
            nodes.Count().Should().Be(sortedArray.Length);
        }
    }
}

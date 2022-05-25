using FluentAssertions;
using NUnit.Framework;

namespace Project.Tests
{
    public class GraphTests
    {
        [Test]
        public void DFSSearch_ShouldReturnTrueWhenCorrectPath()
        {
            //Arrange
            Graph graph = new Graph();
            var (root, end) = graph.InitializeTestData();


            //Act
            bool result = graph.IsRouteBetweenTwoRoutes(root, end, TypeOfSearch.DFS);


            //Assert
            result.Should().BeTrue();
        }

        [Test]
        public void DFSSearch_ShouldReturnFalseWhenIncorrectPath()
        {
            //Arrange
            Graph graph = new Graph();
            var (root, end) = graph.InitializeTestData();


            //Act
            bool result = graph.IsRouteBetweenTwoRoutes(end, root, TypeOfSearch.DFS);


            //Assert
            result.Should().BeFalse();
        }
    }
}

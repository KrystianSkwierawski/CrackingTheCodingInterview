using FluentAssertions;
using NUnit.Framework;

namespace Project.Tests
{
    public class GraphTests
    {
        [Test]
        [TestCase(TypeOfSearch.DFS)]
        [TestCase(TypeOfSearch.BFS)]
        public void ShouldReturnTrueWhenCorrectPath(TypeOfSearch typeOfSearch)
        {
            //Arrange
            IGraph graph = new Graph();
            var (root, end) = graph.InitializeTestData();


            //Act
            bool result = graph.IsRouteBetweenTwoRoutes(root, end, typeOfSearch);


            //Assert
            result.Should().BeTrue();
        }

        [Test]
        [TestCase(TypeOfSearch.DFS)]
        [TestCase(TypeOfSearch.BFS)]
        public void ShouldReturnFalseWhenIncorrectPath(TypeOfSearch typeOfSearch)
        {
            //Arrange
            IGraph graph = new Graph();
            var (root, end) = graph.InitializeTestData();


            //Act
            bool result = graph.IsRouteBetweenTwoRoutes(end, root, typeOfSearch);


            //Assert
            result.Should().BeFalse();

        }

        [Test]
        public void ShouldInitializeTestData()
        {
            //Arrange
            IGraph graph = new Graph();


            //Act
            var (root, end) = graph.InitializeTestData();


            //Assert
            root.Should().NotBeNull();
            end.Should().NotBeNull();
            root.Value.Should().Be(0);
            end.Value.Should().Be(3);
        }
    }
}

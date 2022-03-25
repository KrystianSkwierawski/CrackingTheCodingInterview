using FluentAssertions;
using NUnit.Framework;
using System;

namespace Project.Tests
{
    public class PermutationCheckerTests
    {
        [Test]
        [TestCase("cat", "tac", true)]
        [TestCase("testt", "tset", false)]
        [TestCase("test", "tset", true)]
        public void Test1(string text1, string text2, bool expectedResult)
        {
            IPermutationChecker checker = new PermutationChecker();

            var result = checker.IsPermutation(text1, text2);

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowExceptionIfTextIsNullOrEmpty(dynamic emptyText)
        {
            IPermutationChecker checker = new PermutationChecker();

            FluentActions.Invoking(() => checker.IsPermutation(emptyText, emptyText))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

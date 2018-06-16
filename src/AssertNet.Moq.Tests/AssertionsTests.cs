using Moq;
using Xunit;
using static AssertNet.Moq.Assertions;

namespace AssertNet.Moq.Tests
{
    /// <summary>
    /// Test class for the <see cref="Assertions"/> class.
    /// </summary>
    public static class AssertionsTests
    {
        /// <summary>
        /// Checks that the assertion is created correctly.
        /// </summary>
        [Fact]
        public static void AssertThatTest()
        {
            Mock<object> target = new Mock<object>();
            MockAssertion<object> assertion = AssertThat(target);
            Assert.NotNull(assertion);
            Assert.Same(target, assertion.Target);
        }
    }
}

using System;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests
{
    /// <summary>
    /// Test class for the <see cref="VoidAssertion"/> class.
    /// </summary>
    public static class VoidAssertionTests
    {
        /// <summary>
        /// Checks that the constructor functions properly.
        /// </summary>
        [Fact]
        public static void ConstructorTest()
        {
            IFailureHandler handler = new Mock<IFailureHandler>().Object;
            Action action = new Mock<Action>().Object;
            VoidAssertion assertion = new VoidAssertion(handler, action);
            Assert.Same(handler, assertion.FailureHandler);
        }
    }
}

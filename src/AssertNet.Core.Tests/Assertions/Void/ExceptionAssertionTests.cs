using System;
using AssertNet.Core.Assertions.Void;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Void
{
    /// <summary>
    /// Test class for the <see cref="ExceptionAssertion"/> class.
    /// </summary>
    public class ExceptionAssertionTests
    {
        private readonly Mock<IFailureHandler> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionAssertionTests"/> class.
        /// </summary>
        public ExceptionAssertionTests()
        {
            _handler = new Mock<IFailureHandler>();
        }

        /// <summary>
        /// Checks that the constructor functions properly.
        /// </summary>
        [Fact]
        public void ConstructorTest()
        {
            Exception e = new Mock<Exception>().Object;
            ExceptionAssertion assertion = new ExceptionAssertion(_handler.Object, e);
            Assert.Same(_handler.Object, assertion.FailureHandler);
            Assert.Same(e, assertion.Exception);
        }
    }
}

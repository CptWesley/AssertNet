using System;
using AssertNet.Core.Failures;
using AssertNet.FailureHandlers;
using Xunit;

namespace AssertNet.Tests.Xunit.FailureHandlers
{
    /// <summary>
    /// Test class for the <see cref="FallbackFailureHandler"/> class.
    /// </summary>
    public class FallbackFailureHandlerTests
    {
        private readonly IFailureHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="FallbackFailureHandlerTests"/> class.
        /// </summary>
        public FallbackFailureHandlerTests()
        {
            handler = new FallbackFailureHandler();
        }

        /// <summary>
        /// Checks that the handler is available.
        /// </summary>
        [Fact]
        public void AvailableTest()
        {
            Assert.True(handler.IsAvailable());
        }

        /// <summary>
        /// Tests that calling a failure throws the correct exception.
        /// </summary>
        [Fact]
        public void FailTest()
        {
            string msg = "435h9d 432 0";
            Exception e = Assert.Throws<AssertionFailedException>(() => handler.Fail(msg));
            Assert.Equal(msg, e.Message);
        }
    }
}

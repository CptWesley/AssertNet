using System;
using AssertNet.FailureHandlers;
using Xunit;
using Xunit.Sdk;

namespace AssertNet.Tests.Xunit.FailureHandlers
{
    /// <summary>
    /// Test class for the <see cref="XunitFailureHandler"/> class.
    /// </summary>
    public class XunitFailureHandlerTests
    {
        private readonly XunitFailureHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="XunitFailureHandlerTests"/> class.
        /// </summary>
        public XunitFailureHandlerTests()
        {
            handler = new XunitFailureHandler();
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
            Exception e = Assert.Throws<XunitException>(() => handler.Fail(msg));
            Assert.Equal(msg, e.Message);
        }
    }
}

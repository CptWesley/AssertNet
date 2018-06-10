using System;
using Xunit;
using Xunit.Sdk;

namespace AssertNet.Xunit.Tests
{
    /// <summary>
    /// Test class for the <see cref="XunitFailureHandler"/> class.
    /// </summary>
    public class XunitFailureHandlerTests
    {
        private XunitFailureHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="XunitFailureHandlerTests"/> class.
        /// </summary>
        public XunitFailureHandlerTests()
        {
            _handler = new XunitFailureHandler();
        }

        /// <summary>
        /// Tests that calling a failure throws the correct exception.
        /// </summary>
        [Fact]
        public void FailTest()
        {
            string msg = "435h9d 432 0";
            Exception e = Assert.Throws<XunitException>(() => _handler.Fail(msg));
            Assert.Equal(msg, e.Message);
        }
    }
}

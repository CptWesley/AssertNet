using System;
using AssertNet.FailureHandlers;
using NUnit.Framework;

namespace AssertNet.Tests.Nunit
{
    /// <summary>
    /// Test class for the <see cref="NunitFailureHandler"/> class.
    /// </summary>
    [TestFixture]
    public class NunitFailureHandlerTests
    {
        private readonly NunitFailureHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="NunitFailureHandlerTests"/> class.
        /// </summary>
        public NunitFailureHandlerTests()
        {
            handler = new NunitFailureHandler();
        }

        /// <summary>
        /// Checks that the handler is available.
        /// </summary>
        [Test]
        public void AvailableTest()
        {
            Assert.True(handler.IsAvailable());
        }

        /// <summary>
        /// Tests that calling a failure throws the correct exception.
        /// </summary>
        [Test]
        public void FailTest()
        {
            string msg = "54363tr3f4";
            Exception e = Assert.Throws<AssertionException>(() => handler.Fail(msg));
            Assert.AreEqual(msg, e.Message);
        }
    }
}

using System;
using AssertNet.NUnit;
using NUnit.Framework;

namespace AssertNet.Nunit.Tests
{
    /// <summary>
    /// Test class for the <see cref="NUnitFailureHandler"/> class.
    /// </summary>
    [TestFixture]
    public class NUnitFailureHandlerTests
    {
        private NUnitFailureHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="NUnitFailureHandlerTests"/> class.
        /// </summary>
        public NUnitFailureHandlerTests()
        {
            _handler = new NUnitFailureHandler();
        }

        /// <summary>
        /// Tests that calling a failure throws the correct exception.
        /// </summary>
        [Test]
        public void FailTest()
        {
            string msg = "54363tr3f4";
            Exception e = Assert.Throws<AssertionException>(() => _handler.Fail(msg));
            Assert.AreEqual(msg, e.Message);
        }
    }
}
